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

        }
      
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        [Required]
        public Guid codeID {get;set;}
       
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        public string ProjName {get;set;}
       
        /// <summary>
        /// 项目负责人
        /// </summary>
        [Required]
        public string ProjChargeman {get;set;}
        
        /// <summary>
        /// 项目位置
        /// </summary>
        [Required]
        public string ProjLocation {get;set;}
       
        /// <summary>
        /// 项目面积
        /// </summary>
        [Required]
        public decimal ProjArea {get;set;}
       
        /// <summary>
        /// 项目开工时间
        /// </summary>
        public DateTime ProjStartdate { get; set; }
        
        /// <summary>
        /// 项目工期
        /// </summary>
        public string Projdate { get; set; }
       
        /// <summary>
        /// 项目是否结束
        /// </summary>
        [Required]
        public string state { get; set; }
      
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProjEnddate { get; set; }
      
        /// <summary>
        /// 工地负责人联系电话
        /// </summary>
        public string ProjPhone { get; set; }
     
        /// <summary>
        /// 项目内容介绍
        /// </summary>
        public string ProjContent { get; set; }
       
        /// <summary>
        /// 工程规模
        /// </summary>
        public string ProjScale { get; set; }
     
        /// <summary>
        /// 结构形式
        /// </summary> 
        public string ProjStructure { get; set; }
        
        /// <summary>
        /// 资金来源
        /// </summary>
        public string ProjFunds { get; set; }
        
        /// <summary>
        /// 项目报价
        /// </summary>
        public string ProjPrice { get; set; }
       
        /// <summary>
        /// 项目成本预算
        /// </summary>
        public int? ProjCostBudget { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
       
       
        public string Remark { get; set; }
      
    }

}

