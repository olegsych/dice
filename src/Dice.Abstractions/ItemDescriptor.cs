using System;

namespace Dice.Abstractions
{
    public abstract class ItemDescriptor
    {
        protected ItemDescriptor(string name, string summary)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name) + " cannot be null or white space", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(summary))
            {
                throw new ArgumentException(nameof(summary) + " cannot be null or white space", nameof(summary));
            }

            this.Name = name;
            this.Summary = summary;
        }

        public string Name { get; }

        public string Summary { get; }
    }
}
