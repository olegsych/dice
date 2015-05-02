using System;
using System.Reflection;
using Xunit;

namespace Dice.Abstractions
{
    public class ItemDescriptorTest
    {
        [Fact]
        public void ClassIsAbstractAndServesAsBaseClassForConcreteDescriptors()
        {
            Assert.True(typeof(ItemDescriptor).GetTypeInfo().IsAbstract);
        }

        [Fact]
        public void ConstructorInitializesNamePropertyWithGivenValue()
        {
            const string expectedValue = "ItemName";
            var descriptor = new TestableItemDescriptor(expectedValue, "any");
            Assert.Equal(expectedValue, descriptor.Name);
        }

        [Theory, InlineData(null), InlineData(""), InlineData(" \t\n\r")]
        public void ConstructorThrowsArgumentExceptionWhenNameIsNotSpecifiedCorrectly(string name)
        {
            var e = Assert.ThrowsAny<ArgumentException>(() => new TestableItemDescriptor(name, "any"));
            Assert.Equal("name", e.ParamName);
        }

        [Fact]
        public void ConstructorInitializesSummaryPropertyWithGivenValue()
        {
            const string expectedValue = "Test Summary";
            var descriptor = new TestableItemDescriptor("any", expectedValue);
            Assert.Equal(expectedValue, descriptor.Summary);
        }

        [Theory, InlineData(null), InlineData(""), InlineData(" \t\n\r")]
        public void ConstructorThrowsArgumentExceptionWhenSummaryIsNotSpecifiedCorrectly(string summary)
        {
            var e = Assert.ThrowsAny<ArgumentException>(() => new TestableItemDescriptor("any", summary));
            Assert.Equal("summary", e.ParamName);
        }

        private class TestableItemDescriptor : ItemDescriptor
        {
            public TestableItemDescriptor(string name, string summary) : base(name, summary)
            {
            }
        }
    }
}
