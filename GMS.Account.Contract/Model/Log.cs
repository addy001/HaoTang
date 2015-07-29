using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Framework.Contract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GMS.Account.Contract
{
    [Table("Log")]
    public class Log : ModelBase
    {
        public int ModelId { get; set; }
        public string UserName { get; set; }
        public string ModuleName { get; set; }
        public string TableName { get; set; }
        public string EventType { get; set; }
        public string NewValues { get; set; }
    }
}