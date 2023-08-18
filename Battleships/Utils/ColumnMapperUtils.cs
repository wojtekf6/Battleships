namespace Battleships.Utils
{
    public static class ColumnMapperUtils
    {
        private const int AsciiCodeA = 65;
        
        public static char GetColumnChar(this int columnIndex) => (char)(AsciiCodeA + columnIndex);
        public static int GetColumnIndex(this char value) => (int)char.ToUpper(value) - AsciiCodeA;
    }
}