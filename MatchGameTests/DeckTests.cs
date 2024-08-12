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

        [Fact]
        public void BuildStandardPack_GeneratesFiftyTwoCardPack()
        {
            //Arrange
            Deck deck = new();
            const int standardPackSize = 52;
            //Act
            var listOfCards = deck.BuildStandardPack();
            //Assert
            Assert.Equal(standardPackSize, listOfCards.Count);
        }
       
    }
}