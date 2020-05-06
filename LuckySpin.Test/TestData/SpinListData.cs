using System;
using System.Collections.Generic;
using LuckySpin.Models;
namespace LuckySpin.Test.TestData
{
    public class SpinListData
    {
        private static List<Spin> spins = new List<Spin>
            {
                new Spin{ Luck = 7, IsWinning=true },
                new Spin{ Luck = 7, IsWinning=true },
                new Spin{ Luck = 7, IsWinning=false },
                new Spin{ Luck = 7, IsWinning=false },
                new Spin{ Luck = 7, IsWinning=true },
                new Spin{ Luck = 7, IsWinning=false },
                new Spin{ Luck = 7, IsWinning=false },
                new Spin{ Luck = 7, IsWinning=false },
                new Spin{ Luck = 7, IsWinning=true },
                new Spin{ Luck = 7, IsWinning=false }
            };

        public static IEnumerable<Spin> GetSpins()
        { 
            return spins;
        }

        public static int GetCount()
        {
            return spins.ToArray().Length;
        }
        
    }
}
