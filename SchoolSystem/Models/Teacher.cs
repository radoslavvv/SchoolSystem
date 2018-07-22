using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem.Models
{
    public class Teacher : ITeacher
    {
        private List<IGroup> groups;
        public Teacher(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            this.groups = new List<IGroup>();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public IReadOnlyCollection<IGroup> Groups => this.groups;

        public void AddGroup(IGroup group)
        {
            this.groups.Add(group);
        }

        public void DeleteGroup(IGroup groupToDelete)
        {
            this.groups.Remove(groupToDelete);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"--Teacher: {this.FirstName} {this.LastName}");
            if (this.groups.Count != 0)
            {
                sb.AppendLine($"--Teacher Groups:");
                foreach (var group in this.Groups)
                {
                    sb.AppendLine(group.ToString());
                }
            }
            else
            {
                sb.Append($"--Teacher Groups: (None)"); ;
            }

            return sb.ToString().Trim();
        }
    }
}