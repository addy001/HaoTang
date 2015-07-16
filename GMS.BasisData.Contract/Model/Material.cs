
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
    [Table("Material")]
    public class Material : ModelBase
    {
        public Material()
        {
            Suppliers = new HashSet<Supplier>();

        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? ClassificationID { get; set; }

        public bool? IsAvailability { get; set; }

        public virtual Classification Classification { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }

    }

}