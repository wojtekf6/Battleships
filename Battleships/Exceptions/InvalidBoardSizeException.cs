namespace Battleships.Exceptions
{
    public class InvalidBoardSizeException : DomainException
    {
        public InvalidBoardSizeException() : base("Invalid board size.")
        {
        }
    }
}