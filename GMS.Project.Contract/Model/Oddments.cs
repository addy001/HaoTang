using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GMS.Framework.Contract;
using GMS.Framework.Utility;

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
        /// <summary>
        /// 材料类型
        /// </summary>
        public string OType { get; set; }

        /// <summary>
        /// 当前项目
        /// </summary>
        public int ProjectBasedataID { get; set; }
        public virtual ProjectBasedata ProjectBasedata { get; set; }
       
    }
    public enum EnumOType
    {
        [EnumTitle("材料一")]
        one = 1,

        [EnumTitle("材料二")]
        two = 2,

        [EnumTitle("材料三")]
        three = 3
    }
}
