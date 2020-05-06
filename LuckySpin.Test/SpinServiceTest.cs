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
        [Fact] //BONUS: Refactor into a Theory that tests both a winning and losing spin
        public void SpinService_CalculateAvgWins_WinningSpin()
        {
            //Arrange - create your Mock elements; setup the mockRepo to return TestData
            var mockRepo = new Mock<ISpinRepository>();
            //TODO: Use the Setup() and Returns() methods of mockRepo
            //       to arrange for a consistent, expected output based on TestData

            mockRepo.Setup(r => r.GetSpins()).Returns(SpinListData.GetSpins());
            mockRepo.Setup(r => r.GetCount()).Returns(SpinListData.GetCount());
            var service = new SpinService(mockRepo.Object);

            //Act - run the method that you are testing and get a result
            double result = service.CalculateAvgWins();

            //Assert - compare the expected output from TestData to the method result
            // TODO: check the repo data for the number of previous spins and wins, add one winning spin
                double wins = 4 + 1 /*???*/, count = SpinListData.GetCount() + 1;
                double expected = wins / count;
            Assert.Equal(expected, result);
        }
    }
}
