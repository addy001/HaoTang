using GMS.Project.Contract;
using GMS.Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;
using GMS.Framework.Utility;
using GMS.Framework.Contract;

namespace GMS.Project.BLL
{
    public class ProjectService : IProjectService
    {
        #region ProjectBasedata CURD
        public ProjectBasedata GetProjectBasedata(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<ProjectBasedata>(id);
            }
        }

        public IEnumerable<ProjectBasedata> GetProjectBasedataList(ProjectRequest request = null)
        {
            request = request ?? new ProjectRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<ProjectBasedata> ProjectBasedatas = dbContext.ProjectBasedatas;

                if (!string.IsNullOrEmpty(request.PName))
                    ProjectBasedatas = ProjectBasedatas.Where(u => u.PName.Contains(request.PName));

                return ProjectBasedatas.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);


            }
        }

        public void SaveProjectBasedata(ProjectBasedata project)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (project.ID>0)
                {
                    dbContext.Update<ProjectBasedata>(project);
                }
                else
                {
                    dbContext.Insert<ProjectBasedata>(project);
                }
            }
        }

        public void DeleteProjectBasedata(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.ProjectBasedatas.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion

        #region Budget CURD
        public BudgetInfo GetBudget(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<BudgetInfo>(id);
            }
        }

        public IEnumerable<BudgetInfo> GetBudgetList(BudgetRequest request = null)
        {
            request = request ?? new BudgetRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<BudgetInfo> Budgets = dbContext.Budgets.Include("LaborCost").Include("Overhead").Include("MachineryCost").Include("MaterialCost").Include("Measure");              
                if (!string.IsNullOrEmpty(request.ProjectName))
                    Budgets = Budgets.Where(u => u.ProjectName.Contains(request.ProjectName));                  
                return Budgets.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveBudget(BudgetInfo budget)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (budget.ID >0)
                {
                    dbContext.Update<BudgetInfo>(budget);
                }
                else
                {
                    dbContext.Insert<BudgetInfo>(budget);
                }
            }
        }

        public void DeleteBudget(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.Budgets.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region LaborCost CURD
        public LaborCost GetLaborCost(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<LaborCost>(id);
            }
        }

        public IEnumerable<LaborCost> GetLaborCostList(LaborCostRequest request = null)
        {
            request = request ?? new LaborCostRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<LaborCost> LaborCost = dbContext.LaborCosts;

                if (!string.IsNullOrEmpty(request.ProjectName))
                    LaborCost = LaborCost.Where(u => u.ProjectName.Contains(request.ProjectName));

                return LaborCost.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveLaborCost(LaborCost laborcost)
        {
            using (var dbContext = new ProjectDbContext())
            {
               
            

                if (laborcost.ID >0)
                {
                    var budgets = dbContext.Budgets.ToList();
                    if (laborcost.LaborTotal > 0)
                    {
                        foreach (var budget in budgets)
                        {
                            if (budget.ProjectID == laborcost.ProjectID)
                            {
                                budget.LaborCostID = laborcost.ID;
                                dbContext.Update<BudgetInfo>(budget);
                            }
                        }
                    }
                    dbContext.Update<LaborCost>(laborcost);
                }
                else
                {
                    dbContext.Insert<LaborCost>(laborcost);
                }
            }
        }

        public void DeleteLaborCost(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.LaborCosts.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region MaterialCost CURD
        public MaterialCost GetMaterialCost(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<MaterialCost>(id);
            }
        }

        public IEnumerable<MaterialCost> GetMaterialCostList(MaterialCostRequest request = null)
        {
            request = request ?? new MaterialCostRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<MaterialCost> MaterialCost = dbContext.MaterialCosts;

                if (!string.IsNullOrEmpty(request.ProjectName))
                    MaterialCost = MaterialCost.Where(u => u.ProjectName.Contains(request.ProjectName));

                return MaterialCost.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveMaterialCost(MaterialCost materialcost)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (materialcost.ID >0)
                {
                    var budgets = dbContext.Budgets.ToList();
                    if (materialcost.MaterialTotal > 0)
                    {
                        foreach (var budget in budgets)
                        {
                            if (budget.ProjectID == materialcost.ProjectID)
                            {
                                budget.MaterialCostID = materialcost.ID;
                                dbContext.Update<BudgetInfo>(budget);
                            }
                        }
                    }

                    dbContext.Update<MaterialCost>(materialcost);
                }
                else
                {
                    dbContext.Insert<MaterialCost>(materialcost);
                }
            }
        }

        public void DeleteMaterialCost(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.MaterialCosts.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region MachineryCost CURD
        public MachineryCost GetMachineryCost(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<MachineryCost>(id);
            }
        }

        public IEnumerable<MachineryCost> GetMachineryCostList(MachineryCostRequest request = null)
        {
            request = request ?? new MachineryCostRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<MachineryCost> MachineryCost = dbContext.MachineryCosts;

                if (!string.IsNullOrEmpty(request.ProjectName))
                    MachineryCost = MachineryCost.Where(u => u.ProjectName.Contains(request.ProjectName));

                return MachineryCost.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveMachineryCost(MachineryCost machinerycost)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (machinerycost.ID >0)
                {
                    var budgets = dbContext.Budgets.ToList();
                    if (machinerycost.MachineryTotal > 0)
                    {
                        foreach (var budget in budgets)
                        {
                            if (budget.ProjectID == machinerycost.ProjectID)
                            {
                                budget.MachineryCostID = machinerycost.ID;
                                dbContext.Update<BudgetInfo>(budget);
                            }
                        }
                    }
                    dbContext.Update<MachineryCost>(machinerycost);
                }
                else
                {
                    dbContext.Insert<MachineryCost>(machinerycost);
                }
            }
        }

        public void DeleteMachineryCost(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.MachineryCosts.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region Measure CURD
        public Measure GetMeasure(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<Measure>(id);
            }
        }

        public IEnumerable<Measure> GetMeasureList(MeasureRequest request = null)
        {
            request = request ?? new MeasureRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<Measure> Measure = dbContext.Measures;

                if (!string.IsNullOrEmpty(request.ProjectName))
                    Measure = Measure.Where(u => u.ProjectName.Contains(request.ProjectName));

                return Measure.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveMeasure(Measure measure)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (measure.ID >0)
                {
                    var budgets = dbContext.Budgets.ToList();
                    if (measure.MeasureTotal > 0)
                    {
                        foreach (var budget in budgets)
                        {
                            if (budget.ProjectID == measure.ProjectID)
                            {
                                budget.MeasureID = measure.ID;
                                dbContext.Update<BudgetInfo>(budget);
                            }
                        }
                    }
                    dbContext.Update<Measure>(measure);
                }
                else
                {
                    dbContext.Insert<Measure>(measure);
                }
            }
        }

        public void DeleteMeasure(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.MachineryCosts.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region Overhead CURD
        public Overhead GetOverhead(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<Overhead>(id);
            }
        }

        public IEnumerable<Overhead> GetOverheadList(OverheadRequest request = null)
        {
            request = request ?? new OverheadRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<Overhead> Overhead = dbContext.Overheads;

                if (!string.IsNullOrEmpty(request.ProjectName))
                    Overhead = Overhead.Where(u => u.ProjectName.Contains(request.ProjectName));

                return Overhead.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveOverhead(Overhead overhead)
        {
            using (var dbContext = new ProjectDbContext())
            {
                var budgets = dbContext.Budgets.ToList();

                if (overhead.ID>0)
                {
                    if (overhead.OverheadTotal > 0)
                    {
                        foreach (var budget in budgets)
                        {
                            if (budget.ProjectID == overhead.ProjectID)
                            {
                                budget.OverheadID = overhead.ID;
                                dbContext.Update<BudgetInfo>(budget);
                            }
                        }
                    }
                    dbContext.Update<Overhead>(overhead);
                }
                else
                {
                    dbContext.Insert<Overhead>(overhead);
                }
            }
        }

        public void DeleteOverhead(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.Overheads.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion

        #region  Accountant CURD
        public Accountant GetAccount(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<Accountant>(id);
            }
        }

        public IEnumerable<Accountant> GetAccountantList(AccountantRequest request = null)
        {
            request = request ?? new AccountantRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<Accountant> Accountant = dbContext.Accountants;

                if (!string.IsNullOrEmpty(request.Name))
                    Accountant = Accountant.Where(u => u.Name.Contains(request.Name));

                return Accountant.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveAccountant(Accountant account)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (account.ID > 0)
                {

                    dbContext.Update<Accountant>(account);
                }
                else
                {
                    dbContext.Insert<Accountant>(account);
                }
            }
        }

        public void DeleteAccountant(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.Accountants.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region  Accounting CURD
        public Accounting GetAccounting(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<Accounting>(id);
            }
        }

        public IEnumerable<Accounting> GetAccountingList(AccountingRequest request = null)
        {
            request = request ?? new AccountingRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<Accounting> Accounting = dbContext.Accountings;

                if (!string.IsNullOrEmpty(request.Name))
                    Accounting = Accounting.Where(u => u.Name.Contains(request.Name));

                return Accounting.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveAccounting(Accounting accounting)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (accounting.ID > 0)
                {

                    dbContext.Update<Accounting>(accounting);
                }
                else
                {
                    dbContext.Insert<Accounting>(accounting);
                }
            }
        }

        public void DeleteAccounting(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.Accountings.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        //------------------------------------------即时管理--------------------------------------


        #region InsBudgetInfo CURD
        public InsBudgetInfo GetInsBudget(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<InsBudgetInfo>(id);
            }
        }

        public IEnumerable<InsBudgetInfo> GetInsBudgetList(InsBudgetRequest request = null)
        {
            request = request ?? new InsBudgetRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<InsBudgetInfo> InsBudgetInfos = dbContext.InsBudgetInfos.Include("InsLaborCost").Include("InsOverhead").Include("InsMachineryCost").Include("InsMaterialCost").Include("InsMeasure");
                if (!string.IsNullOrEmpty(request.ProjectName))
                    InsBudgetInfos = InsBudgetInfos.Where(u => u.ProjectName.Contains(request.ProjectName));
                return InsBudgetInfos.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveInsBudget(InsBudgetInfo insbudget)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (insbudget.ID > 0)
                {
                    dbContext.Update<InsBudgetInfo>(insbudget);
                }
                else
                {
                    dbContext.Insert<InsBudgetInfo>(insbudget);
                }
            }
        }

        public void DeleteInsBudget(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.InsBudgetInfos.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region InsLaborCost CURD
        public InsLaborCost GetInsLaborCost(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<InsLaborCost>(id);
            }
        }

        public IEnumerable<InsLaborCost> GetInsLaborCostList(InsLaborCostRequest request = null)
        {
            request = request ?? new InsLaborCostRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<InsLaborCost> InsLaborCost = dbContext.InsLaborCosts.Include("ProjectBasedata") ;
               
                //if (!string.IsNullOrEmpty(request.ProjectBasedataID))
                    if (request.ProjectBasedataID>0)
                    InsLaborCost = InsLaborCost.Where(d => d.ProjectBasedataID == request.ProjectBasedataID);
                
                return InsLaborCost.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveInsLaborCost(InsLaborCost inslaborcost)
        {
            using (var dbContext = new ProjectDbContext())         
            {
                if (inslaborcost.ID > 0)
                {
                    //var budgets = dbContext.Budgets.ToList();
                    //if (inslaborcost.LaborTotal > 0)
                    //{
                    //    foreach (var budget in budgets)
                    //    {
                    //        if (budget.ProjectID == inslaborcost.ProjectID)
                    //        {
                    //            budget.LaborCostID = inslaborcost.ID;
                    //            dbContext.Update<BudgetInfo>(budget);
                    //        }
                    //    }
                    //}
                    dbContext.Update<InsLaborCost>(inslaborcost);
                }
                else
                {
                    dbContext.Insert<InsLaborCost>(inslaborcost);
                }
            }
        }

        public void DeleteInsLaborCost(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.InsLaborCosts.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region InsMaterialCost CURD
        public InsMaterialCost GetInsMaterialCost(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<InsMaterialCost>(id);
            }
        }

        public IEnumerable<InsMaterialCost> GetInsMaterialCostList(InsMaterialCostRequest request = null)
        {
            request = request ?? new InsMaterialCostRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<InsMaterialCost> InsMaterialCost = dbContext.InsMaterialCosts;

                if (!string.IsNullOrEmpty(request.ProjectName))
                    InsMaterialCost = InsMaterialCost.Where(u => u.ProjectName.Contains(request.ProjectName));

                return InsMaterialCost.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveInsMaterialCost(InsMaterialCost insmaterialcost)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (insmaterialcost.ID > 0)
                {
                    //var budgets = dbContext.Budgets.ToList();
                    //if (insmaterialcost.MaterialTotal > 0)
                    //{
                    //    foreach (var budget in budgets)
                    //    {
                    //        if (budget.ProjectID == insmaterialcost.ProjectID)
                    //        {
                    //            budget.MaterialCostID = insmaterialcost.ID;
                    //            dbContext.Update<BudgetInfo>(budget);
                    //        }
                    //    }
                    //}

                    dbContext.Update<InsMaterialCost>(insmaterialcost);
                }
                else
                {
                    dbContext.Insert<InsMaterialCost>(insmaterialcost);
                }
            }
        }

        public void DeleteInsMaterialCost(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.InsMaterialCosts.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region InsMachineryCost CURD
        public InsMachineryCost GetInsMachineryCost(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<InsMachineryCost>(id);
            }
        }

        public IEnumerable<InsMachineryCost> GetInsMachineryCostList(InsMachineryCostRequest request = null)
        {
            request = request ?? new InsMachineryCostRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<InsMachineryCost> InsMachineryCost = dbContext.InsMachineryCosts;

                if (!string.IsNullOrEmpty(request.ProjectName))
                    InsMachineryCost = InsMachineryCost.Where(u => u.ProjectName.Contains(request.ProjectName));

                return InsMachineryCost.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveInsMachineryCost(InsMachineryCost insmachinerycost)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (insmachinerycost.ID > 0)
                {
                    //var budgets = dbContext.Budgets.ToList();
                    //if (machinerycost.MachineryTotal > 0)
                    //{
                    //    foreach (var budget in budgets)
                    //    {
                    //        if (budget.ProjectID == machinerycost.ProjectID)
                    //        {
                    //            budget.MachineryCostID = machinerycost.ID;
                    //            dbContext.Update<BudgetInfo>(budget);
                    //        }
                    //    }
                    //}
                    dbContext.Update<InsMachineryCost>(insmachinerycost);
                }
                else
                {
                    dbContext.Insert<InsMachineryCost>(insmachinerycost);
                }
            }
        }

        public void DeleteInsMachineryCost(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.InsMachineryCosts.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region InsMeasure CURD
        public InsMeasure GetInsMeasure(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<InsMeasure>(id);
            }
        }

        public IEnumerable<InsMeasure> GetInsMeasureList(InsMeasureRequest request = null)
        {
            request = request ?? new InsMeasureRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<InsMeasure> InsMeasure = dbContext.InsMeasures;

                if (!string.IsNullOrEmpty(request.ProjectName))
                    InsMeasure = InsMeasure.Where(u => u.ProjectName.Contains(request.ProjectName));

                return InsMeasure.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveInsMeasure(InsMeasure insmeasure)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (insmeasure.ID > 0)
                {
                    //var budgets = dbContext.Budgets.ToList();
                    //if (measure.MeasureTotal > 0)
                    //{
                    //    foreach (var budget in budgets)
                    //    {
                    //        if (budget.ProjectID == measure.ProjectID)
                    //        {
                    //            budget.MeasureID = measure.ID;
                    //            dbContext.Update<BudgetInfo>(budget);
                    //        }
                    //    }
                    //}
                    dbContext.Update<InsMeasure>(insmeasure);
                }
                else
                {
                    dbContext.Insert<InsMeasure>(insmeasure);
                }
            }
        }

        public void DeleteInsMeasure(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.InsMachineryCosts.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region InsOverhead CURD
        public InsOverhead GetInsOverhead(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<InsOverhead>(id);
            }
        }

        public IEnumerable<InsOverhead> GetInsOverheadList(InsOverheadRequest request = null)
        {
            request = request ?? new InsOverheadRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<InsOverhead> InsOverhead = dbContext.InsOverheads;

                if (!string.IsNullOrEmpty(request.ProjectName))
                    InsOverhead = InsOverhead.Where(u => u.ProjectName.Contains(request.ProjectName));

                return InsOverhead.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveInsOverhead(InsOverhead insoverhead)
        {
            using (var dbContext = new ProjectDbContext())
            {
                //var budgets = dbContext.Budgets.ToList();

                if (insoverhead.ID > 0)
                {
                //    if (overhead.OverheadTotal > 0)
                //    {
                //        foreach (var budget in budgets)
                //        {
                //            if (budget.ProjectID == overhead.ProjectID)
                //            {
                //                budget.OverheadID = overhead.ID;
                //                dbContext.Update<BudgetInfo>(budget);
                //            }
                //        }
                //    }
                    dbContext.Update<InsOverhead>(insoverhead);
                }
                else
                {
                    dbContext.Insert<InsOverhead>(insoverhead);
                }
            }
        }

        public void DeleteInsOverhead(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.InsOverheads.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion

        //--------------------------资产管理-----------------------------------
        #region Files CURD
        public Files GetFile(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<Files>(id);
            }
        }

        public IEnumerable<Files> GetFileList(FileRequest request = null)
        {
            request = request ?? new FileRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<Files> files = dbContext.Files;


                if (!string.IsNullOrEmpty(request.Name))
                    files = files.Where(u => u.Name.Contains(request.Name));

               
                if (!string.IsNullOrEmpty(request.Type))
                    files = files.Where(u => u.Type.Contains(request.Type));

                return files.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveFile(Files file)
        {
            using (var dbContext = new ProjectDbContext())
            {
                if (file.ID > 0)
                {
                    dbContext.Update<Files>(file);
                }
                else
                {
                    dbContext.Insert<Files>(file);
                }
            }
        }

        public void DeleteFile(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.Files.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion

        #region Oddments CURD
        public Oddments GetOddments(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<Oddments>(id);
            }
        }

        public IEnumerable<Oddments> GetOddmentsList(OddmentsRequest request = null)
        {
            request = request ?? new OddmentsRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<Oddments> oddments = dbContext.Oddments;


                if (!string.IsNullOrEmpty(request.Name))

                    oddments = oddments.Where(u => u.Name.Contains(request.Name));

                //if (!string.IsNullOrEmpty(request.Toolname))
                //    oddments = oddments.Where(u => u.Toolname.Contains(request.Toolname));

                //if (!string.IsNullOrEmpty(request.obb))
                //    oddments = oddments.Where(u => u.obb.Contains(request.obb));

                //if (!string.IsNullOrEmpty(request.Way))
                //    oddments = oddments.Where(u => u.Way.Contains(request.Way));

                return oddments.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveOddments(Oddments oddments)
        {
            using (var dbContext = new ProjectDbContext())
            {
                if (oddments.ID > 0)
                {
                    dbContext.Update<Oddments>(oddments);
                }
                else
                {
                    dbContext.Insert<Oddments>(oddments);
                }
            }
        }

        public void DeleteOddments(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.Oddments.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


        #region ProjectCtrl CURD
        public ProjectCtrl GetProjectCtrl(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<ProjectCtrl>(id);
            }
        }

        public IEnumerable<ProjectCtrl> GetProjectCtrlList(ProjectCtrlRequest request = null)
        {
            request = request ?? new ProjectCtrlRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<ProjectCtrl> projects = dbContext.ProjectCtrls;


                if (!string.IsNullOrEmpty(request.Name))

                    projects = projects.Where(u => u.Name.Contains(request.Name));

                //if (!string.IsNullOrEmpty(request.Stuffname))
                //    projects = projects.Where(u => u.Stuffname.Contains(request.Stuffname));

                //if (!string.IsNullOrEmpty(request.obb))
                //    projects = projects.Where(u => u.obb.Contains(request.obb));

                //if (!string.IsNullOrEmpty(request.Way))
                //    projects = projects.Where(u => u.Way.Contains(request.Way));

                return projects.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveProjectCtrl(ProjectCtrl project)
        {
            using (var dbContext = new ProjectDbContext())
            {
                if (project.ID > 0)
                {
                    dbContext.Update<ProjectCtrl>(project);
                }
                else
                {
                    dbContext.Insert<ProjectCtrl>(project);
                }
            }
        }

        public void DeleteProjectCtrl(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.ProjectCtrls.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion

        #region OfficeCtrl CURD
        public OfficeCtrl GetOfficeCtrl(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<OfficeCtrl>(id);
            }
        }

        public IEnumerable<OfficeCtrl> GetOfficeCtrlList(OfficeCtrlRequest request = null)
        {
            request = request ?? new OfficeCtrlRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<OfficeCtrl> offices = dbContext.OfficeCtrls;


                if (!string.IsNullOrEmpty(request.Name))

                    offices = offices.Where(u => u.Name.Contains(request.Name));

                //if (!string.IsNullOrEmpty(request.Toolname))
                //    offices = offices.Where(u => u.Toolname.Contains(request.Toolname));

                //if (!string.IsNullOrEmpty(request.obb))
                //    offices = offices.Where(u => u.obb.Contains(request.obb));

                //if (!string.IsNullOrEmpty(request.Way))
                //    offices = offices.Where(u => u.Way.Contains(request.Way));

                return offices.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveOfficeCtrl(OfficeCtrl offices)
        {
            using (var dbContext = new ProjectDbContext())
            {
                if (offices.ID > 0)
                {
                    dbContext.Update<OfficeCtrl>(offices);
                }
                else
                {
                    dbContext.Insert<OfficeCtrl>(offices);
                }
            }
        }

        public void DeleteOfficeCtrl(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.OfficeCtrls.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion


    }
}
