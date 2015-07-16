using GMS.Framework.Contract;
using GMS.Framework.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GMS.Project.Contract
{    
    [Serializable]
    [Table("Accounting")]
    public class Accounting : ModelBase
    {
        public Accounting()
        {
            //Materials = new HashSet<Material>();
        }

       
        /// <summary>
        /// 科目名字
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 科目编码
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// 会计级别 如：一级科目，二级科目
        /// </summary>
        public string Rank { get; set; }
        /// <summary>
        /// 会计分类，如：资产类、负债类
        /// </summary>
        public string AccountDep { get; set; }

        public string Description { get; set; }

        public string Remark { get; set; }

        //public virtual Accountant accountant { get; set; }      
    }

    /// <summary>
    /// 级别
    /// </summary>
    public enum EnumRank
    {
        [EnumTitle("一级科目")]
        First = 1,

        [EnumTitle("二级科目")]
        Second = 2
    }

    /// <summary>
    /// 分类
    /// </summary>
    public enum EnumDep
    {
        [EnumTitle("资产类")]
        Asset = 1001,

        [EnumTitle("负债类")]
        Debt = 2000
    }
}
