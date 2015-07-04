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
    [Table("MaterialSupplier")]
    public class MaterialSupplier : ModelBase
    {
        public MaterialSupplier()
        {
            //Suppliers = new HashSet<Supplier>();
            //Materials = new HashSet<Material>();
        }
        public int ID { get; set; }

        public int MaterialID { get; set; }

        public int SupplierID { get; set; }

        public double? Price { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }
        [StringLength(100)]
        public string MaterialName { get; set; }
        [StringLength(100)]
        public string SupplierName { get; set; }
        //public virtual ICollection<Material> Materials { get; set; }
        //public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual Material Material { get; set; }
        public virtual Supplier Supplier { get; set; }

    }

}