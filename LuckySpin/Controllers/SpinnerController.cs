using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.Services;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        private ISpinService spinService;
        private ISpinRepository spinRepository;
        
        /***
         * Controller Constructor with Dependency Injection of a SpinRepository object
         */
        public SpinnerController(ISpinRepository r, ISpinService s)
        {
            spinRepository = r;
            spinService = s;
        }

        /***
         * Entry Page Action
         **/

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Player player)
        {
            if (ModelState.IsValid) {
                //Save the current player in the repository
                spinRepository.SetPlayer(player);
                return RedirectToAction("SpinIt");
            }
            return View();
        }

        /***
         * Spin Action
         **/  
         [HttpGet]      
         public IActionResult SpinIt(int luck) 
        {
            //Check if enough balance to play, if not drop out to LuckList
            if (!spinRepository.GetPlayer().ChargeSpin())
            {
                return RedirectToAction("LuckList");
            }
            //If a luck value is passed, use it otherwise use the saved one
            var Luck = luck > 0 ? luck : spinRepository.GetPlayer().Luck;

            //Create the current Spin
            Spin spin = spinService.SpinIt(Luck);

            //Compute the average wins
            spin.AverageWins = spinService.CalculateAvgWins(spin.IsWinning);

            //Add to Spin Repository
            spinRepository.AddSpin(spin);

            //Prepare the View
            if (spin.IsWinning)
            {
                ViewBag.Display = "block";
                spinRepository.GetPlayer().CollectWinnings();
            }
            else
                ViewBag.Display = "none";

            ViewBag.FirstName = spinRepository.GetPlayer().FirstName;
            ViewBag.Balance = spinRepository.GetPlayer().Balance;

            return View("SpinIt", spin);
        }

        /***
         * ListSpins Action
         **/

         public IActionResult LuckList()
        {
            ViewBag.Balance = 0;
            return View(spinRepository.GetSpins());
        }

    }
}

