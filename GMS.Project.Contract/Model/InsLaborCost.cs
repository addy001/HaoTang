using GMS.Framework.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GMS.Project.Contract
{

    [Serializable]
    [Table("InsLaborCost")]
    public class InsLaborCost : ModelBase
    {
        public InsLaborCost()
        {
            
        }

        #region Model
        /// <summary>
        /// 项目Id
        /// </summary>       
        public int ProjectBasedataID { get; set; }
        /// <summary>
        /// 预算日期

        [Required(ErrorMessage = "日期不能为空")]
        public string Date { get; set; }
       
        /// <summary>
        /// 泥瓦工费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Masons { get; set; }
        /// <summary>
        /// 拆除人工费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? TearDown { get; set; }
        /// <summary>
        /// 木工费用
        /// </summary>
       [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Carpenter { get; set; }
        /// <summary>
        /// 水电工费用
        /// </summary>
        public int? Plumbers { get; set; }
        /// <summary>
        /// 油漆工费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Painter { get; set; }
        /// <summary>
        /// 电焊工费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? ELectricWelder { get; set; }
        /// <summary>
        /// 钢筋工费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Steel { get; set; }
        /// <summary>
        /// 搬运工费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Transportor { get; set; }
        /// <summary>
        /// 垃圾清理工费
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Cleaner { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OtherLabor { get; set; }
        /// <summary>
        /// 其他费用说明
        /// </summary>
        public string Remark { get; set; }

        public int LaborTotal { get; set; }



        public virtual ProjectBasedata ProjectBasedata { get; set; }

       

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var result = new List<ValidationResult>();
        //    if (ProjectBasedataID == 0)
        //    {
        //        result.Add(new ValidationResult("请选择项目"));
        //    }
        //    return result;
        //}
        #endregion Model
    }

   
}