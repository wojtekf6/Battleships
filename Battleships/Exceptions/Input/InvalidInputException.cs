namespace Battleships.Exceptions.Input
{
    public class InvalidInputException : DomainException
    {
        public InvalidInputException() : base("Invalid input!")
        {
        }
    }
}