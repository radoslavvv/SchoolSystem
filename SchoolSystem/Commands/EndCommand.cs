using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem.Commands
{
    public class EndCommand : Command
    {
        private string CommandFormat = "11. End";
        private ISchoolSystemController controller;

        public EndCommand(IList<string> args, ISchoolSystemController controller) 
            : base(args)
        {
            this.controller = controller;
        }

        public override string Execute()
        {
            StringBuilder sb = new StringBuilder();
            if(this.controller.Schools.Count != 0)
            {
                sb.AppendLine("Schools: ");
                foreach (var school in this.controller.Schools)
                {
                    sb.AppendLine(school.ToString());
                }
            }
            else
            {
                sb.AppendLine("Schools: (None)");
            }
          
            return sb.ToString().Trim();
        }
    }
}
