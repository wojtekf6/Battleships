using Battleships.Ships;

namespace Battleships.Tests.Mocks
{
    public class TestShip : Ship
    {
        public bool DestroyInvoked { get; private set; }
        public override int Size { get; }

        public TestShip(int size)
        {
            Size = size;
        }

        protected override void Destroy()
        {
            DestroyInvoked = true;
        }
    }
}