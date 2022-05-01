using System;
using LuckySpin.Models;
namespace LuckySpin.Services
{
    public interface ISpinService
    {
        public Double CalculateAvgWins(bool IsWinning);
        public Spin SpinIt(int Lucky);
    }
}