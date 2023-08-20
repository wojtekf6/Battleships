using Battleships.Utils;
using NUnit.Framework;

namespace Battleships.Tests.UtilsTests
{
    [TestFixture]
    public class ColumnMapperUtilsTests
    {
        [TestCase(0, ExpectedResult = 'A')]
        [TestCase(1, ExpectedResult = 'B')]
        [TestCase(25, ExpectedResult = 'Z')]
        public char GetColumnChar_ShouldReturnCorrectChar(int columnIndex) => columnIndex.GetColumnChar();

        [TestCase('A', ExpectedResult = 0)]
        [TestCase('B', ExpectedResult = 1)]
        [TestCase('Z', ExpectedResult = 25)]
        [TestCase('a', ExpectedResult = 0)]
        public int GetColumnIndex_ShouldReturnCorrectIndex(char value) => value.GetColumnIndex();
    }
}