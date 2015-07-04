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
    [Table("BudgetInfo")]
    public class BudgetInfo : ModelBase
    {
        public BudgetInfo()
        {
           
        }

        #region Model

        //public new Guid ID { get; set; }
      
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
        /// 人工费
        /// </summary>
        public int? LaborCostID { get; set; }
       


        
        /// <summary>
        /// 材料费
        /// </summary>
        public int? MaterialCostID { get; set; }
        /// <summary>
        /// 机械使用费
        /// </summary>
        public int? MachineryCostID { get; set; }
        /// <summary>
        /// 其他直接费用
        /// </summary>
        public int? MeasureID { get; set; }
        /// <summary>
        /// 间接费用
        /// </summary>
        public int? OverheadID { get; set; }
        /// <summary>
        /// 工程保修金
        /// </summary>
        public int Warranty { get; set; }
        /// <summary>
        /// 分包工程
        /// </summary>
        public int Subcontracting { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public int OtherBudget { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public int BudgetTotal { get; set; }

        //public   List<LaborCost> Labour
        //{ 
        //    get 
        //    {
        //        var labor = new List<LaborCost>();
        //        foreach(var ProjectName in labor )
        //        {
        //            return labor.Single(ProjectName);
        //        }
        //    //return   labor = labor.Where(u => u.ProjectName.SingleOrDefault(this.ProjectName));
        
        //     } 
        //}
        //public virtual List<MaterialCost> Material { get; set; }
        //public virtual List<MachineryCost> MachineryCost { get; set; }
        //public virtual List<Measure> Measure { get; set; }
        //public virtual List<Overhead> Overhead { get; set; }

        public virtual LaborCost LaborCost { get; set; }
        public virtual Overhead Overhead { get; set; }
        public virtual MachineryCost MachineryCost { get; set; }
        public virtual MaterialCost MaterialCost { get; set; }
        public virtual Measure Measure { get; set; }
     

        #endregion Model
    }


   

}