namespace Battleships.Exceptions.Ship
{
    public class ShipOccupiesMaxFieldsException : DomainException
    {
        public ShipOccupiesMaxFieldsException() : base("Can't add more fields to Ship.")
        {
        }
    }
}