using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Models
{
    public class School : ISchool
    {
        private List<ITeacher> teachers;
        private List<IGroup> groups;
        private List<IStudent> students;

        public School(string schoolName)
        {
            this.Name = schoolName;

            this.teachers = new List<ITeacher>();
            this.groups = new List<IGroup>();
            this.students = new List<IStudent>();
        }
        public string Name { get; private set; }

        public IReadOnlyCollection<ITeacher> Teachers => this.teachers;
                                   
        public IReadOnlyCollection<IGroup> Groups => this.groups;
                                   
        public IReadOnlyCollection<IStudent> Students => this.students;

        public void RegisterStudent(IStudent studentToAdd)
        {
            this.students.Add(studentToAdd);
        }

        public void DeleteStudent(IStudent studentToRemove)
        {
            this.students.Remove(studentToRemove);

            foreach (var group in this.groups)
            {
                foreach (var student in group.Students)
                {
                    if (student == studentToRemove)
                    {
                        this.groups
                            .First(g => g.Name == group.Name)
                            .RemoveStudent(student);
                        break;
                    }
                }
            }
        }

        public void AddGroup(IGroup groupToAdd)
        {
            this.groups.Add(groupToAdd);
        }

        public void DeleteGroup(IGroup groupToRemove)
        {
            this.groups.Remove(groupToRemove);
        }

        public void RegisterTeacher(ITeacher teacherToAdd)
        {
            this.teachers.Add(teacherToAdd);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"School: {this.Name}");

            if (this.Teachers.Count != 0)
            {
                sb.AppendLine($"Teachers: {string.Join(",", this.Teachers.Select(t => t.FirstName + " " + t.LastName))}");
            }
            else
            {
                sb.AppendLine("Teachers: (None)");
            }

            if (this.Students.Count != 0)
            {
                sb.AppendLine($"Students: {string.Join(", ", this.Students.Select(s => s.FirstName + " " + s.LastName))}");
            }
            else
            {
                sb.AppendLine("Students: (None)");
            }

            if (this.Groups.Count != 0)
            {
                sb.AppendLine("Groups:");
                foreach (var group in groups)
                {
                    sb.AppendLine(group.ToString());
                }
            }
            else
            {
                sb.AppendLine("Groups: (None)");
            }
            return sb.ToString().Trim();
        }
    }
}
