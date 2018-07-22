using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem.Models
{
    public class Student : IStudent
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int StudentId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"----Student: {this.FirstName} {this.LastName}");

            return sb.ToString().Trim();
        }
    }
}
