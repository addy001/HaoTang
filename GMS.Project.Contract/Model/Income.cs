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
    [Table("Income")]
    public class Income : ModelBase
    {
        public Income()
        {
            //Materials = new HashSet<Material>();
        }

        #region Model
       
        /// <summary>
        /// 应收款单号
        /// </summary>
        public string RecID { get; set; }
        /// <summary>
        /// 应收款类型
        /// </summary>
        public string RecType { get; set; }
        /// <summary>
        /// 应收款金额
        /// </summary>
        public string RecTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 应收款对象
        /// </summary>
        public string RecObject { get; set; }
        /// <summary>
        /// 应收款日期
        /// </summary>
        public DateTime? RecTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Aging { get; set; }
        /// <summary>
        /// 是否已收
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ContractID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ProjectBasedataID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }      
        #endregion Model
    }

    /// <summary>
    /// 级别
    /// </summary>
    public enum EnumRecType
    {
        [EnumTitle("项目应收款")]
        Project = 1,

        [EnumTitle("公司应收款")]
        Company = 2
    }

    /// <summary>
    /// 分类
    /// </summary>
    //public enum EnumStatus
    //{
    //    [EnumTitle("是")]
    //    Yes = 1,

    //    [EnumTitle("否")]
    //    No = 2
    //}
}
