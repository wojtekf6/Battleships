using Battleships.Board;
using Battleships.Config;
using Battleships.Input;
using Battleships.Services;
using Battleships.Tests.Mocks;
using NUnit.Framework;

namespace Battleships.Tests
{
    [TestFixture]
    public class GameTest : BaseTestFixture
    {
        private IInputController _input;
        private GameConfig _gameConfig;
        private ShipPlacementService _shipPlacementService;
        private GameBoard _gameBoard;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _gameConfig = new GameConfig
            {
                BoardSize = 10,
                BattleshipCount = 1,
                DestroyerCount = 2,
                Debug = false
            };

            _input = new TestInputController(_gameConfig, LoggerFactory, "A5");
            _shipPlacementService = new RandomShipPlacementService(_gameConfig);
            _gameBoard = new GameBoard(_gameConfig, LoggerFactory, _shipPlacementService);
        }
        
        [Test]
        public void SetUpBoard_SubscribesToBoardEvents()
        {
            var game = new Game(_gameConfig, LoggerFactory, _input, _gameBoard);

            Assert.NotNull(_gameBoard.OnShipHit);
            Assert.NotNull(_gameBoard.OnHitMiss);
            Assert.NotNull(_gameBoard.OnShipSink);
        }
    }
}