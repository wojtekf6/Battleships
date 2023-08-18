namespace Battleships.Exceptions
{
    public class ShipOccupiesMaxFieldsException : DomainException
    {
        public ShipOccupiesMaxFieldsException() : base("Can't add more fields to Ship.")
        {
        }
    }
}