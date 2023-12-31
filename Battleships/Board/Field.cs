using Battleships.Exceptions.Board;
using Battleships.Ships;

namespace Battleships.Board
{
    public class Field
    {
        public int Row { get; }
        public int Column { get; }
        public Ship ShipOnField { get; private set; }
        public bool IsHit { get; private set; }

        public Field(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void PlaceShip(Ship ship)
        {
            if (ShipOnField != null)
                throw new FieldAlreadyHasShipException();
            
            ShipOnField = ship;
        }

        public void Hit()
        {
            if (IsHit)
                throw new FieldAlreadyHit();
            
            IsHit = true;
            ShipOnField?.Hit(this);
        }
    }
}