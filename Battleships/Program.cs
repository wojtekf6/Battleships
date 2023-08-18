using Battleships.Board;
using Battleships.Config;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new GameConfig
            {
                BoardSize = 10
            };

            var board = new GameBoard(config);
        }
    }
}