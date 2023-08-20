using Battleships.Config;
using Battleships.Exceptions.Input;
using Battleships.Tests.Mocks;
using NUnit.Framework;

namespace Battleships.Tests.InputTests
{
    [TestFixture]
    public class InputControllerTest : BaseTestFixture
    {
        private GameConfig _config;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _config = new GameConfig
            {
                BoardSize = 10
            };
        }
        
        [TestCase("A5", 4, 0)]
        [TestCase("a5", 4, 0)]
        [TestCase("c7", 6, 2)]
        [TestCase("j10", 9, 9)]
        [TestCase("d2", 1, 3)]
        public void GetUserInput_ProperData(string input, int exRow, int exColumn)
        {
            var inputController = new TestInputController(_config, LoggerFactory, input);

            var result = inputController.GetUserInput();

            Assert.AreEqual(exColumn, result.Column);
            Assert.AreEqual(exRow, result.Row);
        }
        
        [TestCase("A11")]
        [TestCase("Z1")]
        [TestCase("X0")]
        [TestCase(" ")]
        [TestCase("")]
        public void GetUserInput_InvalidData(string input)
        {
            Assert.Throws<InvalidInputException>(delegate
            {
                var inputController = new TestInputController(_config, LoggerFactory, input);
                inputController.GetUserInput();
            });
        }
    }
}