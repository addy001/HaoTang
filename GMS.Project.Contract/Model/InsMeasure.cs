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
    [Table("InsMeasure")]
    public class InsMeasure : ModelBase
    {
        public InsMeasure()
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
        /// 水费
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Water
        {
            get;
            set;
        }
        /// <summary>
        /// 电费
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Electric
        {
            get;
            set;
        }
        /// <summary>
        /// 临时生产工具费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? TempTool
        {
            get;
            set;
        }
        /// <summary>
        /// 检测费
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Test
        {
            get;
            set;
        }
        /// <summary>
        /// 质检费
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? QualityCosts
        {
            get;
            set;
        }
        /// <summary>
        /// 文明施工
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Civilization
        {
            get;
            set;
        }
        /// <summary>
        /// 安全工程
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? Secure
        {
            get;
            set;
        }
        /// <summary>
        /// 材料二次搬运
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? SecondHand
        {
            get;
            set;
        }
        /// <summary>
        /// 临时设施摊销费
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? TempFacility
        {
            get;
            set;
        }
        /// <summary>
        /// 其他费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OtherFee
        {
            get;
            set;
        }

        public string Remark { get; set; }

        public int MeasureTotal { get; set; }
        public virtual ProjectBasedata ProjectBasedata { get; set; }

        #endregion Model

    }
}
