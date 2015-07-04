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
    [Table("Measure")]
    public class Measure : ModelBase
    {
        public Measure()
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
        /// 水费
        /// </summary>
        public int Water
        {
            get;
            set;
        }
        /// <summary>
        /// 电费
        /// </summary>
        public int Electric
        {
            get;
            set;
        }
        /// <summary>
        /// 临时生产工具费用
        /// </summary>
        public int TempTool
        {
            get;
            set;
        }
        /// <summary>
        /// 检测费
        /// </summary>
        public int Test
        {
            get;
            set;
        }
        /// <summary>
        /// 质检费
        /// </summary>
        public int QualityCosts
        {
            get;
            set;
        }
        /// <summary>
        /// 文明施工
        /// </summary>
        public int Civilization
        {
            get;
            set;
        }
        /// <summary>
        /// 安全工程
        /// </summary>
        public int Secure
        {
            get;
            set;
        }
        /// <summary>
        /// 材料二次搬运
        /// </summary>
        public int SecondHand
        {
            get;
            set;
        }
        /// <summary>
        /// 临时设施摊销费
        /// </summary>
        public int TempFacility
        {
            get;
            set;
        }
        /// <summary>
        /// 其他费用
        /// </summary>
        public int OtherFee
        {
            get;
            set;
        }

        public string Remark { get; set; }

        public int MeasureTotal { get; set; }


        #endregion Model

    }
}