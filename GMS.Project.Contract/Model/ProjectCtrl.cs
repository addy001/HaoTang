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
        /// 材料名称
        /// </summary>
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string oddnum { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public double obb { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string Way { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Stuffname { get; set; }
        /// <summary>
        /// 所属项目显示
        /// </summary>
        public int ProjectBasedataID { get; set; }

        public virtual ProjectBasedata ProjectBasedata { get; set; }


    }

}
