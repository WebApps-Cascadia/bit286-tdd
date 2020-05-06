using System;
using LuckySpin.Models;
namespace LuckySpin.Services
{
    public interface ISpinService
    {
        public Double CalculateAvgWins();
        public Spin SpinIt(int Lucky);
    }
}
