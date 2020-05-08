using System;
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


        public double CalculateAvgWins()
        {
            //TODO: Write logic to use the "real" spinRepository NOT the test data
            Spin spin = new Spin();
            double count = spinRepository.GetCount() + 1;
            double sum = 1;
            double result = 0;
            double wins = 0;
            for (int i = 1; i < count; i++)
            {
                if (spin.IsWinning == true)
                {
                    wins += 1;
                }
                else
                {
                    wins += 0;
                }
            }
            result = (wins + 1) / count;
            return result; 
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
