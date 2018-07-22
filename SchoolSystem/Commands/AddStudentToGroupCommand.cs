using SchoolSystem.Exceptions;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Commands
{
    public class AddStudentToGroupCommand : Command
    {
        private string CommandFormat = "08. AddStudentToGroup {schoolName} {studentFirstName} {studentLastName} {groupName}";

        private ISchoolSystemController controller;
        public AddStudentToGroupCommand(IList<string> args, ISchoolSystemController controller)
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

            IStudent studentToAdd = currentSchool.Students
                .FirstOrDefault(s => s.FirstName == studentFirstName && s.LastName == studentLastName);
            if (studentToAdd == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.StudentIsNotRegisteredInSchool, studentFirstName, studentLastName, schoolName));
            }

            IGroup group = currentSchool.Groups.FirstOrDefault(g => g.Name == groupName);
            if (group == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.GroupDoesntExist, groupName, schoolName));
            }

            this.controller
                .Schools
                .FirstOrDefault(s => s.Name == schoolName)
                .Groups
                .FirstOrDefault(g => g == group)
                .AddStudent(studentToAdd);

            return $"Student {studentFirstName} {studentLastName} successfully added to group: {groupName} in {schoolName} School!";
        }
    }
}
