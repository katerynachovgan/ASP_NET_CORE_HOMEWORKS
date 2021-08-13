using Microsoft.Extensions.Logging;
using System;

namespace Logger_Provider
{
    public class ColoredConsoleLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; }
        public int EventId { get; set; } 
        public ConsoleColor Color { get; set; }
    }
}
