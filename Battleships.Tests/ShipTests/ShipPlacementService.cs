using System.Collections.Generic;
using Battleships.Board;
using Battleships.Config;
using Battleships.Enums;
using Battleships.Ships;
using Battleships.Tests.Mocks;
using NUnit.Framework;

namespace Battleships.Tests.ShipTests
{
    [TestFixture]
    public class ShipPlacementServiceTests
    {
        [Test]
        public void CalculateAvailableFields_NoCollisions_ReturnsCorrectPositions()
        {
            var config = new GameConfig
            {
                BoardSize = 2
            };

            var shipPlacementService = new TestShipPlacementService(config);
            var gameBoard = new GameBoard(config, shipPlacementService);
            var ship = new TestShip(2);
            
            var expectedPositions = new List<PlacementData>
            {
                new() { StartField = new Field(0, 0), Orientation = Orientation.Vertical},
                new() { StartField = new Field(0, 0), Orientation = Orientation.Horizontal},
                new() { StartField = new Field(1, 0), Orientation = Orientation.Horizontal},
                new() { StartField = new Field(0, 1), Orientation = Orientation.Vertical}
            };
           
            var positions = shipPlacementService.CalculateAvailableFieldsForTest(gameBoard, ship);

            CollectionAssert.AreEqual(expectedPositions, positions);
        }
        
        [TestCase(0, ExpectedResult = 3)]
        [TestCase(1, ExpectedResult = 2)]
        public int CalculateAvailableFields_Collisions_ReturnsCorrectPositions(int placementOffset)
        {
            var config = new GameConfig
            {
                BoardSize = 4,
                DestroyerCount = 1,
                PlacementCollisionOffset = placementOffset
            };

            // Mocked service return [0] placement (0,0,vertical)
            // S o o o 
            // S o o o 
            // S o o o
            // S o o o
            
            var shipPlacementService = new TestShipPlacementService(config);
            var gameBoard = new GameBoard(config, shipPlacementService);
            gameBoard.CreateShips();

            var ship = new Destroyer();

            var positionsWithCollisions = shipPlacementService.CalculateAvailableFieldsForTest(gameBoard, ship);
            
            return positionsWithCollisions.Count;
        }

        [Test]
        public void GetShipPlacementData_ReturnsCorrectPositions()
        {
            var config = new GameConfig
            {
                BoardSize = 2
            };

            PlacementData expectedPlacementData = new()
                { StartField = new Field(0, 0), Orientation = Orientation.Vertical };
            
            var shipPlacementService = new TestShipPlacementService(config);
            var gameBoard = new GameBoard(config, shipPlacementService);
            var ship = new TestShip(2);
            
            var placementData = shipPlacementService.GetShipPlacementData(gameBoard, ship);
            
            Assert.AreEqual(expectedPlacementData.StartField.Column, placementData.StartField.Column);
            Assert.AreEqual(expectedPlacementData.StartField.Row, placementData.StartField.Row);
            Assert.AreEqual(expectedPlacementData.Orientation, placementData.Orientation);
        }
    }
}