using Battleships.Utils;
using NUnit.Framework;

namespace Battleships.Tests.UtilsTests
{
    [TestFixture]
    public class InputUtilsTests
    {
        [TestCase(1, ExpectedResult = "^[A-A]\\d+$")]
        [TestCase(2, ExpectedResult = "^[A-B]\\d+$")]
        [TestCase(26, ExpectedResult = "^[A-Z]\\d+$")]
        public string GetInputPattern_ValidSize_ReturnsCorrectPattern(int size) => InputUtils.GetInputPattern(size);

        [TestCase("A1", 1, ExpectedResult = true)]
        [TestCase("B2", 2, ExpectedResult = true)]
        [TestCase("J10", 10, ExpectedResult = true)]
        [TestCase("C3", 2, ExpectedResult = false)]
        [TestCase("X", 2, ExpectedResult = false)]
        [TestCase("", 2, ExpectedResult = false)]
        public bool ValidateMaxSize_ValidInput_ReturnsExpectedResult(string input, int size) => InputUtils.ValidateMaxSize(input, size);
    }
}