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
    [Permission(EnumBusinessPermission.ProjectManage_InsMachine)]
    public class IMachineController : AdminControllerBase
    {

        public ActionResult Index(InsMachineryCostRequest request)
        {
            var result = this.ProjectService.GetInsMachineryCostList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var model = new InsMachineryCost();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new InsMachineryCost();
            this.TryUpdateModel<InsMachineryCost>(model);
            this.ProjectService.SaveInsMachineryCost(model);
            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetInsMachineryCost(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetInsMachineryCost(id);
            this.TryUpdateModel<InsMachineryCost>(model);
            model.MachineryTotal = model.Transport + model.Operating + model.Repair + model.Fuel + model.Depreciation + model.TravelTax + model.OtherFee;
            this.ProjectService.SaveInsMachineryCost(model);
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
            this.ProjectService.DeleteInsMachineryCost(ids);
            return RedirectToAction("Index");
        }
    }
}
