namespace Battleships.Exceptions.Ship
{
    public class ShipsDataEmptyException : DomainException
    {
        public ShipsDataEmptyException() : base("Ships data empty.")
        {
        }
    }
}