using System;
using System.Collections.Generic;
using Battleships.Board;
using Battleships.Exceptions.Ship;

namespace Battleships.Ships
{
    public abstract class Ship
    {
        public Action<Ship> OnDestroy;
        
        public abstract int Size { get; }

        public readonly List<Field> OccupiedFields = new();
        
        public void AddOccupiedField(Field field)
        {
            if (OccupiedFields.Count == Size)
                throw new ShipOccupiesMaxFieldsException();
                
            OccupiedFields.Add(field);
        }
        
        public void Hit(Field field)
        {
            OccupiedFields.Remove(field);

            if (OccupiedFields.Count == 0)
                Destroy();
        }
        
        protected virtual void Destroy()
        {
            OnDestroy?.Invoke(this);
        }
    }
}