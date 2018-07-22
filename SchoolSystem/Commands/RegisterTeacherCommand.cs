using SchoolSystem.Exceptions;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Commands
{
    public class RegisterTeacherCommand : Command
    {
        private string CommandFormat = "03. RegisterTeacher {schoolName} {teacherFirstName} {teacherLastName}";
        private ISchoolSystemController controller;

        public RegisterTeacherCommand(IList<string> args, ISchoolSystemController controller) 
            : base(args)
        {
            this.controller = controller;
        }

        public override string Execute()
        {
            string schoolName = this.Arguments[0];
            string teacherFirstName = this.Arguments[1];
            string teacherLastName = this.Arguments[2];

            ISchool currentSchool = this.controller.Schools
                     .FirstOrDefault(s => s.Name == schoolName);

            if (currentSchool == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.SchoolDoesntExist, schoolName));
            }

            ITeacher teacherToAdd = new Teacher(teacherFirstName, teacherLastName);
            this.controller
                .Schools
                .FirstOrDefault(s=>s.Name == schoolName)
                .RegisterTeacher(teacherToAdd);

            return $"Teacher: {teacherToAdd.FirstName} {teacherToAdd.LastName} successfully registered to {schoolName} School";
        }
    }
}
