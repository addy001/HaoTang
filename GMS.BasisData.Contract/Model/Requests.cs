using System;
using System.Collections.Generic;
using GMS.Framework.Contract;

namespace GMS.BasisData.Contract
{
    public class ClassificationRequest : Request
    {


        public string Name { get; set; }

        public string Code { get; set; }

    }

    public class MaterialRequest : Request
    {

        public string Name { get; set; }

        public int? ClassificationID { get; set; }

        public bool? IsAvailability { get; set; }
    }

    public class SupplierRequest : Request
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }


    }
    public class MaterialSupplierRequest : Request
    {

        public int MaterialID { get; set; }

        public int SupplierID { get; set; }
        public double? Price { get; set; }
        public string Remark { get; set; }
        public string MaterialName { get; set; }
        public string SupplierName { get; set; }

    }
}
