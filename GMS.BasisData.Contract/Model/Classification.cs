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
    [Table("Classification")]
    public class Classification : ModelBase
    {
        public Classification()
        {
            Materials = new HashSet<Material>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
