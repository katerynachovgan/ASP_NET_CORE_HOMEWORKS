using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Logger_Provider
{
    public class MyLoggerProvider : ILoggerProvider
    {
        private readonly ColoredConsoleLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, MyLogger> _loggers = new ConcurrentDictionary<string, MyLogger>();

        public MyLoggerProvider(ColoredConsoleLoggerConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new MyLogger(name, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
