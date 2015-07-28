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
    [Table("Odder")]
    public class Odder : ModelBase
    {
        public Odder()
        {

        }
        
        [StringLength(50)]
        [Required]
        /// <summary>
        /// 单号
        /// </summary>
        public string oddnum { get; set; }
        /// <summary>
        /// 采购人
        /// </summary>
        public string Buyer { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public string Total { get; set; }
        /// <summary>
        /// 审批
        /// </summary>
        public bool IsPro { get; set; }
        /// <summary>
        /// 是否达标
        /// </summary>
        public bool IsStandard { get; set; }
        /// <summary>
        /// 核准人
        /// </summary>
        public string Authorizer { get; set; }
        /// <summary>
        /// 批准人
        /// </summary>
        public string Approver { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Others { get; set; }
        /// <summary>
        /// 所属项目显示
        /// </summary>
        public string Department { get; set; }

        //public virtual ProjectBasedata ProjectBasedata { get; set; }


    }

}
