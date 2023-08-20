namespace Battleships.Exceptions.Input
{
    public sealed class InvalidInputException : DomainException
    {
        public InvalidInputException() : base("Invalid input!")
        {
        }
    }
}