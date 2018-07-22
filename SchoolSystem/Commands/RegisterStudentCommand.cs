using SchoolSystem.Exceptions;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Commands
{
    public class RegisterStudentCommand : Command
    {
        private string CommandFormat = "04. RegisterStudent {schoolName} {studentFirstName} {studentLastName}";
        private ISchoolSystemController controller;

        public RegisterStudentCommand(IList<string> args, ISchoolSystemController manager)
            : base(args)
        {
            this.controller = manager;
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

            IStudent currentStudent = new Student(studentFirstName, studentLastName);
            this.controller
                .Schools
                .FirstOrDefault(s=>s.Name == schoolName)
                .RegisterStudent(currentStudent);

            return $"Student: {currentStudent.FirstName} {currentStudent.LastName} successfully registered to {schoolName} School";
        }
    }
}
