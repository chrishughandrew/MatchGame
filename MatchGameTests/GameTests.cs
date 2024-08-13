using MatchGame;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
