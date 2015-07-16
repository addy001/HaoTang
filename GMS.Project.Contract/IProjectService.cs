using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;
using GMS.Project.Contract;

namespace GMS.Project.Contract
{
    public interface IProjectService
    {

        ProjectBasedata GetProjectBasedata(int id);
        IEnumerable<ProjectBasedata> GetProjectBasedataList(ProjectRequest request = null);
        void SaveProjectBasedata(ProjectBasedata project);
        void DeleteProjectBasedata(List<int> ids);



        BudgetInfo GetBudget(int id);
        IEnumerable<BudgetInfo> GetBudgetList(BudgetRequest request = null);
        void SaveBudget(BudgetInfo project);
        void DeleteBudget(List<int> ids);

         //人工费
        LaborCost GetLaborCost(int id);
        IEnumerable<LaborCost> GetLaborCostList(LaborCostRequest request = null);
        void SaveLaborCost(LaborCost project);
        void DeleteLaborCost(List<int> ids);
        
        //材料费
        MaterialCost GetMaterialCost(int id);
        IEnumerable<MaterialCost> GetMaterialCostList(MaterialCostRequest request = null);
        void SaveMaterialCost(MaterialCost project);
        void DeleteMaterialCost(List<int> ids);

        //机械费
        MachineryCost GetMachineryCost(int id);
        IEnumerable<MachineryCost> GetMachineryCostList(MachineryCostRequest request = null);
        void SaveMachineryCost(MachineryCost project);
        void DeleteMachineryCost(List<int> ids);

        //措施费
        Measure GetMeasure(int id);
        IEnumerable<Measure> GetMeasureList(MeasureRequest request = null);
        void SaveMeasure(Measure project);
        void DeleteMeasure(List<int> ids);


        //间接费用
        Overhead GetOverhead(int id);
        IEnumerable<Overhead> GetOverheadList(OverheadRequest request = null);
        void SaveOverhead(Overhead project);
        void DeleteOverhead(List<int> ids);


        //会计科目大类 
        Accountant GetAccount(int id);
        IEnumerable<Accountant> GetAccountantList(AccountantRequest request = null);
        void SaveAccountant(Accountant account);
        void DeleteAccountant(List<int> ids);


        //会计科目
        Accounting GetAccounting(int id);
        IEnumerable<Accounting> GetAccountingList(AccountingRequest request = null);
        void SaveAccounting(Accounting accounting);
        void DeleteAccounting(List<int> ids);


        //-----------------------------即时管理------------------------------------------
        InsBudgetInfo GetInsBudget(int id);
        IEnumerable<InsBudgetInfo> GetInsBudgetList(InsBudgetRequest request = null);
        void SaveInsBudget(InsBudgetInfo project);
        void DeleteInsBudget(List<int> ids);


        //人工费
        InsLaborCost GetInsLaborCost(int id);
        IEnumerable<InsLaborCost> GetInsLaborCostList(InsLaborCostRequest request = null);
        void SaveInsLaborCost(InsLaborCost project);
        void DeleteInsLaborCost(List<int> ids);

        //材料费
        InsMaterialCost GetInsMaterialCost(int id);
        IEnumerable<InsMaterialCost> GetInsMaterialCostList(InsMaterialCostRequest request = null);
        void SaveInsMaterialCost(InsMaterialCost project);
        void DeleteInsMaterialCost(List<int> ids);

        //机械费
        InsMachineryCost GetInsMachineryCost(int id);
        IEnumerable<InsMachineryCost> GetInsMachineryCostList(InsMachineryCostRequest request = null);
        void SaveInsMachineryCost(InsMachineryCost project);
        void DeleteInsMachineryCost(List<int> ids);

        //措施费
        InsMeasure GetInsMeasure(int id);
        IEnumerable<InsMeasure> GetInsMeasureList(InsMeasureRequest request = null);
        void SaveInsMeasure(InsMeasure project);
        void DeleteInsMeasure(List<int> ids);


        //间接费用
        InsOverhead GetInsOverhead(int id);
        IEnumerable<InsOverhead> GetInsOverheadList(InsOverheadRequest request = null);
        void SaveInsOverhead(InsOverhead project);
        void DeleteInsOverhead(List<int> ids);

        //-----------资产管理------------------

        Files GetFile(int id);
        IEnumerable<Files> GetFileList(FileRequest request = null);
        void SaveFile(Files file);
        void DeleteFile(List<int> ids);


        Oddments GetOddments(int id);
        IEnumerable<Oddments> GetOddmentsList(OddmentsRequest request = null);
        void SaveOddments(Oddments office);
        void DeleteOddments(List<int> ids);


        ProjectCtrl GetProjectCtrl(int id);
        IEnumerable<ProjectCtrl> GetProjectCtrlList(ProjectCtrlRequest request = null);
        void SaveProjectCtrl(ProjectCtrl project);
        void DeleteProjectCtrl(List<int> ids);

        OfficeCtrl GetOfficeCtrl(int id);
        IEnumerable<OfficeCtrl> GetOfficeCtrlList(OfficeCtrlRequest request = null);
        void SaveOfficeCtrl(OfficeCtrl office);
        void DeleteOfficeCtrl(List<int> ids);
       
 
    }
}
