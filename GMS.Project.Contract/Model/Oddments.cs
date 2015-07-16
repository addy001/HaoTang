using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GMS.Framework.Contract;

namespace GMS.Project.Contract
{
    [Serializable]
    [Table("Oddments")]
    public class Oddments : ModelBase
    {
        public Oddments()
        {
 
        }
        /// <summary>
        /// 余料名称
        /// </summary>
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Toolname { get; set; }
        /// <summary>
        /// 当前价值
        /// </summary>
        public string obb { get; set; }
        /// <summary>
        /// 折旧率
        /// </summary>
        public string Way { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string ChangTime { get; set; }
        /// <summary>
        /// 折旧损耗价值
        /// </summary>
        public string Discount { get; set; }
    }
}
