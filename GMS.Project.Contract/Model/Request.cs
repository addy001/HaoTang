using GMS.Framework.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Project.Contract
{
    public class ProjectRequest : Request
    {
        public string ProjName { get; set; }
        public string ProjChargeman { get; set; }
    }
}
