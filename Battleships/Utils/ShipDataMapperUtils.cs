using System.Collections.Generic;
using Battleships.Config;
using Battleships.Ships;

namespace Battleships.Utils
{
    public static class ShipDataMapperUtils
    {
        public static List<Ship> GetShipsData(GameConfig config)
        {
            var ships = new List<Ship>();

            for (var i = 0; i < config.BattleshipCount; i++)
            {
                ships.Add(new Battleship());
            }
            
            for (var i = 0; i < config.DestroyerCount; i++)
            {
                ships.Add(new Destroyer());
            }

            return ships;
        }
    }
}