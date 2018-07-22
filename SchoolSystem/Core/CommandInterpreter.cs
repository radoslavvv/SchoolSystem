using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SchoolSystem
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter(ISchoolSystemController controller)
        {
            this.Controller = controller;
        }

        public ISchoolSystemController Controller { get; private set; }

        public string ProcessCommand(IList<string> data)
        {
            string result = string.Empty;
            try
            {
                ICommand command = CreateCommand(data);

                result = command.Execute();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        private ICommand CreateCommand(IList<string> args)
        {
            string commandName = args[0];

            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName + "Command");

            ConstructorInfo ctor = commandType
                .GetConstructors()
                .First();

            ParameterInfo[] ctorParams = ctor.GetParameters();

            object[] parameters = new object[ctorParams.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                Type paramType = ctorParams[i].ParameterType;

                if (paramType == typeof(IList<string>))
                {
                    parameters[i] = args.Skip(1).ToList();
                }
                else
                {
                    PropertyInfo paramInfo = this.GetType()
                        .GetProperties()
                        .FirstOrDefault(p => p.PropertyType == paramType);

                    parameters[i] = paramInfo.GetValue(this);
                }
            }

            ICommand commandInstance = (ICommand)Activator
                .CreateInstance(commandType, parameters);

            return commandInstance;
        }
    }
}