using System;
using System.Linq;
using Xunit;

namespace Dice.Abstractions
{
    public class CommandDescriptorTest
    {
        [Fact]
        public void ConstructorInvokesBaseWithAllParameters()
        {
            const string expectedName = "Test Name";
            const string expectedSummary = "Test Summary";

            var descriptor = new CommandDescriptor(expectedName, expectedSummary, Enumerable.Empty<OptionDescriptor>());

            Assert.Equal(expectedName, descriptor.Name);
            Assert.Equal(expectedSummary, descriptor.Summary);
        }

        [Fact]
        public void ConstructorEnsuresOptionsArgumentIsSpecified()
        {
            var e = Assert.Throws<ArgumentNullException>(() => new CommandDescriptor("any", "any", null));
            Assert.Equal("options", e.ParamName);
        }

        [Fact]
        public void ConstructorEnsuresOptionsInstancesAreNotNull()
        {
            var e = Assert.Throws<ArgumentException>(() => new CommandDescriptor("any", "any", new OptionDescriptor[] { null }));
            Assert.Equal("options", e.ParamName);
            Assert.Contains("null", e.Message);
        }

        [Fact]
        public void ConstructorInitializesOptionsPropertyWithGivenValue()
        {
            var options = new OptionDescriptor[0];
            var descriptor = new CommandDescriptor("any", "any", options);
            Assert.Same(options, descriptor.Options);
        }
    }
}
