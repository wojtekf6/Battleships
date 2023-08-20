using System.Linq;
using Battleships.Config;
using Battleships.Ships;
using Battleships.Utils;
using NUnit.Framework;

namespace Battleships.Tests.UtilsTests
{
    [TestFixture]
    public class ShipDataMapperUtilsTest
    {
        [TestCase(2, 3)]
        [TestCase(4, 7)]
        public void GetShipsData_ReturnsCorrectNumberOfShips(int battleships, int destroyers)
        {
            var config = new GameConfig
            {
                BattleshipCount = battleships,
                DestroyerCount = destroyers
            };

            var result = ShipDataMapperUtils.GetShipsData(config);
            
            Assert.AreEqual(battleships + destroyers, result.Count);
            Assert.AreEqual(battleships, result.Count(ship => ship is Battleship));
            Assert.AreEqual(destroyers, result.Count(ship => ship is Destroyer));
        }
    }
}