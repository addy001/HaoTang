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
    [Table("Files")]
    public class Files : ModelBase
    {
        public  Files()
        {
        }
        /// <summary>
        /// 文档名称
        /// </summary>
        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        /// <summary>
        /// 文件编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 文档类型
        /// </summary>
        public string Type { get; set; }
      
        /// <summary>
        /// 附件
        /// </summary>
        public string Accessory { get; set; }

        /// <summary>
        /// 描述
        /// </summary>

        public string Description { get; set; }
       
    }
    /// <summary>
    /// 文档类型
    /// </summary>
    public enum EnumType
    {
        [EnumTitle("对内合同")]
        Tel = 1,

        [EnumTitle("对外合同")]
        Visit = 2
    }
}
