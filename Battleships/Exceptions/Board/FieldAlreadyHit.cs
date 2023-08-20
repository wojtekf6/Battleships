namespace Battleships.Exceptions.Board
{
    public sealed class FieldAlreadyHit : DomainException
    {
        public FieldAlreadyHit() : base("Field already hit.")
        {
        }
    }
}