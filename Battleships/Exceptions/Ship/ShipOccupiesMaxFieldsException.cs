namespace Battleships.Exceptions.Ship
{
    public sealed class ShipOccupiesMaxFieldsException : DomainException
    {
        public ShipOccupiesMaxFieldsException() : base("Can't add more fields to Ship.")
        {
        }
    }
}