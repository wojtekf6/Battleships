namespace Battleships.Exceptions.Board
{
    public sealed class InvalidBoardSizeException : DomainException
    {
        public InvalidBoardSizeException() : base("Invalid board size.")
        {
        }
    }
}