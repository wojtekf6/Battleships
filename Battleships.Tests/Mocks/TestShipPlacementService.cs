using System.Collections.Generic;
using System.Linq;
using Battleships.Board;
using Battleships.Config;
using Battleships.Services;
using Battleships.Ships;

namespace Battleships.Tests.Mocks
{
    public class TestShipPlacementService : ShipPlacementService
    {
        public TestShipPlacementService(GameConfig config) : base(config)
        {
        }
        
        public List<PlacementData> CalculateAvailableFieldsForTest(GameBoard gameBoard, Ship ship)
        {
            return CalculateAvailableFields(gameBoard, ship);
        }

        public override PlacementData GetShipPlacementData(GameBoard gameBoard, Ship ship)
        {
            return CalculateAvailableFields(gameBoard, ship).First();
        }
    }
}