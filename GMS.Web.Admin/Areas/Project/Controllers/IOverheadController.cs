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
    [Permission(EnumBusinessPermission.ProjectManage_InsOverhead)]
    public class IOverheadController : AdminControllerBase
    {

        public ActionResult Index(InsOverheadRequest request)
        {
            var result = this.ProjectService.GetInsOverheadList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var model = new InsOverhead();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new InsOverhead();

            this.TryUpdateModel<InsOverhead>(model);
            this.ProjectService.SaveInsOverhead(model);

            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetInsOverhead(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetInsOverhead(id);
            this.TryUpdateModel<InsOverhead>(model);
            model.OverheadTotal = model.OPay + model.OBonus + model.OEntertainment + model.OTraffic + model.OVehicle + model.OOffice + model.OWelfare + model.OSecurity + model.OAccidentInsurance + model.OHousingFund + model.OMeals + model.OAccommodation + model.OUnion + model.OEducation + model.OlaborInsurance + model.OFare + model.OSewageCharges + model.OMeasuring + model.OCost + model.OFinance + model.OInvisible + model.OOther;
            this.ProjectService.SaveInsOverhead(model);

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
            this.ProjectService.DeleteInsOverhead(ids);
            return RedirectToAction("Index");
        }
    }

}
