using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SchoolSystem.Commands
{
    public class HelpCommand : Command
    {
        private string CommandFormat = "10. Help";
        private ISchoolSystemController controller;

        public HelpCommand(IList<string> args, ISchoolSystemController controller)
            : base(args)
        {
            this.controller = controller;
        }

        public override string Execute()
        {
            List<string> formats = new List<string>();

            Type[] commandTypes = Assembly
                    .GetCallingAssembly()
                    .GetTypes()
                    .Where(t => (t.Name != "Command" && t.Name != "ICommand") && t.Name.EndsWith("Command"))
                    .ToArray();

            foreach (var commandType in commandTypes)
            {
                ConstructorInfo ctor = commandType
                    .GetConstructors()
                    .First();

                object[] prarams = { null, null };
                ICommand commandInstance = (ICommand)Activator
                    .CreateInstance(commandType, prarams);

                FieldInfo commandFiled = commandType
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(f => f.Name == "CommandFormat");

                string commandFormat = (string)commandFiled.GetValue(commandInstance);
                formats.Add(commandFormat);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var format in formats.OrderBy(f => f))
            {
                sb.AppendLine(format);
            }

            return sb.ToString().Trim();
        }
    }
}
