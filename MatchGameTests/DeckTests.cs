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
            const int countPerValue = 4;
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
                item => Assert.Equal(countPerValue, item.Freq)
                );
        }

        [Fact]
        public void BuildStandardPack_GeneratesThirteenOfEachSuit()
        {
            //Arrange
            Deck deck = new();
            const int countPerSuit = 13;
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
                item => Assert.Equal(countPerSuit, item.Freq)
                );
        }

        [Fact]
        public void BuildMultiplePacks_ReturnsListOfCards()
        {
            //Arrange
            Deck deck = new();
            //Act
            var listOfCards = deck.BuildMultiplePacks(1);
            //Assert
            Assert.IsType<List<Card>>(listOfCards);
        }

        [Theory]
        [InlineData(104, 2)]
        [InlineData(260, 5)]
        [InlineData(5200, 100)]
        public void BuildMultiplePacks_GeneratesPackSizeOfMultiplesOfFiftyTwoCards(int expected, int methodInput)
        {
            //Arrange
            Deck deck = new();
            //Act
            var deckOfCards = deck.BuildMultiplePacks(methodInput);
            //Assert
            Assert.Equal(expected, deckOfCards.Count);
        }


        //negative input 
        //zero input 


    }
}