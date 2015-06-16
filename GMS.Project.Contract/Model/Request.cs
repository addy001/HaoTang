using GMS.Framework.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Project.Contract
{
    public class ProjectRequest : Request
    {
        public string PName { get; set; }
        public string PCharger { get; set; }
    }
    public class BudgetRequest : Request
    {
        public string ProjectName { get; set; }       
    }

}
