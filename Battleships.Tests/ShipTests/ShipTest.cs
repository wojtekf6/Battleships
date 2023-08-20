using Battleships.Board;
using Battleships.Exceptions.Ship;
using Battleships.Tests.Mocks;
using NUnit.Framework;

namespace Battleships.Tests.ShipTests
{
    [TestFixture]
    public class ShipTest
    {
        [Test]
        public void Hit_RemovesOccupiedField_DestroyInvoked()
        {
            var ship = new TestShip(1);
            var field = new Field(0, 0);
            ship.AddOccupiedField(field);
            
            ship.Hit(field);
            
            Assert.IsEmpty(ship.OccupiedFields);
            Assert.IsTrue(ship.DestroyInvoked);
        }

        [Test]
        public void Hit_LastOccupiedField_DestroyInvoked()
        {
            var ship = new TestShip(1);
            var field = new Field(0, 0);
            ship.AddOccupiedField(field);
            
            ship.Hit(field);
            
            Assert.IsTrue(ship.DestroyInvoked);
        }

        [Test]
        public void Hit_NonEmptyOccupiedFields_DestroyNotInvoked()
        {
            var ship = new TestShip(2);
            var field1 = new Field(0, 0);
            var field2 = new Field(0, 1);
            ship.AddOccupiedField(field1);
            ship.AddOccupiedField(field2);
            
            ship.Hit(field1);
            
            Assert.AreEqual(1, ship.OccupiedFields.Count);
            Assert.IsFalse(ship.DestroyInvoked);
        }
        
        [Test]
        public void AddOccupiedField_AddsField()
        {
            var ship = new TestShip(1);
            var field = new Field(0, 0);
            
            ship.AddOccupiedField(field);
            
            Assert.AreEqual(1, ship.OccupiedFields.Count);
        }
        
        [TestCase(2, 3)]
        public void AddOccupiedField_AddMoreFieldsFail(int row, int column)
        {
            Assert.Throws<ShipOccupiesMaxFieldsException>(delegate
            {
                var ship = new TestShip(1);
                var field = new Field(0, 0);
                var field2 = new Field(0, 1);
                
                ship.AddOccupiedField(field);
                ship.AddOccupiedField(field2);
            });
        }
    }
}