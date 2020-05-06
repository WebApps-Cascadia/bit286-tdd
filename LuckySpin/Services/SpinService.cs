using System;
using System.Linq;
using LuckySpin.Models;
using LuckySpin.Repositories;

namespace LuckySpin.Services
{
    public class SpinService : ISpinService //Makes this class extend the Interface ISpinService
    {
        Random random = new Random();
        public bool IsWinning;
        private ISpinRepository spinRepository;
        //Constructor with Dependency Injection
        public SpinService(ISpinRepository sr)
        {
            spinRepository = sr;

        }


        public double CalculateAvgWins()
        {
            //TODO: Write logic to use the "real" spinRepository NOT the test data
            double wins = spinRepository.GetSpins().Count(s => s.IsWinning) + (IsWinning ? 1 : 0);
            double spins = spinRepository.GetCount() + 1;
            return wins / spins;
        }

        public Spin SpinIt(int luck)
        {
            int a, b, c;
            a = random.Next(1, 10);
            b = random.Next(1, 10);
            c = random.Next(1, 10);
            IsWinning = (a == luck || b == luck || c == luck);
            return new Spin()
            {
                A = a,
                B = b,
                C = c,
                IsWinning = IsWinning,
                Luck = luck
            };
        }
    }
}
