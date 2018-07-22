using System.Collections.Generic;

namespace SchoolSystem
{
    public interface ICommand
    {
        IList<string> Arguments { get; }

        string Execute();
    }
}