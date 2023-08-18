namespace Battleships.Exceptions
{
    public class ShipsDataEmptyException : DomainException
    {
        public ShipsDataEmptyException() : base("Ships data empty.")
        {
        }
    }
}