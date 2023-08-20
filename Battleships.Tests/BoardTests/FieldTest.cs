using Battleships.Board;
using Battleships.Exceptions.Board;
using Battleships.Tests.Mocks;
using NUnit.Framework;

namespace Battleships.Tests.BoardTests
{
    [TestFixture]
    public class FieldTest
    {
        [TestCase(2, 3)]
        public void PlaceShip_ShouldSetShipOnField(int row, int column)
        {
            var ship = new TestShip(3);
            var field = new Field(row, column);
            
            field.PlaceShip(ship);
            
            Assert.AreEqual(ship, field.ShipOnField);
        }

        [TestCase(2, 3)]
        public void ShipOnField_ShouldBeNullInitially(int row, int column)
        {
            var field = new Field(row, column);
            
            Assert.IsNull(field.ShipOnField);
        }
        
        [TestCase(2, 3)]
        public void HitField_EmptyField(int row, int column)
        {
            var field = new Field(row, column);
            field.Hit();
            
            Assert.IsTrue(field.IsHit);
        }
        
        [TestCase(2, 3)]
        public void HitField_FieldWithShip(int row, int column)
        {
            var field = new Field(row, column);
            var ship = new TestShip(1);
            
            field.PlaceShip(ship);
            field.Hit();
            
            Assert.IsTrue(field.IsHit);
            Assert.IsTrue(ship.DestroyInvoked);
        }
        
        [TestCase(2, 3)]
        public void HitField_ShouldFailIfAlreadyHit(int row, int column)
        {
            Assert.Throws<FieldAlreadyHit>(delegate
            {
                var field = new Field(2, 3);
                field.Hit();
                field.Hit();
            });
        }
        
        [TestCase(2, 3)]
        public void ShipOnField_ShouldFailIfFieldHasShip(int row, int column)
        {
            Assert.Throws<FieldAlreadyHasShipException>(delegate
            {
                var ship = new TestShip(3);
                var field = new Field(2, 3);
                
                field.PlaceShip(ship);
                field.PlaceShip(ship);
            });
        }
    }
}