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
    [Permission(EnumBusinessPermission.ProjectManage_InsMaterial)]
    public class IMaterialController : AdminControllerBase
    {

        public ActionResult Index(InsMaterialCostRequest request)
        {
            var result = this.ProjectService.GetInsMaterialCostList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var model = new InsMaterialCost();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new InsMaterialCost();
            this.TryUpdateModel<InsMaterialCost>(model);
            this.ProjectService.SaveInsMaterialCost(model);
            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetInsMaterialCost(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetInsMaterialCost(id);
            this.TryUpdateModel<InsMaterialCost>(model);
            model.MaterialTotal = model.MSteel + model.MHose + model.MCement + model.MGrayOil + model.MWire + model.MWood + model.MCeramicTile + model.MWindowsDoors + model.MGalss + model.MHardware + model.MElectric + model.MConcrete + model.MBrick + model.MTemplate + model.MAluminum + model.MTest + model.MFireAirSmoke + model.MTurnoverRent + model.MTurnovers + model.MOther;
            this.ProjectService.SaveInsMaterialCost(model);
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
            this.ProjectService.DeleteInsMaterialCost(ids);
            return RedirectToAction("Index");
        }
    }
}
