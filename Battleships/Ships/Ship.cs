using System.Collections.Generic;
using Battleships.Board;

namespace Battleships.Ships
{
    public abstract class Ship
    {
        public abstract int Size { get; protected init; }

        public readonly List<Field> OccupiedFields = new();
    }
}