using System;
using System.Linq;
using GMS.Framework.Contract;
using System.Collections.Generic;
using GMS.Framework.Utility;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GMS.BasisData.Contract
{
    [Serializable]
    [Table("Supplier")]
    public class Supplier:ModelBase
    {
        public Supplier()
        {
            Materials = new HashSet<Material>();
            
        }

        public int ID { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Contactor { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string Email { get; set; }


        [StringLength(100)]
        public string Contact { get; set; }

      
       
                  
        public virtual ICollection<Material> Materials { get; set; }

    }
}
