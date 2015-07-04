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
        
        public int ProjectID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [StringLength(100)]
        [Required]
        public string ProjectName { get; set; }       
      
        /// <summary>
        /// 钢材
        /// </summary>
        public int MSteel
        {
            get;
            set;
        }
        /// <summary>
        /// 朔料管件及配件
        /// </summary>
        public int MHose
        {
            get;
            set;
        }
        /// <summary>
        /// 水泥及制品
        /// </summary>
        public int MCement
        {
            get;
            set;
        }
        /// <summary>
        /// 灰油
        /// </summary>
        public int MGrayOil
        {
            get;
            set;
        }
        /// <summary>
        /// 电线电缆
        /// </summary>
        public int MWire
        {
            get;
            set;
        }
        /// <summary>
        /// 木竹及制品
        /// </summary>
        public int MWood
        {
            get;
            set;
        }
        /// <summary>
        /// 瓷砖类
        /// </summary>
        public int MCeramicTile
        {
            get;
            set;
        }
        /// <summary>
        /// 门窗型材及配件类
        /// </summary>
        public int MWindowsDoors
        {
            get;
            set;
        }
        /// <summary>
        /// 玻璃及配件
        /// </summary>
        public int MGalss
        {
            get;
            set;
        }
        /// <summary>
        /// 零星五金类
        /// </summary>
        public int MHardware
        {
            get;
            set;
        }
        /// <summary>
        /// 电气及配件
        /// </summary>
        public int MElectric
        {
            get;
            set;
        }
        /// <summary>
        /// 混凝土
        /// </summary>
        public int MConcrete
        {
            get;
            set;
        }
        /// <summary>
        /// 砖
        /// </summary>
        public int MBrick
        {
            get;
            set;
        }
        /// <summary>
        /// 模板
        /// </summary>
        public int MTemplate
        {
            get;
            set;
        }
        /// <summary>
        /// 铝材
        /// </summary>
        public int MAluminum
        {
            get;
            set;
        }
        /// <summary>
        /// 材料检测费
        /// </summary>
        public int MTest
        {
            get;
            set;
        }
        /// <summary>
        /// 砂浆王
        /// </summary>
        public int MMortar
        {
            get;
            set;
        }
        /// <summary>
        /// 消防、通风、排烟
        /// </summary>
        public int MFireAirSmoke
        {
            get;
            set;
        }
        /// <summary>
        /// 周转材料租赁
        /// </summary>
        public int MTurnoverRent
        {
            get;
            set;
        }
        /// <summary>
        /// 周转材料摊销
        /// </summary>
        public int MTurnovers
        {
            get;
            set;
        }
        /// <summary>
        /// 其他材料费用
        /// </summary>
        public int MOther
        {
            get;
            set;
        }

        public string Remark { get; set; }

        public int MaterialTotal { get; set; }

        #endregion Model
    }
        
}
