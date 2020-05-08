using System;
using LuckySpin.Models;
namespace LuckySpin.Services
{
    public interface ISpinService
    {
        public Double CalculateAvgWins(bool isWinning);
        public Spin SpinIt(int Lucky);
    }
}
