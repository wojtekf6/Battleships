using System.Collections.Generic;
using System.Linq;
using Battleships.Board;
using Battleships.Config;
using Battleships.Enums;
using Battleships.Ships;

namespace Battleships.Services
{
    public abstract class ShipPlacementService
    {
        private readonly GameConfig _config;
        private readonly int _collisionOffset;

        protected ShipPlacementService(GameConfig config)
        {
            _config = config;
            _collisionOffset = config.PlacementCollisionOffset;
        }
        
        public abstract PlacementData GetShipPlacementData(GameBoard board, Ship ship);
        
        protected List<PlacementData> CalculateAvailableFields(GameBoard gameBoard, Ship ship)
        {
            var positions = new List<PlacementData>();

            for (var column = 0; column < gameBoard.Size; column++)
            {
                for (var row = 0; row < gameBoard.Size; row++)
                {
                    if (row + ship.Size <= gameBoard.Size && !CollidesWithShips(row, column, ship.Size, Orientation.Vertical, gameBoard.Ships))
                    {
                        positions.Add(new PlacementData { StartField = new Field(row, column), Orientation = Orientation.Vertical });
                    }
                    
                    if (column + ship.Size <= gameBoard.Size && !CollidesWithShips(row, column, ship.Size, Orientation.Horizontal, gameBoard.Ships))
                    {
                        positions.Add(new PlacementData { StartField = new Field(row, column), Orientation = Orientation.Horizontal });
                    }
                }
            }

            return positions;
        }
        
        private bool CollidesWithShips(int row, int column, int shipSize, Orientation orientation, List<Ship> placedShips)
        {
            foreach (var ship in placedShips)
            {
                if (orientation == Orientation.Vertical)
                {
                    if (ship.OccupiedFields.Any(of => 
                            (of.Column == column || of.Column + _collisionOffset == column || of.Column - _collisionOffset == column)
                            && (of.Row >= row - _collisionOffset && of.Row <= row + shipSize + _collisionOffset)))
                    {
                        return true;
                    }
                }
                else
                {
                    if (ship.OccupiedFields.Any(of => 
                            (of.Row == row || of.Row + _collisionOffset == row || of.Row - _collisionOffset == row)
                            && (of.Column >= column - _collisionOffset && of.Column <= column + shipSize + _collisionOffset)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}