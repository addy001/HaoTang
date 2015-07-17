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
    [Table("InsBudgetInfo")]
    public class InsBudgetInfo : ModelBase
    {
        public InsBudgetInfo()
        {

        }
        #region Model      
        /// <summary>
        /// 项目Id
        /// </summary>
        public int ProjectBasedataID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "日期不能为空")]
        public string Date { get; set; }
        /// <summary>
        /// 人工费
        /// </summary>
        public int? InsLaborCostID { get; set; }
        /// <summary>
        /// 材料费
        /// </summary>
        public int? InsMaterialCostID { get; set; }
        /// <summary>
        /// 机械使用费
        /// </summary>
        public int? InsMachineryCostID { get; set; }
        /// <summary>
        /// 其他直接费用
        /// </summary>
        public int? InsMeasureID { get; set; }
        /// <summary>
        /// 间接费用
        /// </summary>
        public int? InsOverheadID { get; set; }
        /// <summary>
        /// 工程保修金
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? InsWarranty { get; set; }
        /// <summary>
        /// 分包工程
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? InsSubcontracting { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? InsOtherBudget { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        public int InsBudgetTotal { get; set; }


        public virtual InsLaborCost InsLaborCost { get; set; }
        public virtual InsOverhead InsOverhead { get; set; }
        public virtual InsMachineryCost InsMachineryCost { get; set; }
        public virtual InsMaterialCost InsMaterialCost { get; set; }
        public virtual InsMeasure InsMeasure { get; set; }
        public virtual ProjectBasedata ProjectBasedata { get; set; }
        #endregion Model
    }
}
