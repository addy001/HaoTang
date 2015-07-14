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
    [Table("ProjectBasedata")]
    public class ProjectBasedata : ModelBase
    {
        public ProjectBasedata()
        {
            //PSDate = DateTime.Now;
        }
       
        [StringLength(100)]
        [Required]
        //public new Guid ID { get; set; }
       
        /// <summary>
        /// 项目名称
        /// </summary>       
        public string PName { get; set; }
        /// <summary>
        /// 项目位置
        /// </summary>
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
         [StringLength(50, ErrorMessage = "电话不能超过50个字")]
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
        public string PFund { get; set; }
        /// <summary>
        /// 项目报价
        /// </summary>
        public int PPrice { get; set; }
        /// <summary>
        /// 项目成本预算
        /// </summary>
        public int PBuget { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string PRemark { get; set; }

        

    }
}

