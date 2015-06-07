using GMS.Framework.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Basedata.Contract
{
    public class MaterialRequest : Request
    {
        public string MaterialName { get; set; }
        public string MaterialCode { get; set; }
    }

    
}
