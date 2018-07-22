using System.Collections.Generic;

namespace SchoolSystem
{
    public interface ICommandInterpreter
    {
        ISchoolSystemController Controller { get; }

        string ProcessCommand(IList<string> data);
    }
}