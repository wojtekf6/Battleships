using System;
using Battleships.Board;
using Battleships.Config;
using Battleships.Input;
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
                    PlacementCollisionOffset = 1,
                    Debug = true
                };

                var shipPlacementService = new RandomShipPlacementService(config);
                var board = new GameBoard(config, shipPlacementService);

                IInputController inputController = new ConsoleInputController(config);
                var inputData = inputController.GetUserInput();
                
                if (config.Debug)
                {
                    Console.WriteLine($"Hit: {inputData.Column}{inputData.Row}");
                    board.PrintBoard();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected Exception occured: " + e.Message);
            }
            
        }
    }
}