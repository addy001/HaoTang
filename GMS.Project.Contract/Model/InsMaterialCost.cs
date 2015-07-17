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
    [Table("InsMaterialCost")]
    public class InsMaterialCost : ModelBase
    {
        public InsMaterialCost()
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
        /// 钢材
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MSteel
        {
            get;
            set;
        }
        /// <summary>
        /// 朔料管件及配件
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MHose
        {
            get;
            set;
        }
        /// <summary>
        /// 水泥及制品
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MCement
        {
            get;
            set;
        }
        /// <summary>
        /// 灰油
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MGrayOil
        {
            get;
            set;
        }
        /// <summary>
        /// 电线电缆
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MWire
        {
            get;
            set;
        }
        /// <summary>
        /// 木竹及制品
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MWood
        {
            get;
            set;
        }
        /// <summary>
        /// 瓷砖类
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MCeramicTile
        {
            get;
            set;
        }
        /// <summary>
        /// 门窗型材及配件类
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MWindowsDoors
        {
            get;
            set;
        }
        /// <summary>
        /// 玻璃及配件
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MGalss
        {
            get;
            set;
        }
        /// <summary>
        /// 零星五金类
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MHardware
        {
            get;
            set;
        }
        /// <summary>
        /// 电气及配件
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MElectric
        {
            get;
            set;
        }
        /// <summary>
        /// 混凝土
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MConcrete
        {
            get;
            set;
        }
        /// <summary>
        /// 砖
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MBrick
        {
            get;
            set;
        }
        /// <summary>
        /// 模板
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MTemplate
        {
            get;
            set;
        }
        /// <summary>
        /// 铝材
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MAluminum
        {
            get;
            set;
        }
        /// <summary>
        /// 材料检测费
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MTest
        {
            get;
            set;
        }
        /// <summary>
        /// 砂浆王
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MMortar
        {
            get;
            set;
        }
        /// <summary>
        /// 消防、通风、排烟
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MFireAirSmoke
        {
            get;
            set;
        }
        /// <summary>
        /// 周转材料租赁
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MTurnoverRent
        {
            get;
            set;
        }
        /// <summary>
        /// 周转材料摊销
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MTurnovers
        {
            get;
            set;
        }
        /// <summary>
        /// 其他材料费用
        /// </summary>
        [RegularExpression(@"[1-9]\d*", ErrorMessage = "请输入正整数")]
        public int? MOther
        {
            get;
            set;
        }

        public string Remark { get; set; }

        public int MaterialTotal { get; set; }
        public virtual ProjectBasedata ProjectBasedata { get; set; }
        #endregion Model
    }
        
}
