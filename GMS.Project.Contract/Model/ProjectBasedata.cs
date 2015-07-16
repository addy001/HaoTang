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
    [Table("ProjectBasedata")]
    public class ProjectBasedata : ModelBase
    {
        public ProjectBasedata()
        {
            //PSDate = DateTime.Now;
        }
       
      
       
        //public new Guid ID { get; set; }
       
        /// <summary>
        /// 项目名称
        /// </summary> 
        [StringLength(100)]
        [Required(ErrorMessage = "项目名称不能为空")]
        public string PName { get; set; }
        /// <summary>
        /// 项目位置
        /// </summary>
         [Required(ErrorMessage = "项目位置不能为空")]
        public string PLocation { get; set; }
        /// <summary>
        /// 项目开工日期
        /// </summary>
        public string PSDate { get; set; }
        /// <summary>
        /// 项目结束工期
        /// </summary>
        public string PEdate { get; set; }
        /// <summary>
        /// 项目负责人
        /// </summary>
        public string PCharger { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
      [RegularExpression(@"^[1-9]{1}\d{10}$", ErrorMessage = "不是有效的手机号码")]
        public string PPhone { get; set; }
        /// <summary>
        /// 项目内容
        /// </summary>
        public string PContent { get; set; }
        /// <summary>
        /// 项目规模
        /// </summary>
        public string PScale { get; set; }
        /// <summary>
        /// 项目结构
        /// </summary>
        public string PStructure { get; set; }
        /// <summary>
        /// 资金来源
        /// </summary>
        public string Fund { get; set; }
        /// <summary>
        /// 项目报价
        /// </summary>
        public int PPrice { get; set; }
        /// <summary>
        /// 项目成本预算
        /// </summary>
        public int PBuget { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string PRemark { get; set; }

        

    }
    /// <summary>
    /// Status
    /// </summary>
    public enum EnumStatus
    {
        [EnumTitle("已立项")]
         Pre = 1,

        [EnumTitle("已验收")]
        Last = 2
    }
    /// <summary>
    /// PFund
    /// </summary>
    public enum EnumFund
    {
        [EnumTitle("自筹")]
        Self = 1,

        [EnumTitle("合伙")]
        Work = 2

       
    }
}

