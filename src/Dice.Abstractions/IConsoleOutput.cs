using System;

namespace Dice.Abstractions
{
    public interface IConsoleOutput
    {
        ConsoleColor BackgroundColor { get; set; }
        ConsoleColor ForegroundColor { get; set; }
        void Write(string text);
    }
}
