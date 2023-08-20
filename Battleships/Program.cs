using System;
using System.Threading.Tasks;
using Battleships.Board;
using Battleships.Input;
using Battleships.Services;
using Battleships.Utils;
using Microsoft.Extensions.Logging;

namespace Battleships
{
    class Program
    {
        private const string ConfigFileName = "config.json";
        
        static async Task Main(string[] args)
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
                var config = await ConfigUtils.LoadConfig(ConfigFileName);
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
    }
}