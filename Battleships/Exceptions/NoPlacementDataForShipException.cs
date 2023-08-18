namespace Battleships.Exceptions
{
    public class NoPlacementDataForShipException : DomainException
    {
        public NoPlacementDataForShipException() : base("No place for ship on board. Check configuration.")
        {
        }
    }
}