using System;

namespace Dice.Abstractions
{
    public abstract class ItemDescriptor
    {
        public ItemDescriptor(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name) + " cannot be null or white space", nameof(name));
            }

            this.Name = name;
        }

        public string Name { get; }
    }
}
