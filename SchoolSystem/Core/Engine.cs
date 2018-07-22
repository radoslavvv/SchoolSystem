using SchoolSystem.Commands;
using SchoolSystem.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;
        private IConsoleReader reader;
        private IConsoleWriter writer;

        public Engine(ICommandInterpreter commandInterpreter, IConsoleReader reader, IConsoleWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            ICommand helpCommand = new HelpCommand(null,null);
            writer.WriteLine(helpCommand.Execute());
            while (true)
            {
                writer.Write($"Enter command --> ");
                IList<string> inputArgs = this.reader
                       .ReadLine()
                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .ToList();

                string result = this.commandInterpreter.ProcessCommand(inputArgs);

                this.writer.WriteLine(result);

                if(inputArgs[0] == "End")
                {
                    break;
                }
            }
        }
    }
}
