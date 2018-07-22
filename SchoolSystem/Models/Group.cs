using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem.Models
{
    public class Group : IGroup
    {
        private List<IStudent> students;

        public Group(string groupName, ITeacher groupTeacher)
        {
            this.Name = groupName;
            this.Teacher = groupTeacher;

            this.students = new List<IStudent>();
        }
        public string Name { get; private set; }

        public IReadOnlyCollection<IStudent> Students => this.students;

        public ITeacher Teacher { get; private set; }

        public void AddStudent(IStudent studentToAdd)
        {
            this.students.Add(studentToAdd);
        }
        public void RemoveStudent(IStudent studentToRemove)
        {
            this.students.Remove(studentToRemove);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"---Group Name: {this.Name}");
            if(this.students.Count != 0)
            {
                sb.AppendLine($"---Group Students: ");
                foreach (var student in this.Students)
                {
                    sb.AppendLine(student.ToString());
                }
            }
            else
            {
                sb.AppendLine($"---Group Students: (None)");
            }
           
            sb.AppendLine($"---Group Teacher: {this.Teacher.FirstName[0]}.{this.Teacher.LastName}");
            return sb.ToString().Trim();
        }
    }
}
