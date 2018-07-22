using SchoolSystem.Exceptions;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Commands
{
    public class RegisterSchoolCommand : Command
    {
        private string CommandFormat = "01. RegisterSchool {schoolName}";
        private ISchoolSystemController controller;

        public RegisterSchoolCommand(IList<string> args, ISchoolSystemController controller)
            : base(args)
        {
            this.controller = controller;
        }

        public override string Execute()
        {
            string schoolName = this.Arguments[0];

            ISchool schoolToRegister = new School(schoolName);
            if (this.controller.Schools.Any(s => s.Name == schoolName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.SchoolAlredyRegistered, schoolName));
            }

            this.controller.AddSchool(schoolToRegister);

            return $"School {schoolName} was registered successfully";
        }
    }
}
