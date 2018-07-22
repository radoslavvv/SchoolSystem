using System.Collections.Generic;
using SchoolSystem.Models;

namespace SchoolSystem
{
    public interface ISchoolSystemController
    {
        IReadOnlyCollection<ISchool> Schools { get; }

        void AddSchool(ISchool schoolToAdd);
        void DeleteSchool(ISchool schoolToDelete);
    }
}