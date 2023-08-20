namespace Battleships.Config
{
    public record GameConfig
    {
        // Should board size be configurable?
        public int BoardSize { get; set; } = 10;
        public int BattleshipCount { get; set; }
        public int DestroyerCount { get; set; }
        public int PlacementCollisionOffset { get; set; }
        public bool Debug { get; set; }
    }
}