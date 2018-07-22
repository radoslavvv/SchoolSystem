using SchoolSystem.Exceptions;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Commands
{
    public class DeleteSchoolCommand : Command
    {
        private string CommandFormat = "02. DeleteSchool {schoolName}";
        private ISchoolSystemController controller;

        public DeleteSchoolCommand(IList<string> args, ISchoolSystemController controller) 
            : base(args)
        {
            this.controller = controller;
        }

        public override string Execute()
        {
            string schoolName = this.Arguments[0];

            ISchool schoolToDelete = this.controller
                .Schools.FirstOrDefault(s => s.Name == schoolName);

            if (schoolToDelete == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.SchoolDoesntExist, schoolName));
            }

            this.controller.DeleteSchool(schoolToDelete);

            return $"School {schoolName} was deleted successfully!";
        }
    }
}
