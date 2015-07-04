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
        public string PCharger { get; set; }
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

    public class AccountantRequest : Request
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
    public class AccountingRequest : Request
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
    //--------------------------即时管理-----------------------------------------------------

    public class InsBudgetRequest : Request
    {
        public string ProjectName { get; set; }
    }


    public class InsLaborCostRequest : Request
    {
        public string ProjectName { get; set; }
    }
    public class InsMaterialCostRequest : Request
    {
        public string ProjectName { get; set; }
    }
    public class InsMachineryCostRequest : Request
    {
        public string ProjectName { get; set; }
    }
    public class InsMeasureRequest : Request
    {
        public string ProjectName { get; set; }
    }
    public class InsOverheadRequest : Request
    {
        public string ProjectName { get; set; }
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
        
    }
    public class ProjectCtrlRequest : Request
    {
        public string Name { get; set; }

    }
    public class OfficeCtrlRequest : Request
    {
        public string Name { get; set; }

    }

}
