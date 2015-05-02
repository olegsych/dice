using Xunit;

namespace Dice.Abstractions
{
    public class OptionDescriptorTest
    {
        [Fact]
        public void ConstructorInvokesBaseWithAllParameters()
        {
            const string expectedName = "Test Name";
            const string expectedSummary = "Test Summary";

            var descriptor = new OptionDescriptor(expectedName, expectedSummary);

            Assert.Equal(expectedName, descriptor.Name);
        }
    }
}
