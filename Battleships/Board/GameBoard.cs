using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Config;
using Battleships.Enums;
using Battleships.Exceptions.Board;
using Battleships.Exceptions.Ship;
using Battleships.Services;
using Battleships.Ships;
using Battleships.Utils;

namespace Battleships.Board
{
    public class GameBoard
    {
        public Action OnShipHit;
        public Action OnHitMiss;
        public Action OnShipSink;
        
        public readonly int Size;
        public readonly List<Ship> Ships = new ();

        private readonly List<Field> _fields = new ();
        private readonly GameConfig _config;
        private readonly ShipPlacementService _shipPlacementService;

        public GameBoard(GameConfig config, ShipPlacementService shipPlacementService)
        {
            _config = config;
            _shipPlacementService = shipPlacementService;
            
            Size = _config.BoardSize;
            InitializeBoard();
        }
        
        public void Hit(int row, int column)
        {
            try
            {
                var hitField = GetField(row, column);

                if (hitField.IsHit)
                    throw new FieldAlreadyHit();

                if (hitField.ShipOnField != null)
                {
                    OnShipHit?.Invoke();
                }
                else
                {
                    OnHitMiss?.Invoke();
                }
                
                hitField.Hit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public Field GetField(int row, int column)
        {
            var field = _fields.FirstOrDefault(f => f.Row == row && f.Column == column);
            
            if (field == null)
                throw new InvalidFieldDataException();

            return field;
        }
        
        public void PrintBoard()
        {
            var headLine = "    ";
            for (var column = 0; column < Size; column++)
            {
                headLine += column.GetColumnChar() + " ";
            }
            
            Console.WriteLine(headLine);
            
            for (var row = 0; row < Size; row++)
            {
                var lineToPrint = (row + 1) + (row < 9 ? "   " : "  ");
            
                foreach (var field in _fields.Where(f => f.Row == row).OrderBy(f => f.Column))
                {
                    var toPrint = !field.IsHit ? "o " : field.ShipOnField != null ? "S " : "x ";
                    
                    // Display ship as "s" in debug mode if not Hit 
                    if (_config.Debug && !field.IsHit && field.ShipOnField != null)
                        toPrint = "s ";
                    
                    lineToPrint += toPrint;
                }
            
                Console.WriteLine(lineToPrint);
            }
        }
        
        public void CreateShips()
        {
            var ships = ShipDataMapperUtils.GetShipsData(_config);

            if (!ships.Any())
                throw new ShipsDataEmptyException();

            foreach (var ship in ships)
            {
                var placementData = _shipPlacementService.GetShipPlacementData(this, ship);
                PlaceShip(placementData.StartField.Row, placementData.StartField.Column, ship, placementData.Orientation);
            }
        }
        
        private void PlaceShip(int startRow, int startColumn, Ship ship, Orientation orientation)
        {
            for (var i = 0; i < ship.Size; i++)
            {
                var fieldToPlaceShip = orientation == Orientation.Horizontal
                    ? GetField(startRow, startColumn + i)
                    : GetField(startRow + i, startColumn);
                
                ship.AddOccupiedField(fieldToPlaceShip);
                fieldToPlaceShip.PlaceShip(ship);
            }
            
            ship.OnDestroy += ShipDestroyed;
            Ships.Add(ship);
        }
        
        private void ShipDestroyed(Ship ship)
        {
            ship.OnDestroy -= ShipDestroyed;
            Ships.Remove(ship);
            
            OnShipSink?.Invoke();
        }
        
        // One param size instead of row and columns as we don't plan to play on not square board
        private void InitializeBoard()
        {
            if (Size < 1)
                throw new InvalidBoardSizeException();
            
            for (var row = 0; row < Size; row++)
            {
                for (var column = 0; column < Size; column++)
                {
                    _fields.Add(new Field(row, column));
                }
            }
        }
    }
}