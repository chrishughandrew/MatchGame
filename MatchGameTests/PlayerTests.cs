using MatchGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchGameTests
{
    public class PlayerTests
    {
        [Theory]
        [InlineData(0,1,1)]
        [InlineData(5,5,10)]
        public void AddPoints_AddsGivenValueToPlayersCurrentScore(int originalScore, int pointsToAdd, int expectedResult)
        {
            //Arrange
            Player player = new();
            player.Score = originalScore;
            //Act
            player.AddPoints(pointsToAdd);
            //Assert
            Assert.Equal(expectedResult, player.Score);

        }

        [Fact]
        public void AddPoints_ThrowsArgRangeExceptionWhenArgsAreNegative()
        {
            //Arrange
            Player player = new();
            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => player.AddPoints(-1));

        }
    }
    
}
