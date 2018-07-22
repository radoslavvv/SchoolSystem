using SchoolSystem.Exceptions;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Commands
{
    public class CreateGroupCommand : Command
    {
        private string CommandFormat = "06. CreateGroup {schoolName} {teacherFirstName} {teacherLastName} {groupName}";
        private ISchoolSystemController controller;

        public CreateGroupCommand(IList<string> args, ISchoolSystemController manager)
            : base(args)
        {
            this.controller = manager;
        }

        public override string Execute()
        {
            string schoolName = this.Arguments[0];
            string teacherFirstName = this.Arguments[1];
            string teacherLastName = this.Arguments[2];
            string groupName = this.Arguments[3];

            ISchool currentSchool = this.controller.Schools
             .FirstOrDefault(s => s.Name == schoolName);

            if (currentSchool == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.SchoolDoesntExist, schoolName));
            }

            ITeacher teacher = currentSchool
                .Teachers
                .FirstOrDefault(t => t.FirstName == teacherFirstName && t.LastName == teacherLastName);

            if (teacher == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.TeacherDoesntExist, teacherFirstName, teacherLastName, schoolName));
            }

            IGroup group = currentSchool
                .Groups
                .FirstOrDefault(g => g.Name == groupName);

            if (group != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.GroupAlreadyCreated, groupName, schoolName));
            }

            group = new Group(groupName, teacher);

            this.controller.Schools.FirstOrDefault(s => s.Name == schoolName)
                .AddGroup(group);

            this.controller.Schools
                .FirstOrDefault(s => s.Name == schoolName)
                .Teachers
                .FirstOrDefault(t => t == teacher)
                .AddGroup(group);

            return $"Group: {groupName} was successfully added to {schoolName} School with teacher {teacherFirstName} {teacherLastName}!";
        }
    }
}
