using System;
using System.Linq;
using Battleships.Board;
using Battleships.Config;
using Battleships.Exceptions.Ship;
using Battleships.Ships;

namespace Battleships.Services
{
    public class RandomShipPlacementService : ShipPlacementService
    {
        public RandomShipPlacementService(GameConfig config) : base(config)
        {
        }
        
        public override PlacementData GetShipPlacementData(GameBoard board, Ship ship)
        {
            var results = CalculateAvailableFields(board, ship);

            // throw exception and break game. We don't want to create game without ship that user requested.
            if (!results.Any())
                throw new NoPlacementDataForShipException();
            
            var rnd = new Random();
            var resultIndex = rnd.Next(results.Count);
            var startField = results[resultIndex];

            return startField;
        }
    }
}