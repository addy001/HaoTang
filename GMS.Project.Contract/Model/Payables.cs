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
    [Table("Payables")]
    public class Payables : ModelBase
    {
        public Payables()
        { }
        #region Model    
        /// <summary>
        /// 应付款单号
        /// </summary>
        public string PID { get; set; }
        /// <summary>
        /// 应付款类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 应付款金额
        /// </summary>
        public string Total { get; set; }
        ///// <summary>
        ///// 采购单号
        ///// </summary>
        public string PurchaseID { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 收款人或者收款单位
        /// </summary>
        public string Receivables { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        #endregion Model
    }

    public enum EnumPtype 
    {
        [EnumTitle("应付单据")]
         Receipt = 1,

        [EnumTitle("应付票据")]
        Ticket = 2,

        [EnumTitle("其他应付款")]
        Remark = 3,
    }
   
}
