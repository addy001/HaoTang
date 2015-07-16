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
    [Permission(EnumBusinessPermission.ProjectManage_InsMeasure)]
    public class IMeasureController : AdminControllerBase
    {

        public ActionResult Index(InsMeasureRequest request)
        {
            var ProjectList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectList, "ID", "PName");

            var result = this.ProjectService.GetInsMeasureList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var ProjectList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectList, "ID", "PName");

            var model = new InsMeasure();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {


            var model = new InsMeasure();
            this.TryUpdateModel<InsMeasure>(model);

            if (model.Water != null)
                model.MeasureTotal += (int)model.Water;
            if (model.Electric != null)
                model.MeasureTotal += (int)model.Electric;
            if (model.TempTool != null)
                model.MeasureTotal += (int)model.TempTool;

            if (model.Test != null)
                model.MeasureTotal += (int)model.Test;
            if (model.Electric != null)
                model.MeasureTotal += (int)model.QualityCosts;
            if (model.Civilization != null)
                model.MeasureTotal += (int)model.Civilization;

            if (model.Secure != null)
                model.MeasureTotal += (int)model.Secure;
            if (model.SecondHand != null)
                model.MeasureTotal += (int)model.SecondHand;
            if (model.TempFacility != null)
                model.MeasureTotal += (int)model.TempFacility;
            if (model.OtherFee != null)
                model.MeasureTotal += (int)model.OtherFee; 

            this.ProjectService.SaveInsMeasure(model);

            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetInsMeasure(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetInsMeasure(id);
            this.TryUpdateModel<InsMeasure>(model);
            model.MeasureTotal = 0;
            if (model.Water != null)
                model.MeasureTotal += (int)model.Water;
            if (model.Electric != null)
                model.MeasureTotal += (int)model.Electric;
            if (model.TempTool != null)
                model.MeasureTotal += (int)model.TempTool;

            if (model.Test != null)
                model.MeasureTotal += (int)model.Test;
            if (model.QualityCosts != null)
                model.MeasureTotal += (int)model.QualityCosts;
            if (model.Civilization != null)
                model.MeasureTotal += (int)model.Civilization;

            if (model.Secure != null)
                model.MeasureTotal += (int)model.Secure;
            if (model.SecondHand != null)
                model.MeasureTotal += (int)model.SecondHand;
            if (model.TempFacility != null)
                model.MeasureTotal += (int)model.TempFacility;
            if (model.OtherFee != null)
                model.MeasureTotal += (int)model.OtherFee; 

            this.ProjectService.SaveInsMeasure(model);

            return this.RefreshParent();
        }

     

        //
        // POST: /Project/Labor/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteInsMeasure(ids);
            return RedirectToAction("Index");
        }
    }
}
