using System.Collections.Generic;

namespace SchoolSystem
{
    public abstract class Command : ICommand
    {
        public Command(IList<string> args)
        {
            this.Arguments = args;
        }

        public IList<string> Arguments { get; protected set; }

        public abstract string Execute();
    }
}