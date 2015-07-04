using GMS.Account.Contract;
using GMS.Project.Contract;
using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Project.Controllers
{
    [Permission(EnumBusinessPermission.ProjectManage_Budget)]
    public class BudgetController : AdminControllerBase
    {
        public ActionResult Index(BudgetRequest request)
        {
            var result = this.ProjectService.GetBudgetList(request);
            foreach (var rt in result)
            {
                if (rt.LaborCost != null)
                {
                    rt.BudgetTotal += rt.LaborCost.LaborTotal; 
                }
                if (rt.MaterialCost != null)
                {
                    rt.BudgetTotal += rt.MaterialCost.MaterialTotal;
                }
                if (rt.MachineryCost != null)
                {
                    rt.BudgetTotal += rt.MachineryCost.MachineryTotal;
                }
                if (rt.Measure != null)
                {
                    rt.BudgetTotal += rt.Measure.MeasureTotal;
                }
                if (rt.Overhead != null)
                {
                    rt.BudgetTotal += rt.Overhead.OverheadTotal;
                }
                rt.BudgetTotal +=rt.Warranty + rt.Subcontracting + rt.OtherBudget;
            }
            return View(result);
        }

        //
        // GET: /Project/budget/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /Project/ProjectBasedata/Create

        public ActionResult Create()
        {
            var model = new BudgetInfo();
            return View("Edit", model);
           
        }         //
        // POST: /Project/budget/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new BudgetInfo();

            this.TryUpdateModel<BudgetInfo>(model);
            this.ProjectService.SaveBudget(model);

            return this.RefreshParent();
        }

        //
        // GET: /Project/ProjectBasedata/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetBudget(id);
            return View(model);
        }

        //
        // POST: /Project/ProjectBasedata/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            var model = this.ProjectService.GetBudget(id);
            this.TryUpdateModel<BudgetInfo>(model);
            //model.BudgetTotal = model.Labour + model.MachineryCost + model.Material + model.Overhead + model.Measure + model.Warranty + model.Subcontracting + model.OtherBudget;

            this.ProjectService.SaveBudget(model);

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
            this.ProjectService.DeleteBudget(ids);
            return RedirectToAction("Index");
        }
    }
}