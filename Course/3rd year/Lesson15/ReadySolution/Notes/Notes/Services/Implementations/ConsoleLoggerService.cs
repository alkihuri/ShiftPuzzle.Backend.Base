using Notes.Services.Interfaces;

namespace Notes.Services.Implementations;

public class ConsoleLoggerService : ILoggerService
{
    public void Log(string message) => Console.WriteLine($"Log: {message}");
}