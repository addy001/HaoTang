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
        public int OPay
		{
			 get; set;
		}
		/// <summary>
		/// 奖金
		/// </summary>
        public int OBonus
		{
			 get; set;
		}
		/// <summary>
		/// 业务招待费
		/// </summary>
        public int OEntertainment
		{
			 get; set;
		}
		/// <summary>
		/// 差旅交通费
		/// </summary>
        public int OTraffic
		{
			 get; set;
		}
		/// <summary>
		/// 车辆费用
		/// </summary>
        public int OVehicle
		{
			 get; set;
		}
		/// <summary>
		/// 办公费
		/// </summary>
        public int OOffice
		{
		 get; set;
		}
		/// <summary>
		/// 福利费
		/// </summary>
        public int OWelfare
		{
			 get; set;
		}
		/// <summary>
		/// 社会保障费
		/// </summary>
        public int OSecurity
		{
			 get; set;
		}
		/// <summary>
		/// 危险作业意外伤害保险费
		/// </summary>
        public int OAccidentInsurance
		{
			 get; set;
		}
		/// <summary>
		/// 住房公积金
		/// </summary>
        public int OHousingFund
		{
			 get; set;
		}
		/// <summary>
		/// 伙食费
		/// </summary>
        public int OMeals
		{
			 get; set;
		}
		/// <summary>
		/// 员工宿舍费用
		/// </summary>
        public int OAccommodation
		{
			 get; set;
		}
		/// <summary>
		/// 工会经费
		/// </summary>
        public int OUnion
		{
			 get; set;
		}
		/// <summary>
		/// 职工教育经费
		/// </summary>
        public int OEducation
		{
			 get; set;
		}
		/// <summary>
		/// 劳动保险费
		/// </summary>
        public int OlaborInsurance
		{
			 get; set;
		}
		/// <summary>
		/// 税金
		/// </summary>
        public int OFare
		{
		 get; set;
		}
		/// <summary>
		/// 工程排污费
		/// </summary>
        public int OSewageCharges
		{
			 get; set;
		}
		/// <summary>
		/// 工程定额测定费
		/// </summary>
        public int OMeasuring
		{
		 get; set;
		}
		/// <summary>
		/// 造价预算费
		/// </summary>
        public int OCost
		{
			 get; set;
		}
		/// <summary>
		/// 财务费用
		/// </summary>
        public int OFinance
		{
			 get; set;
		}
		/// <summary>
		/// 无形资产摊销
		/// </summary>
        public int OInvisible
		{
			 get; set;
		}
		/// <summary>
		/// 其他费用
		/// </summary>
        public int OOther
		{
			 get; set;
		}

        public string Remark { get; set; }

        public int OverheadTotal { get; set; }

		#endregion Model
    }

}