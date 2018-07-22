using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem
{
    public class SchoolSystemController : ISchoolSystemController
    {
        private List<ISchool> schools;
        public SchoolSystemController()
        {
            this.schools = new List<ISchool>();
        }
        public void AddSchool(ISchool schoolToAdd)
        {
            this.schools.Add(schoolToAdd);
        }
        public void DeleteSchool(ISchool schoolToDelete)
        {
            this.schools.Remove(schoolToDelete);
        }

        public IReadOnlyCollection<ISchool> Schools => this.schools;
    }
}
