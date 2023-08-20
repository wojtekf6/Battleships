using Battleships.Config;
using Battleships.Input;

namespace Battleships.Tests.Mocks
{
    public class TestInputController : ConsoleInputController
    {
        private string TestInput { get; }
        
        public TestInputController(GameConfig config, string testInput) : base(config)
        {
            TestInput = testInput;
        }
        
        public new InputData GetUserInput() => ParseUserInput(TestInput);
    }
}