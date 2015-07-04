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
            var result = this.ProjectService.GetInsMeasureList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
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
            model.MeasureTotal = model.Water + model.Electric + model.TempTool + model.TempFacility + model.Secure + model.Test + model.QualityCosts + model.Civilization + model.SecondHand + model.OtherFee;

            this.ProjectService.SaveInsMeasure(model);

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
            this.ProjectService.DeleteInsMeasure(ids);
            return RedirectToAction("Index");
        }
    }
}
