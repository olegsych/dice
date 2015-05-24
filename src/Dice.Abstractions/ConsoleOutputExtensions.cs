using System;

namespace Dice.Abstractions
{
    public static class ConsoleOutputExtensions
    {
        public static void Write(this IConsoleOutput consoleOutput, ConsoleColor foregroundColor, string text)
        {
            if (consoleOutput == null)
            {
                throw new ArgumentNullException(nameof(consoleOutput));
            }

            ConsoleColor originalColor = consoleOutput.ForegroundColor;
            consoleOutput.ForegroundColor = foregroundColor;

            consoleOutput.Write(text);

            consoleOutput.ForegroundColor = originalColor;
        }
    }
}
