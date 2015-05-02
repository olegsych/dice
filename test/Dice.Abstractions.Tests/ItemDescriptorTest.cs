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
            const string expected = "ItemName";

            var descriptor = new TestableItemDescriptor("ItemName");

            Assert.Equal(expected, descriptor.Name);
        }

        [Theory, InlineData(null), InlineData(""), InlineData(" \t\n\r")]
        public void ConstructorThrowsArgumentExceptionWhenNameIsNotSpecifiedCorrectly(string value)
        {
            var e = Assert.ThrowsAny<ArgumentException>(() => new TestableItemDescriptor(value));
            Assert.Equal("name", e.ParamName);
        }

        private class TestableItemDescriptor : ItemDescriptor
        {
            public TestableItemDescriptor(string name) : base(name)
            {
            }
        }
    }
}
