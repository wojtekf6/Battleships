using System.Collections.Generic;
using Battleships.Config;
using Battleships.Ships;

namespace Battleships.Board
{
    public class GameBoard
    {
        public readonly int Size;
        
        public readonly List<Ship> Ships = new ();
        public readonly List<Field> Fields = new ();
        
        private readonly GameConfig _config;

        public GameBoard(GameConfig config)
        {
            _config = config;
            Size = _config.BoardSize;
            InitializeBoard();
        }
        
        // One param size instead of row and columns as we don't plan to play on not square board
        private void InitializeBoard()
        {
            for (var row = 0; row < Size; row++)
            {
                for (var column = 0; column < Size; column++)
                {
                    Fields.Add(new Field(row, column));
                }
            }
        }
    }
}