using System;
using Xunit;
using Moq;
using LuckySpin.Models;
using LuckySpin.Services;
using LuckySpin.Repositories;
using LuckySpin.Test.TestData;

namespace LuckySpin.Test
{
    public class SpinServiceTest
    {
        [Theory] //BONUS: Refactor into a Theory that tests both a winning and losing spin
        [InlineData(true)]
        [InlineData(false)]
        public void SpinService_CalculateAvgWins_WinningSpin(bool isWinning)
        {
            //Arrange - create your Mock elements; setup the mockRepo to return TestData
            var mockRepo = new Mock<ISpinRepository>();
            //TODO: Use the Setup() and Returns() methods of mockRepo
            //       to arrange for a consistent, expected output based on TestData
            mockRepo.Setup(r => r.GetSpins()).Returns(SpinListData.GetSpins());
            mockRepo.Setup(r => r.GetCount()).Returns(SpinListData.GetCount());


            var service = new SpinService(mockRepo.Object);

            service.IsWinning = isWinning;
            //Act - run the method that you are testing and get a result
            double result = service.CalculateAvgWins();

            //Assert - compare the expected output from TestData to the method result
            // TODO: check the repo data for the number of previous spins and wins, add one winning spin
            double count = 10 + 1;
            double wins;
            if (isWinning)
            {
                wins = 4 + 1;
            }
            else
            {
                wins = 4;
            }
            double expected = wins / count;
            Assert.Equal(expected, result);
        }
    }
}
