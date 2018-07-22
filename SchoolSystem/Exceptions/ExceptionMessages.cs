using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem.Exceptions
{
    public class ExceptionMessages
    {
        public const string SchoolDoesntExist = "There is no school with name: {0}!";

        public const string SchoolAlredyRegistered = "School {0} already registered!";

        public const string StudentIsNotRegisteredInSchool = "There is no student with name: {0} {1} in {2} School!";

        public const string GroupDoesntExist = "There is no group with name: {0} in {1} School!";

        public const string GroupAlreadyCreated = "There already is registered group with name {0} in {1} School!";

        public const string TeacherDoesntExist = "There is no teacher with name: {0} {1} in {2} School!";


    }
}
