using SchoolSystem.Exceptions;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Commands
{
    public class DeleteStudentCommand : Command
    {
        private string CommandFormat = "05. DeleteStudent {schoolName} {studentFirstName} {studentLastName}";
        private ISchoolSystemController controller;

        public DeleteStudentCommand(IList<string> args, ISchoolSystemController controller) 
            : base(args)
        {
            this.controller = controller;
        }

        public override string Execute()
        {
            string schoolName = this.Arguments[0];
            string studentFirstName = this.Arguments[1];
            string studentLastName = this.Arguments[2];

           ISchool currentSchool = this.controller.Schools
            .FirstOrDefault(s => s.Name == schoolName);

            if (currentSchool == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.SchoolDoesntExist, schoolName));
            }

            IStudent studentToDelete = currentSchool.Students.FirstOrDefault(s => s.FirstName == studentFirstName && s.LastName == studentLastName);
            if (studentToDelete == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.StudentIsNotRegisteredInSchool, studentFirstName, studentLastName, schoolName));
            }

            this.controller.Schools.FirstOrDefault(s=>s.Name == schoolName).DeleteStudent(studentToDelete);

            return $"Student: {studentFirstName} {studentLastName} successfully deleted from {schoolName} School";
        }
    }
}
