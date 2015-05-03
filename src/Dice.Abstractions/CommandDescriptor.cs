using System;
using System.Collections.Generic;
using System.Linq;

namespace Dice.Abstractions
{
    public class CommandDescriptor : ItemDescriptor
    {
        public CommandDescriptor(string name, string summary, IEnumerable<OptionDescriptor> options) 
            : base(name, summary)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.Any(item => item == null))
            {
                throw new ArgumentException(nameof(options) + " elements must not be null", nameof(options));
            }

            this.Options = options;
        }

        public IEnumerable<OptionDescriptor> Options { get; }
    }
}
