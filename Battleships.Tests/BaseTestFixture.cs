using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Battleships.Tests
{
    public class BaseTestFixture
    {
        protected ILoggerFactory LoggerFactory;
        
        [SetUp]
        public virtual void Setup()
        {
            LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole();
            });
        }
    }
}