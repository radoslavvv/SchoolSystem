using SchoolSystem.Core;
using SchoolSystem.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem
{
    public class StartUp
    {
        public static void Main()
        {
            IConsoleReader reader = new ConsoleReader();
            IConsoleWriter writer = new ConsoleWriter();

            ISchoolSystemController schoolController = new SchoolSystemController();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(schoolController);

            IEngine engine = new Engine(commandInterpreter, reader, writer);
            engine.Run();
        }
    }
}
