using MatchGame;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatchGameTests
{
    public class GameTests
    {
        private readonly Game _sut;
        private readonly Mock<IDeck> _deckMock = new Mock<IDeck>();
        private readonly Mock<IPlayer> _player1Mock = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _player2Mock = new Mock<IPlayer>();

        public GameTests()
        {
            _sut = new Game(_deckMock.Object, _player1Mock.Object, _player2Mock.Object);
        }

        [Fact]
        public void DeclareWinner_ReturnsAResultEnum()
        {

            //Assert
            Assert.IsType<ResultEnum>(_sut.DeclareWinner());

        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(24)]
        public void DeclareWinner_ReturnsDrawWhenPlayerScoresAreEqual(int matchingScore)
        {
            //Arrange
            _player1Mock.Setup(x => x.Score).Returns(matchingScore);
            _player2Mock.Setup(x => x.Score).Returns(matchingScore);

            ResultEnum expected = ResultEnum.DRAW;
            //Act
            ResultEnum actual = _sut.DeclareWinner();
            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void DeclareWinner_ReturnsPlayer1WhenPlayer1ScoreIsGreater()
        {
            //Arrange
            _player1Mock.Setup(x => x.Score).Returns(1);
            _player2Mock.Setup(x => x.Score).Returns(0);

            ResultEnum expected = ResultEnum.PLAYER1;
            //Act
            ResultEnum actual = _sut.DeclareWinner();
            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void DeclareWinner_ReturnsPlayer2WhenPlayer1ScoreIsLess()
        {
            //Arrange
            _player1Mock.Setup(x => x.Score).Returns(1);
            _player2Mock.Setup(x => x.Score).Returns(23);

            ResultEnum expected = ResultEnum.PLAYER2;
            //Act
            ResultEnum actual = _sut.DeclareWinner();
            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Setup_SetsTheMatchingRuleForGamePlay()
        {
            //Arrange
            MatchRuleEnum matchRule = MatchRuleEnum.FULL;
            //Act
            var _ = _sut.Setup(matchRule, 1);
            MatchRuleEnum actual = _sut.MatchRule;
            //Assert
            Assert.Equal(matchRule, actual);
        }

        [Fact]
        public void Setup_InformsWhenFullMatchingRuleIsIncompatibleWithASinglePackDeck()
        {
            //Arrange
            MatchRuleEnum matchRule = MatchRuleEnum.FULL;
            int singlePack = 1;
            string expected = "You can play with this setup, but nobody ever wins!";
            
            //Act
            string actual= _sut.Setup(matchRule, singlePack);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Setup_InformsThatGameIsReadyToPlay()
        {
            //Arrange
            MatchRuleEnum matchRule = MatchRuleEnum.FULL;
            string expected = "The game is ready to play.";

            //Act
            string actual = _sut.Setup(matchRule, 3);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Play_ReturnsFromGameLoopWhenDeckHasNoCardsRemaining()
        {
            //Arrange
            _deckMock.Setup(x => x.HasCards).Returns(false);
            //Act
            bool gameOver = _sut.Play();
            //Assert
            Assert.True(gameOver);
        }


    }

}
