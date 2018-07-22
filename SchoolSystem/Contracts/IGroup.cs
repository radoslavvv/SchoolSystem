using System.Collections.Generic;

namespace SchoolSystem.Models
{
    public interface IGroup
    {
        string Name { get; }
        IReadOnlyCollection<IStudent> Students { get; }
        ITeacher Teacher { get; }

        void AddStudent(IStudent studentToAdd);
        void RemoveStudent(IStudent studentToRemove);
        string ToString();
    }
}