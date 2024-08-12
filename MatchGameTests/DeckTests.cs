using MatchGame;
using System.Collections.Generic;
using System.Reflection;

namespace MatchGameTests
{
    public class DeckTests
    {
        [Fact]
        public void BuildStandardPack_ReturnsListOfCards()
        {
            //Arrange
            Deck deck = new();
            //Act
            var listOfCards = deck.BuildStandardPack();
            //Assert
            Assert.IsType<List<Card>>(listOfCards);
        }
    }
}