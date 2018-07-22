using System.Collections.Generic;

namespace SchoolSystem.Models
{
    public interface ITeacher
    {
        string FirstName { get; }
        IReadOnlyCollection<IGroup> Groups { get; }
        string LastName { get; }

        void AddGroup(IGroup group);
        void DeleteGroup(IGroup groupToDelete);
        string ToString();
    }
}