using System;
using System.Linq;
using Battleships.Board;
using Battleships.Config;
using Battleships.Input;
using Microsoft.Extensions.Logging;

namespace Battleships
{
    public class Game
    {
        public bool IsGameInProgress;
        
        private readonly IInputController _input;
        private readonly GameConfig _config;
        private readonly ILogger _logger;
        
        private GameBoard _board;
        private int _hitCounter = 0;

        public Game(GameConfig config, ILoggerFactory loggerFactory, IInputController input, GameBoard board)
        {
            _config = config;
            _logger = loggerFactory.CreateLogger<Game>();
            _input = input;
            _board = board;
            
            _logger.LogInformation("Creating Game...");
            
            SetUpBoard();
        }

        public void Play()
        {
            Console.WriteLine("Start game!");
            Console.WriteLine("Instruction:");
            Console.WriteLine("Input data in proper format to Hit ship e.g. 'A5'");
            Console.WriteLine("o - field not hit");
            Console.WriteLine("S - ship hit");
            Console.WriteLine("x - hit miss");
            
            if (_config.Debug)
                Console.WriteLine("ONLY FOR DEBUG MODE: s - ship on field");
            
            _board.PrintBoard();
            
            IsGameInProgress = true;
            
            while (IsGameInProgress)
            {
                var inputData = _input.GetUserInput();

                if (inputData == null)
                    continue;

                _hitCounter++;
                _board.Hit(inputData.Row, inputData.Column);

                if (_config.Debug)
                {
                    _logger.LogInformation($"Hit: {inputData.Column}{inputData.Row}");
                }
                
                _board.PrintBoard();
            }
        }
        
        private void SetUpBoard()
        {
            _board.CreateShips();
            
            _board.OnShipHit += OnShipHit;
            _board.OnHitMiss += OnHitMiss;
            _board.OnShipSink += OnShipSink;
        }
        
        private void OnShipHit()
        {
            _logger.LogInformation("HIT!");
        }
        
        private void OnHitMiss()
        {
            _logger.LogInformation("Miss...");
        }
        
        private void OnShipSink()
        {
            _logger.LogInformation("...and SINK!");
            CheckGameState();
        }
        
        private void CheckGameState()
        {
            if (!_board.Ships.Any()) 
                OnGameEnd();
        }

        private void OnGameEnd()
        {
            _board.OnShipHit += OnShipHit;
            _board.OnHitMiss += OnHitMiss;
            _board.OnShipSink += OnShipSink;
            
            _logger.LogInformation("END GAME");
            _logger.LogInformation("Hits: " + _hitCounter);
            IsGameInProgress = false;
        }
    }
}