using System;
using Battleships.Board;
using Battleships.Config;
using Battleships.Input;
using Battleships.Services;
using Microsoft.Extensions.Logging;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole();
            });
            
            var logger = loggerFactory.CreateLogger<Program>();
            
            try
            {
                var config = CreateGameConfig();
                var inputController = new ConsoleInputController(config, loggerFactory);
                var shipPlacementService = new RandomShipPlacementService(config);
                var board = new GameBoard(config, loggerFactory, shipPlacementService);
                
                var game = new Game(config, loggerFactory, inputController, board);

                game.Play();
            }
            catch (Exception e)
            {
                logger.LogError("Unexpected Exception occured: " + e.Message);
            }
        }

        static GameConfig CreateGameConfig()
        {
            //TODO: Read from .json file / AzureConfig
            return new GameConfig
            {
                BoardSize = 10,
                BattleshipCount = 1,
                DestroyerCount = 2,
                PlacementCollisionOffset = 1,
                Debug = true
            };
        }
    }
}