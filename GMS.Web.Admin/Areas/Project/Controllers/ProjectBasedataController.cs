using GMS.Account.Contract;
using GMS.Project.Contract;
using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Framework.Utility;


namespace GMS.Web.Admin.Areas.Project.Controllers
{
     [Permission(EnumBusinessPermission.ProjectManage_Basedata)]
    public class ProjectBasedataController : AdminControllerBase
    {
        //
        // GET: /Project/ProjectBasedata/

        public ActionResult Index(ProjectRequest request)
        {
            //this.TryUpdateModel<InsLaborCost>(request.InsLaborCost);
            var result = this.ProjectService.GetProjectBasedataList(request);
            return View(result);
        }

        //
        // GET: /Project/ProjectBasedata/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /Project/ProjectBasedata/Create

        public ActionResult Create()
        {
            var model = new ProjectBasedata();
            return View("Edit",model);
        }

        //
        // POST: /Project/ProjectBasedata/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new ProjectBasedata();
            model.PSDate = DateTime.Now.ToString("yyyy/MM/dd");
            model.PEdate = DateTime.Now.ToString("yyyy/MM/dd");
            this.TryUpdateModel<ProjectBasedata>(model);

            this.ProjectService.SaveProjectBasedata(model);

            var labor = new LaborCost();
            labor.ProjectID = model.ID;
            labor.ProjectName = model.PName;
            this.TryUpdateModel<LaborCost>(labor);
            this.ProjectService.SaveLaborCost(labor);

            var material = new MaterialCost();
            material.ProjectID = model.ID;
            material.ProjectName = model.PName;
            this.TryUpdateModel<MaterialCost>(material);
            this.ProjectService.SaveMaterialCost(material);

            var machine = new MachineryCost();
            machine.ProjectID = model.ID;
            machine.ProjectName = model.PName;
            this.TryUpdateModel<MachineryCost>(machine);
            this.ProjectService.SaveMachineryCost(machine);

            var measure = new Measure();
            measure.ProjectID = model.ID;
            measure.ProjectName = model.PName;
            this.TryUpdateModel<Measure>(measure);
            this.ProjectService.SaveMeasure(measure);

            var overhead = new Overhead();
            overhead.ProjectID = model.ID;
            overhead.ProjectName = model.PName;
            this.TryUpdateModel<Overhead>(overhead);
            this.ProjectService.SaveOverhead(overhead);

            var budgetinfo = new BudgetInfo();
            budgetinfo.ProjectID = model.ID;
            budgetinfo.ProjectName = model.PName;
            this.TryUpdateModel<BudgetInfo>(budgetinfo);
            this.ProjectService.SaveBudget(budgetinfo); 
       
            //-------------------------------即时管理------------------------------------------------

            //var inslabor = new InsLaborCost();
            //inslabor.ProjectID = model.ID;
            //inslabor.ProjectName = model.PName;
            //this.TryUpdateModel<InsLaborCost>(inslabor);
            //this.ProjectService.SaveInsLaborCost(inslabor);

            //var insmaterial = new InsMaterialCost();
            //insmaterial.ProjectID = model.ID;
            //insmaterial.ProjectName = model.PName;
            //this.TryUpdateModel<InsMaterialCost>(insmaterial);
            //this.ProjectService.SaveInsMaterialCost(insmaterial);

            //var insmachine = new InsMachineryCost();
            //insmachine.ProjectID = model.ID;
            //insmachine.ProjectName = model.PName;
            //this.TryUpdateModel<InsMachineryCost>(insmachine);
            //this.ProjectService.SaveInsMachineryCost(insmachine);

            //var insmeasure = new InsMeasure();
            //insmeasure.ProjectID = model.ID;
            //insmeasure.ProjectName = model.PName;
            //this.TryUpdateModel<InsMeasure>(insmeasure);
            //this.ProjectService.SaveInsMeasure(insmeasure);

            //var insoverhead = new InsOverhead();
            //insoverhead.ProjectID = model.ID;
            //insoverhead.ProjectName = model.PName;
            //this.TryUpdateModel<InsOverhead>(insoverhead);
            //this.ProjectService.SaveInsOverhead(insoverhead);

            //var insbudgetinfo = new InsBudgetInfo();
            //insbudgetinfo.ProjectID = model.ID;
            //insbudgetinfo.ProjectName = model.PName;
            //this.TryUpdateModel<InsBudgetInfo>(insbudgetinfo);
            //this.ProjectService.SaveInsBudget(insbudgetinfo); 



            return this.RefreshParent();
        }

        //
        // GET: /Project/ProjectBasedata/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetProjectBasedata(id);
            return View(model);
        }

        //
        // POST: /Project/ProjectBasedata/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            var model = this.ProjectService.GetProjectBasedata(id);
            this.TryUpdateModel<ProjectBasedata>(model);

            this.ProjectService.SaveProjectBasedata(model);

            return this.RefreshParent();
        }

        //
        // GET: /Project/ProjectBasedata/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Project/ProjectBasedata/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteProjectBasedata(ids);
            return RedirectToAction("Index");
        }
    }
}
