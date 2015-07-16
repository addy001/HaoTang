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
  
    [Permission(EnumBusinessPermission.ProjectManage_Measure)]
    public class OverheadController : AdminControllerBase
    {

        public ActionResult Index(OverheadRequest request)
        {
            var result = this.ProjectService.GetOverheadList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var model = new Overhead();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Overhead();

            this.TryUpdateModel<Overhead>(model);
            this.ProjectService.SaveOverhead(model);

            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetOverhead(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetOverhead(id);
            this.TryUpdateModel<Overhead>(model);
            model.OverheadTotal = 0;
            if (model.OPay != null)
                model.OverheadTotal += (int)model.OPay;
            if (model.OBonus != null)
                model.OverheadTotal += (int)model.OBonus;
            if (model.OEntertainment != null)
                model.OverheadTotal += (int)model.OEntertainment;
            if (model.OTraffic != null)
                model.OverheadTotal += (int)model.OTraffic;
            if (model.OVehicle != null)
                model.OverheadTotal += (int)model.OVehicle;
            if (model.OOffice != null)
                model.OverheadTotal += (int)model.OOffice;
            if (model.OWelfare != null)
                model.OverheadTotal += (int)model.OWelfare;

            if (model.OSecurity != null)
                model.OverheadTotal += (int)model.OSecurity;
            if (model.OAccidentInsurance != null)
                model.OverheadTotal += (int)model.OAccidentInsurance;
            if (model.OHousingFund != null)
                model.OverheadTotal += (int)model.OHousingFund;
            if (model.OMeals != null)
                model.OverheadTotal += (int)model.OMeals;
            if (model.OAccommodation != null)
                model.OverheadTotal += (int)model.OAccommodation;
            if (model.OUnion != null)
                model.OverheadTotal += (int)model.OUnion;
            if (model.OEducation != null)
                model.OverheadTotal += (int)model.OEducation;


            if (model.OlaborInsurance != null)
                model.OverheadTotal += (int)model.OlaborInsurance;

            if (model.OFare != null)
                model.OverheadTotal += (int)model.OFare;

            if (model.OSewageCharges != null)
                model.OverheadTotal += (int)model.OSewageCharges;

            if (model.OMeasuring != null)
                model.OverheadTotal += (int)model.OMeasuring;

            if (model.OCost != null)
                model.OverheadTotal += (int)model.OCost;

            if (model.OFinance != null)
                model.OverheadTotal += (int)model.OFinance;

            if (model.OInvisible != null)
                model.OverheadTotal += (int)model.OInvisible;

            if (model.OOther != null)
                model.OverheadTotal += (int)model.OOther; 
            this.ProjectService.SaveOverhead(model);

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
            this.ProjectService.DeleteOverhead(ids);
            return RedirectToAction("Index");
        }
    }

}
