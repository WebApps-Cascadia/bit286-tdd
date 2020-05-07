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
            double count = spinRepository.GetCount();
            double sum = 1;
            double result = 0;
            double win = 0;
            double loss = 0;
            for (int i = 0; i < count; i++)
            {
                if (spin.IsWinning == true)
                {
                    win = win + 1;
                }
                if (spin.IsWinning == false)
                {
                    loss = loss + 1;
                }
                sum = loss + win;
            }
            result = (win + 1) / (sum + 1);
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
