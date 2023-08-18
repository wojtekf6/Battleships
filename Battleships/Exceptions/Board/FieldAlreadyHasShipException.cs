namespace Battleships.Exceptions.Board
{
    public class FieldAlreadyHasShipException : DomainException
    {
        public FieldAlreadyHasShipException() : base("Field already has ship.")
        {
            
        }
    }
}