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
    }
}
