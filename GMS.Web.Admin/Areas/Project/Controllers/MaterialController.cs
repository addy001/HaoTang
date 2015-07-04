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
    

    [Permission(EnumBusinessPermission.ProjectManage_Material)]
    public class MaterialController : AdminControllerBase
    {

        public ActionResult Index(MaterialCostRequest request)
        {
            var result = this.ProjectService.GetMaterialCostList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var model = new MaterialCost();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new MaterialCost();

            this.TryUpdateModel<MaterialCost>(model);
            this.ProjectService.SaveMaterialCost(model);

            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetMaterialCost(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetMaterialCost(id);
            this.TryUpdateModel<MaterialCost>(model);
            model.MaterialTotal = model.MSteel + model.MHose + model.MCement + model.MGrayOil + model.MWire + model.MWood + model.MCeramicTile + model.MWindowsDoors + model.MGalss + model.MHardware + model.MElectric + model.MConcrete + model.MBrick + model.MTemplate + model.MAluminum + model.MTest + model.MFireAirSmoke + model.MTurnoverRent + model.MTurnovers + model.MOther;
            this.ProjectService.SaveMaterialCost(model);

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
            this.ProjectService.DeleteMaterialCost(ids);
            return RedirectToAction("Index");
        }
    }
}
