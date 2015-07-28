using GMS.Framework.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Project.Contract
{
    public class ProjectRequest : Request
    {
        public string PName { get; set; }
        public string Status { get; set; }
        public string Fund { get; set; }
    }
    public class BudgetRequest : Request
    {
        public string ProjectName { get; set; }       
    }

    public class LaborCostRequest : Request
    {
        public string ProjectName { get; set; }
    }
    public class MaterialCostRequest : Request
    {
        public string ProjectName { get; set; }
    }
    public class MachineryCostRequest : Request
    {
        public string ProjectName { get; set; }
    }
    public class MeasureRequest : Request
    {
        public string ProjectName { get; set; }
    }
    public class OverheadRequest : Request
    {
        public string ProjectName { get; set; }
    }
    //-----------------------财务管理----------------------------------------------
    public class PayablesRequest : Request
    {
        public string Receivables { get; set; }
       
    }
    public class IncomeRequest : Request
    {
        public string RecObject { get; set; }
        public string Status { get; set; }

    }
    public class AccountingRequest : Request
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
    //--------------------------即时管理-----------------------------------------------------

    public class InsBudgetRequest : Request
    {
        public int ProjectBasedataID { get; set; }
    }


    public class InsLaborCostRequest : Request
    {
        public int ProjectBasedataID { get; set; }
      
    }
    public class InsMaterialCostRequest : Request
    {
        public int ProjectBasedataID { get; set; }
    }
    public class InsMachineryCostRequest : Request
    {
        public int ProjectBasedataID { get; set; }
    }
    public class InsMeasureRequest : Request
    {
        public int ProjectBasedataID { get; set; }
    }
    public class InsOverheadRequest : Request
    {
        public int ProjectBasedataID { get; set; }
    }
    //----------------------------资产管理-------------------------------
    public class FileRequest : Request
    {
        public string Name { get; set; }      
        public string Type { get; set; }
    }

    public class OddmentsRequest : Request
    {
        public string Name { get; set; }
        public string OType { get; set; }
        public int ProjectBasedataID { get; set; }
        
    }
    public class ProjectCtrlRequest : Request
    {
        public string Name { get; set; }
        public string oddnum { get; set; }
        public int ProjectBasedataID { get; set; }

    }
    public class OfficeCtrlRequest : Request
    {
        public string Name { get; set; }
        public string oddnum { get; set; }

    }
    public class OdderRequest : Request
    {
        public string Buyer { get; set; }
        public string oddnum { get; set; }
        //public int ProjectBasedataID { get; set; }

    }
}
