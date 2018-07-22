using System.Collections.Generic;

namespace SchoolSystem.Models
{
    public interface ISchool
    {
        IReadOnlyCollection<IGroup> Groups { get; }
        string Name { get; }
        IReadOnlyCollection<IStudent> Students { get; }
        IReadOnlyCollection<ITeacher> Teachers { get; }

        void AddGroup(IGroup groupToAdd);
        void DeleteGroup(IGroup groupToRemove);
        void DeleteStudent(IStudent studentToRemove);
        void RegisterStudent(IStudent studentToAdd);
        void RegisterTeacher(ITeacher teacherToAdd);
        string ToString();
    }
}