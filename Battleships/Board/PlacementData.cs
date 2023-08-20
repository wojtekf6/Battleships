using System;
using Battleships.Enums;

namespace Battleships.Board
{
    public class PlacementData : IEquatable<PlacementData>
    {
        public Field StartField { get; init; }
        public Orientation Orientation { get; init; }

        public bool Equals(PlacementData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return StartField.Row == other.StartField.Row && StartField.Column == other.StartField.Column &&
                   StartField.ShipOnField == other.StartField.ShipOnField && Orientation == other.Orientation;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartField, (int)Orientation);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PlacementData);
        }
    }
}