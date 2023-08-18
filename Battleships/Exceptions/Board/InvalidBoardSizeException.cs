namespace Battleships.Exceptions.Board
{
    public class InvalidBoardSizeException : DomainException
    {
        public InvalidBoardSizeException() : base("Invalid board size.")
        {
        }
    }
}