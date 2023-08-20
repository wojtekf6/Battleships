using Battleships.Board;
using Battleships.Config;
using Battleships.Input;
using Battleships.Services;
using Battleships.Tests.Mocks;
using NUnit.Framework;

namespace Battleships.Tests
{
    [TestFixture]
    public class GameTest
    {
        private IInputController _input;
        private GameConfig _gameConfig;
        private ShipPlacementService _shipPlacementService;
        private GameBoard _gameBoard;

        [SetUp]
        public void Setup()
        {
            _gameConfig = new GameConfig
            {
                BoardSize = 10,
                BattleshipCount = 1,
                DestroyerCount = 2,
                Debug = false
            };
            
            _input = new TestInputController(_gameConfig, "A5");
            _shipPlacementService = new RandomShipPlacementService(_gameConfig);
            _gameBoard = new GameBoard(_gameConfig, _shipPlacementService);
        }
        
        [Test]
        public void SetUpBoard_SubscribesToBoardEvents()
        {
            var game = new Game(_gameConfig, _input, _gameBoard);

            Assert.NotNull(_gameBoard.OnShipHit);
            Assert.NotNull(_gameBoard.OnHitMiss);
            Assert.NotNull(_gameBoard.OnShipSink);
        }
    }
}