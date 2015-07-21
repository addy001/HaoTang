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
		/// 文件名称
		/// </summary>
        [Required]
        [StringLength(300)]
		public string Name{ get; set; }
		/// <summary>
		/// 文件编号
		/// </summary>
		public string Code{ get; set; }
		/// <summary>
		/// 甲方
		/// </summary>
		public string FirstParty{ get; set; }
		/// <summary>
		/// 乙方
		/// </summary>
		public string SecondParty{ get; set; }
		/// <summary>
		/// 合同签订日期
		/// </summary>
		public DateTime? SignDate{ get; set; }
		/// <summary>
		/// 合同履行日期
		/// </summary>
		public DateTime? FulfillDate{ get; set; }
		/// <summary>
		/// 合同结束日期
		/// </summary>
		public DateTime? EndDate{ get; set; }
		/// <summary>
		/// 合同金额
		/// </summary>
		public string Money{ get; set; }
		/// <summary>
		/// 文件类型
		/// </summary>
		public string Type{ get; set; }
		/// <summary>
		/// 附件
		/// </summary>
		public string Accessory{ get; set; }
		
		/// <summary>
		/// 描述
		/// </summary>
		public string Description{ get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark{ get; set; }
    }
	
    /// <summary>
    /// 文档类型
    /// </summary>
    public enum EnumType
    {
        [EnumTitle("对内合同")]
        In = 1,

        [EnumTitle("对外合同")]
        Out = 2,

       [EnumTitle("设计图纸")]
        Draw = 3
    }
    //public enum EnumDrawingType
    //{
    //    [EnumTitle("规划图纸")]
    //    First = 1,

    //    [EnumTitle("电路图纸")]
    //    Second = 2,

    //    [EnumTitle("消防图纸")]
    //    Third = 3
    //}


}

