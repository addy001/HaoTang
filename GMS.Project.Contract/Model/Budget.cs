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
    [Table("Budget")]
    public class Budget : ModelBase
    {
        public Budget()
        {
        }

        #region Model


        /// <summary>
        /// 项目Id
        /// </summary>
        [StringLength(100)]
        [Required]
        public string ProjectID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 人工费
        /// </summary>
        public string Labour { get; set; }
        /// <summary>
        /// 材料费
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// 机械使用费
        /// </summary>
        public string MachineryCost { get; set; }
        /// <summary>
        /// 其他直接费用
        /// </summary>
        public string Measure { get; set; }
        /// <summary>
        /// 间接费用
        /// </summary>
        public string Overhead { get; set; }
        /// <summary>
        /// 工程保修金
        /// </summary>
        public string Warranty { get; set; }
        /// <summary>
        /// 分包工程
        /// </summary>
        public string Subcontracting { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public string OtherBudget { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        #endregion Model
    }
}
