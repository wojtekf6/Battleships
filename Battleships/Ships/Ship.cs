using System.Collections.Generic;
using Battleships.Board;
using Battleships.Exceptions.Ship;

namespace Battleships.Ships
{
    public abstract class Ship
    {
        public abstract int Size { get; }

        public readonly List<Field> OccupiedFields = new();
        
        public void AddOccupiedField(Field field)
        {
            if (OccupiedFields.Count == Size)
                throw new ShipOccupiesMaxFieldsException();
                
            OccupiedFields.Add(field);
        }
    }
}