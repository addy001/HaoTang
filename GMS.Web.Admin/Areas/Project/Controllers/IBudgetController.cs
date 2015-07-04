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
    [Permission(EnumBusinessPermission.ProjectManage_InsBudget)]   
    public class IBudgetController : AdminControllerBase
    {
        public ActionResult Index(InsBudgetRequest request)
        {
            var result = this.ProjectService.GetInsBudgetList(request);
            foreach (var rt in result)
            {
                if (rt.InsLaborCost != null)
                {
                    rt.InsBudgetTotal += rt.InsLaborCost.LaborTotal;
                }
                if (rt.InsMaterialCost != null)
                {
                    rt.InsBudgetTotal += rt.InsMaterialCost.MaterialTotal;
                }
                if (rt.InsMachineryCost != null)
                {
                    rt.InsBudgetTotal += rt.InsMachineryCost.MachineryTotal;
                }
                if (rt.InsMeasure != null)
                {
                    rt.InsBudgetTotal += rt.InsMeasure.MeasureTotal;
                }
                if (rt.InsOverhead != null)
                {
                    rt.InsBudgetTotal += rt.InsOverhead.OverheadTotal;
                }
                rt.InsBudgetTotal += rt.InsWarranty + rt.InsSubcontracting + rt.InsOtherBudget;
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
            var model = new InsBudgetInfo();
            return View("Edit", model);

        }         //
        // POST: /Project/budget/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new InsBudgetInfo();

            this.TryUpdateModel<InsBudgetInfo>(model);
            this.ProjectService.SaveInsBudget(model);

            return this.RefreshParent();
        }

        //
        // GET: /Project/ProjectBasedata/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetInsBudget(id);
            return View(model);
        }

        //
        // POST: /Project/ProjectBasedata/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            var model = this.ProjectService.GetInsBudget(id);
            this.TryUpdateModel<InsBudgetInfo>(model);
            //model.BudgetTotal = model.Labour + model.MachineryCost + model.Material + model.Overhead + model.Measure + model.Warranty + model.Subcontracting + model.OtherBudget;

            this.ProjectService.SaveInsBudget(model);

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
            this.ProjectService.DeleteInsBudget(ids);
            return RedirectToAction("Index");
        }
    }
}