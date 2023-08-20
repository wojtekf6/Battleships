namespace Battleships.Exceptions.Board
{
    public sealed class InvalidFieldDataException : DomainException
    {
        public InvalidFieldDataException() : base("Invalid field data.")
        {
        }
    }
}