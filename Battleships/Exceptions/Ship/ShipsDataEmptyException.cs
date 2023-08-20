namespace Battleships.Exceptions.Ship
{
    public sealed class ShipsDataEmptyException : DomainException
    {
        public ShipsDataEmptyException() : base("Ships data empty.")
        {
        }
    }
}