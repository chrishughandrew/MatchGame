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
            var packOfCards = deck.BuildStandardPack();
            //Assert
            Assert.Equal(standardPackSize, packOfCards.Count);
        }

        [Fact]
        public void BuildStandardPack_GeneratesFourOfEachValue()
        {
            //Arrange
            Deck deck = new();
            const int valueCount = 4;
            //Act
            var packOfCards = deck.BuildStandardPack();
            var frequencyList = packOfCards
                .GroupBy(i => i.Value)
                .Select(group => new
                {
                    Value = group.Key,
                    Freq = group.Count()
                })
                .OrderBy(group => group.Value);


            //Assert
            Assert.All(frequencyList,
                item => Assert.Equal(valueCount, item.Freq)
                );
        }

        [Fact]
        public void BuildStandardPack_GeneratesThirteenOfEachSuit()
        {
            //Arrange
            Deck deck = new();
            const int suitCount = 13;
            //Act
            var packOfCards = deck.BuildStandardPack();
            var frequencyList = packOfCards
                .GroupBy(i => i.Suit)
                .Select(group => new
                {
                    Suit = group.Key,
                    Freq = group.Count()
                })
                .OrderBy(group => group.Suit);

            //Assert
            Assert.All(frequencyList,
                item => Assert.Equal(suitCount, item.Freq)
                );
        }
    }
}