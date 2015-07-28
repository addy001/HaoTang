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
        /// 单价
        /// </summary>
        public double obb { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int num { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string oddnum { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public double total{ get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string danwei { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string guige { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string pinpai { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string beizhu { get; set; }
    }
}
