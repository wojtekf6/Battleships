namespace Battleships.Exceptions.Board
{
    public class InvalidFieldDataException : DomainException
    {
        public InvalidFieldDataException() : base("Invalid field data.")
        {
        }
    }
}