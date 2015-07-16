using GMS.Framework.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GMS.Project.Contract
{   
    [Serializable]
    [Table("Accountant")]
    public class Accountant : ModelBase
    {
        public Accountant()
        {
            //Materials = new HashSet<Material>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        //public virtual ICollection<Material> Materials { get; set; }
    }


   
}
