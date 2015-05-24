using System;
using NSubstitute;
using Xunit;

namespace Dice.Abstractions
{
    public class ConsoleOutputExtensionsTest
    {
        public class WriteForegroundColorText
        {
            [Fact]
            public void CallsWriteWithGivenText()
            {
                var consoleOutput = Substitute.For<IConsoleOutput>();
                consoleOutput.Write(default(ConsoleColor), "test");
                consoleOutput.Received().Write("test");
            }

            [Fact]
            public void SetsForegroundColorOfConsoleOutput()
            {
                var consoleOutput = Substitute.For<IConsoleOutput>();
                consoleOutput.Write(ConsoleColor.Cyan, string.Empty);
                consoleOutput.Received().ForegroundColor = ConsoleColor.Cyan;
            }

            [Fact]
            public void RestoresForegroundColorOfConsoleOutputToOriginalValue()
            {
                var consoleOutput = Substitute.For<IConsoleOutput>();
                consoleOutput.ForegroundColor.Returns(ConsoleColor.Gray);
                consoleOutput.Write(ConsoleColor.Cyan, string.Empty);
                consoleOutput.Received().ForegroundColor = ConsoleColor.Gray;
            }

            [Fact]
            public void ThrowsArgumentNullExceptionWhenConsoleOutputIsNull()
            {
                var exception = Assert.Throws<ArgumentNullException>(() => ConsoleOutputExtensions.Write(null, default(ConsoleColor), string.Empty));
                Assert.Equal("consoleOutput", exception.ParamName);
            }
        }
    }
}
