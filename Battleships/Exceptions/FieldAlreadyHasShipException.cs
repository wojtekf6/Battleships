namespace Battleships.Exceptions
{
    public class FieldAlreadyHasShipException : DomainException
    {
        public FieldAlreadyHasShipException() : base("Field already has ship.")
        {
            
        }
    }
}