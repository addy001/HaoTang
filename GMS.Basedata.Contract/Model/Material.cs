using GMS.Framework.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GMS.Framework.Utility;
using System.ComponentModel.DataAnnotations;

namespace GMS.Basedata.Contract
{
    [Serializable]
    [Table("Material")]
    public class Material : ModelBase {
        public Material()
        {
 
        } 
         

        [StringLength(100)]
        [Required]
        public string MaterialCode { get; set; }

        [StringLength(100)]
        [Required]
        public string MaterialName { get; set; }

    }
   
}
