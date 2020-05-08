using System;
using System.Linq;
using LuckySpin.Models;
using LuckySpin.Repositories;
namespace LuckySpin.Services
{
    public class SpinService : ISpinService //Makes this class extend the Interface ISpinService
    {
        Random random = new Random();

        private ISpinRepository spinRepository;
        //Constructor with Dependency Injection
        public SpinService(ISpinRepository sr)
        {
            spinRepository = sr;
        }


        public double CalculateAvgWins(bool isWinning)
        {
            //TODO: Write logic to use the "real" spinRepository NOT the test data
            double winningCount = 0;
            double spinCounts = spinRepository.GetCount() + 1;

            if (isWinning)
                winningCount = 1;

            foreach (Spin spin in spinRepository.GetSpins())
            {
                if (spin.IsWinning)
                    winningCount++;
            }

            return winningCount / spinCounts;
        }

        public Spin SpinIt(int luck)
        {
            int a, b, c;
            a = random.Next(1, 10);
            b = random.Next(1, 10);
            c = random.Next(1, 10);

            return new Spin()
            {
                A = a,
                B = b,
                C = c,
                IsWinning = (a == luck || b == luck || c == luck),
                Luck = luck
            };
        }
    }
}
