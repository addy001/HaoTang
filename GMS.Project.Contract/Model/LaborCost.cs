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
    [Table("LaborCost")]
    public class LaborCost : ModelBase
    {
        public LaborCost()
        {
            
        }

        #region Model

       
        /// <summary>
        /// 项目Id
        /// </summary>
        //[StringLength(100)]
        //[Required]
        public int ProjectID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 泥瓦工费用
        /// </summary>
        public int? Masons { get; set; }
        /// <summary>
        /// 拆除人工费用
        /// </summary>
        public int? TearDown { get; set; }
        /// <summary>
        /// 木工费用
        /// </summary>
        public int? Carpenter { get; set; }
        /// <summary>
        /// 水电工费用
        /// </summary>
        public int? Plumbers { get; set; }
        /// <summary>
        /// 油漆工费用
        /// </summary>
        public int? Painter { get; set; }
        /// <summary>
        /// 电焊工费用
        /// </summary>
        public int? ELectricWelder { get; set; }
        /// <summary>
        /// 钢筋工费用
        /// </summary>
        public int? Steel { get; set; }
        /// <summary>
        /// 搬运工费用
        /// </summary>
        public int? Transportor { get; set; }
        /// <summary>
        /// 垃圾清理工费
        /// </summary>
        public int? Cleaner { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public int? OtherLabor { get; set; }
        /// <summary>
        /// 其他费用说明
        /// </summary>
        public string OtherDetail { get; set; }

        public int LaborTotal { get; set; }     
      
        #endregion Model
        //public  int LaborTotal
        //{
            //get
            //{
            //    int total = 0;
            //    var labor=new LaborCost();
            //    foreach (PropertyInfo p in labor.GetType().GetProperties())
            //    {
            //        if (p.PropertyType.ToString() == "System.Int32")
            //        total += (int)p.GetValue(labor, null);
 
            //    }
            //    return total;
                
            //}
            

        //}

        //public PropertyInfo[] GetPropertyInfoArray()
        //{
        //    PropertyInfo[] props = null;
        //    var lt=0;
        //    try
        //    {
        //        Type type = typeof(LaborCost);
        //        object obj = Activator.CreateInstance(type);
        //        props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    }
        //    catch (Exception ex)
        //    { }          
        //    return props;
        //}

    }

   
}