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
            var ProjectList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectList, "ID", "PName");

            var result = this.ProjectService.GetInsMachineryCostList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var ProjectList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectList, "ID", "PName");


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
            if (model.Transport != null)
                model.MachineryTotal += (int)model.Transport;
            if (model.Operating != null)
                model.MachineryTotal += (int)model.Operating;
            if (model.Repair != null)
                model.MachineryTotal += (int)model.Repair;
            if (model.Fuel != null)
                model.MachineryTotal += (int)model.Fuel;
            if (model.Depreciation != null)
                model.MachineryTotal += (int)model.Depreciation;
            if (model.TravelTax != null)
                model.MachineryTotal += (int)model.TravelTax;
            if (model.OtherFee != null)
                model.MachineryTotal += (int)model.OtherFee;
           
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
            model.MachineryTotal = 0;
            if (model.Transport != null)
                model.MachineryTotal += (int)model.Transport;
            if (model.Operating != null)
                model.MachineryTotal += (int)model.Operating;
            if (model.Repair != null)
                model.MachineryTotal += (int)model.Repair;
            if (model.Fuel != null)
                model.MachineryTotal += (int)model.Fuel;
            if (model.Depreciation != null)
                model.MachineryTotal += (int)model.Depreciation;
            if (model.TravelTax != null)
                model.MachineryTotal += (int)model.TravelTax;
            if (model.OtherFee != null)
                model.MachineryTotal += (int)model.OtherFee;
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
