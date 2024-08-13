using MatchGame;
using Newtonsoft.Json.Bson;
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
            Assert.Equal(expected, deck.Cards.Count);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void BuildMultiplePacks_ThrowsArgumentExceptionWhenZeroOrLess(int methodInput)
        {
            //Arrange
            Deck deck = new();
            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>( () => deck.BuildMultiplePacks(methodInput));
        }

        [Fact]
        public void Shuffle_ResultsInDifferentOrderOfCardsPropInDeck()
        {
            //Arrange
            Deck deck = new();
            List<Card> originalOrder = deck.Cards;
            //Act 
            deck.Shuffle();
            List<Card> newOrder = deck.Cards;
            //Assert
            Assert.NotEqual(originalOrder, newOrder);

        }

        [Fact]
        public void TakeCard_ReturnsTheTopCardFromTheDeck()
        {
            //Arrang
            Deck deck = new();
            Card firstCard = deck.Cards[0];

            //Act
            Card returnedCard = deck.TakeCard();

            //Assert
            Assert.Equal(firstCard, returnedCard);
            
        }

        [Fact]
        public void TakeCard_RemovesCardFromTheDeck()
        {
            //Arrange
            Deck deck = new();
            int originalCount = deck.Cards.Count;
            int expectedCount = originalCount - 1;

            //Act
            Card _ = deck.TakeCard();
            int remainingCount = deck.Cards.Count;

            //Assert
            Assert.Equal(expectedCount, remainingCount);

        }

        [Fact]
        public void HasCards_ReturnsTrueWhenCardsInDeck()
        {
            
            //Arrange
            Deck deck = new();

            //Act
            bool actual = deck.HasCards;

            //Assert
            Assert.True(actual);
        }
        
        [Fact]
        public void HasCards_ReturnsFalseWhenCardsInDeck()
        {
            
            //Arrange
            Deck deck = new();
            deck.Cards.Clear();

            //Act
            bool actual = deck.HasCards;

            //Assert
            Assert.False(actual);
        }

    }
}