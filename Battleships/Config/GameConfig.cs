namespace Battleships.Config
{
    public class GameConfig
    {
        // Should board size be configurable?
        public int BoardSize { get; set; } = 10;
        public int BattleshipCount { get; set; }
        public int DestroyerCount { get; set; }
        public int PlacementCollisionOffset { get; set; }
    }
}