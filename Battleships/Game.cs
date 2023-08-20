using System;
using System.Linq;
using Battleships.Board;
using Battleships.Config;
using Battleships.Input;

namespace Battleships
{
    public class Game
    {
        public bool IsGameInProgress;
        
        private readonly IInputController _input;
        private readonly GameConfig _config;
        
        private GameBoard _board;

        public Game(GameConfig config, IInputController input, GameBoard board)
        {
            Console.WriteLine("Creating Game...");
            _config = config;
            _input = input;
            _board = board;
            
            SetUpBoard();
        }

        public void Play()
        {
            Console.WriteLine("Start game!");
            
            if (_config.Debug)
                _board.PrintBoard();
            
            IsGameInProgress = true;
            
            while (IsGameInProgress)
            {
                var inputData = _input.GetUserInput();

                if (inputData == null)
                    continue;
                
                _board.Hit(inputData.Row, inputData.Column);

                if (_config.Debug)
                {
                    Console.WriteLine($"Hit: {inputData.Column}{inputData.Row}");
                    _board.PrintBoard();
                }
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
            Console.WriteLine("HIT!");
        }
        
        private void OnHitMiss()
        {
            Console.WriteLine("Miss...");
        }
        
        private void OnShipSink()
        {
            Console.WriteLine("...and SINK!");
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
            
            Console.WriteLine("END GAME");
            IsGameInProgress = false;
        }

    }
}