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
    [Table("Overhead")]
    public class Overhead : ModelBase
    {
        public Overhead()
        {
        }

        #region Model


        /// <summary>
        /// 项目Id
        /// </summary>
       
        public int ProjectID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [StringLength(100)]
        [Required]
        public string ProjectName { get; set; }
       
		/// <summary>
		/// 现场管理人员工资
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OPay
		{
			 get; set;
		}
		/// <summary>
		/// 奖金
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OBonus
		{
			 get; set;
		}
		/// <summary>
		/// 业务招待费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OEntertainment
		{
			 get; set;
		}
		/// <summary>
		/// 差旅交通费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OTraffic
		{
			 get; set;
		}
		/// <summary>
		/// 车辆费用
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OVehicle
		{
			 get; set;
		}
		/// <summary>
		/// 办公费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OOffice
		{
		 get; set;
		}
		/// <summary>
		/// 福利费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OWelfare
		{
			 get; set;
		}
		/// <summary>
		/// 社会保障费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OSecurity
		{
			 get; set;
		}
		/// <summary>
		/// 危险作业意外伤害保险费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OAccidentInsurance
		{
			 get; set;
		}
		/// <summary>
		/// 住房公积金
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OHousingFund
		{
			 get; set;
		}
		/// <summary>
		/// 伙食费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OMeals
		{
			 get; set;
		}
		/// <summary>
		/// 员工宿舍费用
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OAccommodation
		{
			 get; set;
		}
		/// <summary>
		/// 工会经费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OUnion
		{
			 get; set;
		}
		/// <summary>
		/// 职工教育经费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OEducation
		{
			 get; set;
		}
		/// <summary>
		/// 劳动保险费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OlaborInsurance
		{
			 get; set;
		}
		/// <summary>
		/// 税金
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OFare
		{
		 get; set;
		}
		/// <summary>
		/// 工程排污费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OSewageCharges
		{
			 get; set;
		}
		/// <summary>
		/// 工程定额测定费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OMeasuring
		{
		 get; set;
		}
		/// <summary>
		/// 造价预算费
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OCost
		{
			 get; set;
		}
		/// <summary>
		/// 财务费用
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OFinance
		{
			 get; set;
		}
		/// <summary>
		/// 无形资产摊销
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OInvisible
		{
			 get; set;
		}
		/// <summary>
		/// 其他费用
		/// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? OOther
		{
			 get; set;
		}

        public string Remark { get; set; }

        public int OverheadTotal { get; set; }

		#endregion Model
    }

}