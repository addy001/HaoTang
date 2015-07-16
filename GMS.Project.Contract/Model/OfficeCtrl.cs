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
    [Table("OfficeCtrl")]
    public class OfficeCtrl : ModelBase
    {
        public OfficeCtrl()
        {
 
        }
        /// <summary>
        /// 公司物品名称
        /// </summary>
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 用途概述
        /// </summary>
        public string Toolname { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string obb { get; set; }
        /// <summary>
        /// 渠道
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
