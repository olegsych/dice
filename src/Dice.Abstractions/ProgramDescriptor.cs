using System;
using System.Collections.Generic;
using System.Linq;

namespace Dice.Abstractions
{
    public class ProgramDescriptor : ItemDescriptor
    {
        public ProgramDescriptor(string name, string summary, IEnumerable<CommandDescriptor> commands) 
            : base(name, summary)
        {
            if (commands == null)
            {
                throw new ArgumentNullException(nameof(commands));
            }

            if (commands.Any(item => item == null))
            {
                throw new ArgumentException(nameof(commands) + " elements must not be null", nameof(commands));
            }

            this.Commands = commands;
        }

        public IEnumerable<CommandDescriptor> Commands { get; }
    }
}
