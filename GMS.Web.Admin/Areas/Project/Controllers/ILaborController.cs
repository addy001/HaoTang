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
    [Permission(EnumBusinessPermission.ProjectManage_InsLabor)]
    public class ILaborController : AdminControllerBase
    {

        public ActionResult Index(InsLaborCostRequest request)
        {
            var result = this.ProjectService.GetInsLaborCostList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var model = new InsLaborCost();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new InsLaborCost();
            this.TryUpdateModel<InsLaborCost>(model);
            this.ProjectService.SaveInsLaborCost(model);

            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetInsLaborCost(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetInsLaborCost(id);
            this.TryUpdateModel<InsLaborCost>(model);
            model.LaborTotal = model.Masons + model.Painter + model.Steel + model.OtherLabor + model.Plumbers + model.TearDown + model.Transportor + model.Carpenter + model.Cleaner + model.ELectricWelder;
            this.ProjectService.SaveInsLaborCost(model);
            return this.RefreshParent();
        }

        //
        // GET: /Project/Labor/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Labor/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteInsLaborCost(ids);
            return RedirectToAction("Index");
        }



    }
}
