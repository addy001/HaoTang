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
    [Table("ProjectCtrl")]
    public class ProjectCtrl : ModelBase
    {
        public ProjectCtrl()
        {
 
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 简述
        /// </summary>
        public string Stuffname { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string obb { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string Way { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string oddnum { get; set; }
        /// <summary>
        /// 审批
        /// </summary>
        public bool IsPro { get; set; }

    }

}
