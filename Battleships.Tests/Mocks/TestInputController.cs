using Battleships.Config;
using Battleships.Input;
using Microsoft.Extensions.Logging;

namespace Battleships.Tests.Mocks
{
    public class TestInputController : ConsoleInputController
    {
        private string TestInput { get; }
        
        public TestInputController(GameConfig config, ILoggerFactory loggerFactory, string testInput) : base(config, loggerFactory)
        {
            TestInput = testInput;
        }
        
        public new InputData GetUserInput() => ParseUserInput(TestInput);
    }
}