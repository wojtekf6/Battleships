using System;
using Battleships.Board;
using Battleships.Config;
using Battleships.Services;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var config = new GameConfig
                {
                    BoardSize = 10,
                    BattleshipCount = 1,
                    DestroyerCount = 2,
                    PlacementCollisionOffset = 1
                };

                var shipPlacementService = new RandomShipPlacementService(config);
                var board = new GameBoard(config, shipPlacementService);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected Exception occured: " + e.Message);
            }
            
        }
    }
}