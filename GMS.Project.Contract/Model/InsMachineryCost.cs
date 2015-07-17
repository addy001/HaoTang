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
    [Table("InsMachineryCost")]
    public class InsMachineryCost : ModelBase
    {
        public InsMachineryCost()
        {
        }

        #region Model
        /// <summary>
        /// 项目Id
        /// </summary>

        public int ProjectBasedataID { get; set; }


       [Required(ErrorMessage = "日期不能为空")]
        public string Date { get; set; }
        /// <summary>
        /// 进退场费
        /// </summary>
       [Display(Name = "进退场费")]
       [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
       public int? Transport { get; set; }
        /// <summary>
        /// 机械人员工资
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
       public int? Operating { get; set; }
        /// <summary>
        /// 修理保养费
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Repair { get; set; }
        /// <summary>
        /// 燃油费
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Fuel { get; set; }
        /// <summary>
        ///折旧费
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Depreciation { get; set; }
        /// <summary>
        /// 车船税
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? TravelTax { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OtherFee { get; set; }
       
        /// <summary>d
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 总额
        /// </summary>
        public int MachineryTotal { get; set; }
        public virtual ProjectBasedata ProjectBasedata { get; set; }
        #endregion Model
    }
}
