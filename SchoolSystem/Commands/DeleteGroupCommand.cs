using SchoolSystem.Exceptions;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Commands
{
    public class DeleteGroupCommand : Command
    {
        private string CommandFormat = "07. DeleteGroup {schoolName} {groupName}";
        private ISchoolSystemController controller;

        public DeleteGroupCommand(IList<string> args, ISchoolSystemController controller)
            : base(args)
        {
            this.controller = controller;
        }

        public override string Execute()
        {
            string schoolName = this.Arguments[0];
            string groupName = this.Arguments[1];

            ISchool currentSchool = this.controller.Schools
             .FirstOrDefault(s => s.Name == schoolName);

            if (currentSchool == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.SchoolDoesntExist, schoolName));
            }

            IGroup groupToDelete = currentSchool.Groups.FirstOrDefault(g => g.Name == groupName);
            if (groupToDelete == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.GroupDoesntExist, groupName, schoolName));
            }

            this.controller
                .Schools
                .FirstOrDefault(s=>s.Name == schoolName)
                .DeleteGroup(groupToDelete);

            foreach (var  teacher in currentSchool.Teachers)
            {
                teacher.DeleteGroup(groupToDelete);
            }

            return $"Group: {groupName} successfully deleted from {schoolName} School!";
        }
    }
}
