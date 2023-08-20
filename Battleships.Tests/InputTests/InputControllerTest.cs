using Battleships.Config;
using Battleships.Exceptions.Input;
using Battleships.Input;
using Battleships.Tests.Mocks;
using NUnit.Framework;

namespace Battleships.Tests.InputTests
{
    [TestFixture]
    public class InputControllerTest
    {
        private GameConfig _config;

        [SetUp]
        public void Setup()
        {
            _config = new GameConfig
            {
                BoardSize = 10
            };
        }
        
        [Test]
        public void GetUserInput_ProperData()
        {
            var inputController = new TestInputController(_config, "A5");

            var result = inputController.GetUserInput();

            Assert.AreEqual(0, result.Column);
            Assert.AreEqual(4, result.Row);
        }
        
        [TestCase("A11")]
        [TestCase("Z1")]
        [TestCase("X0")]
        [TestCase("")]
        public void GetUserInput_InvalidData(string input)
        {
            Assert.Throws<InvalidInputException>(delegate
            {
                var inputController = new TestInputController(_config, input);
                inputController.GetUserInput();
            });
        }
    }
}