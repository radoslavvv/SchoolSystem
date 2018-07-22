using SchoolSystem.Exceptions;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Commands
{
    public class RemovetudentFromGroupCommand : Command
    {
        private string CommandFormat = "09. RemoveStudentFromGroup {schoolName} {studentFirstName} {studentLastName} {groupName}";
        private ISchoolSystemController controller;

        public RemovetudentFromGroupCommand(IList<string> args, ISchoolSystemController controller)
            : base(args)
        {
            this.controller = controller;
        }

        public override string Execute()
        {
            string schoolName = this.Arguments[0];
            string studentFirstName = this.Arguments[1];
            string studentLastName = this.Arguments[2];
            string groupName = this.Arguments[3];

            ISchool currentSchool = this.controller.Schools
               .FirstOrDefault(s => s.Name == schoolName);

            if (currentSchool == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.SchoolDoesntExist, schoolName));
            }

            IGroup group = currentSchool.Groups
                .FirstOrDefault(g => g.Name == groupName);

            if (group == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.GroupDoesntExist, groupName, schoolName));
            }

            IStudent studentToRemove = group.Students
                                .FirstOrDefault(s => s.FirstName == studentFirstName && s.LastName == studentLastName);

            if (studentToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.StudentIsNotRegisteredInSchool, studentFirstName, studentLastName, schoolName));
            }

            this.controller
                .Schools
                .First(s => s.Name == schoolName)
                .Groups
                .First(g => g.Name == groupName)
                .RemoveStudent(studentToRemove);

            return $"Student: {studentFirstName} {studentLastName} successfully removed from {groupName} group from {schoolName} School!";
        }
    }
}
