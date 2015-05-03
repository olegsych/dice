using System;
using System.Linq;
using Xunit;

namespace Dice.Abstractions
{
    public class ProgramDescriptorTest
    {
        [Fact]
        public void ConstructorInvokesBaseWithAllParameters()
        {
            const string expectedName = "Test Name";
            const string expectedSummary = "Test Summary";

            var descriptor = new ProgramDescriptor(expectedName, expectedSummary, Enumerable.Empty<CommandDescriptor>());

            Assert.Equal(expectedName, descriptor.Name);
            Assert.Equal(expectedSummary, descriptor.Summary);
        }

        [Fact]
        public void ConstructorEnsuresCommandsArgumentIsSpecified()
        {
            var e = Assert.Throws<ArgumentNullException>(() => new ProgramDescriptor("any", "any", null));
            Assert.Equal("commands", e.ParamName);
        }

        [Fact]
        public void ConstructorEnsuresCommandInstancesAreNotNull()
        {
            var e = Assert.Throws<ArgumentException>(() => new ProgramDescriptor("any", "any", new CommandDescriptor[] { null }));
            Assert.Equal("commands", e.ParamName);
            Assert.Contains("null", e.Message);
        }

        [Fact]
        public void ConstructorInitializesCommandsPropertyWithGivenValue()
        {
            var commands = new CommandDescriptor[0];
            var descriptor = new ProgramDescriptor("any", "any", commands);
            Assert.Same(commands, descriptor.Commands);
        }
    }
}
