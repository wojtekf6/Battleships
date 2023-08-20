namespace Battleships.Exceptions.Ship
{
    public sealed class NoPlacementDataForShipException : DomainException
    {
        public NoPlacementDataForShipException() : base("No place for ship on board. Check configuration.")
        {
        }
    }
}