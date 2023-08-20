namespace Battleships.Exceptions.Board
{
    public sealed class FieldAlreadyHasShipException : DomainException
    {
        public FieldAlreadyHasShipException() : base("Field already has ship.")
        {
            
        }
    }
}