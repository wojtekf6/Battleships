using System.Linq;
using Battleships.Board;
using Battleships.Config;
using Battleships.Exceptions.Board;
using Battleships.Exceptions.Ship;
using Battleships.Services;
using Battleships.Ships;
using NUnit.Framework;

namespace Battleships.Tests.BoardTests
{
    [TestFixture]
    public class GameBoardTest
    {
        private ShipPlacementService _shipPlacementService;
        private GameConfig _gameConfig;

        [SetUp]
        public void Setup()
        {
            _gameConfig = new GameConfig
            {
                BoardSize = 10,
                BattleshipCount = 1,
                DestroyerCount = 2,
                PlacementCollisionOffset = 1
            };
            _shipPlacementService = new RandomShipPlacementService(_gameConfig);
        }
        
        [Test]
        public void CreateBoard_CheckBoard()
        {
            var gameBoard = new GameBoard(_gameConfig, _shipPlacementService);

            Assert.NotNull(gameBoard.GetField(0, 0));
            Assert.NotNull(gameBoard.GetField(_gameConfig.BoardSize-1, _gameConfig.BoardSize-1));
        }
        
        [TestCase(-1)]
        [TestCase(0)]
        public void CreateBoard_InvalidSize(int size)
        {
            Assert.Throws<InvalidBoardSizeException>(delegate
            {
                var config = new GameConfig
                {
                    BoardSize = size,
                    BattleshipCount = 1,
                    DestroyerCount = 2
                };
                
                var gameBoard = new GameBoard(config, _shipPlacementService);
            });
        }
        
        [TestCase(-1, 2)]
        [TestCase(11, 10)]
        public void CreateBoard_InvalidFieldData(int row, int column)
        {
            Assert.Throws<InvalidFieldDataException>(delegate
            {
                var gameBoard = new GameBoard(_gameConfig, _shipPlacementService);
                gameBoard.GetField(row, column);
            });
        }
        
        [Test]
        public void CreateShips_EmptyData()
        {
            Assert.Throws<ShipsDataEmptyException>(delegate
            {
                var config = new GameConfig
                {
                    BoardSize = 10,
                    BattleshipCount = 0,
                    DestroyerCount = 0
                };
                
                var gameBoard = new GameBoard(config, _shipPlacementService);
                gameBoard.CreateShips();
            });
        }
        
        [Test]
        public void CreateShips_AddsShipsToBoard()
        {
            var gameBoard = new GameBoard(_gameConfig, _shipPlacementService);
            gameBoard.CreateShips();
            
            var battleships = gameBoard.Ships.Count(ship => ship is Battleship);
            var destroyers = gameBoard.Ships.Count(ship => ship is Destroyer);
            
            Assert.AreEqual(_gameConfig.BattleshipCount, battleships);
            Assert.AreEqual(_gameConfig.DestroyerCount, destroyers);
        }

        [Test]
        public void Hit_HitsShip()
        {
            var gameBoard = new GameBoard(_gameConfig, _shipPlacementService);
            gameBoard.CreateShips();
            var ship = gameBoard.Ships.First();
            var hitField = ship.OccupiedFields.First();
            
            gameBoard.Hit(hitField.Row, hitField.Column);
            
            Assert.IsFalse(ship.OccupiedFields.Contains(hitField));
        }
    }
}