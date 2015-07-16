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
            model.MaterialTotal = 0;
            if (model.MSteel != null)
                model.MaterialTotal += (int)model.MSteel;
            if (model.MHose != null)
                model.MaterialTotal += (int)model.MHose;
            if (model.MCement != null)
                model.MaterialTotal += (int)model.MCement;
            if (model.MGrayOil != null)
                model.MaterialTotal += (int)model.MGrayOil;
            if (model.MWire != null)
                model.MaterialTotal += (int)model.MWire;
            if (model.MWood != null)
                model.MaterialTotal += (int)model.MWood;
            if (model.MCeramicTile != null)
                model.MaterialTotal += (int)model.MCeramicTile;
            if (model.MWindowsDoors != null)
                model.MaterialTotal += (int)model.MWindowsDoors;
            if (model.MGalss != null)
                model.MaterialTotal += (int)model.MGalss;
            if (model.MHardware != null)
                model.MaterialTotal += (int)model.MHardware;
            if (model.MElectric != null)
                model.MaterialTotal += (int)model.MElectric;
            if (model.MConcrete != null)
                model.MaterialTotal += (int)model.MConcrete;
            if (model.MBrick != null)
                model.MaterialTotal += (int)model.MBrick;
            if (model.MTemplate != null)
                model.MaterialTotal += (int)model.MTemplate;
            if (model.MAluminum != null)
                model.MaterialTotal += (int)model.MAluminum;

            if (model.MTest != null)
                model.MaterialTotal += (int)model.MTest;
            if (model.MMortar != null)
                model.MaterialTotal += (int)model.MMortar;
            if (model.MFireAirSmoke != null)
                model.MaterialTotal += (int)model.MFireAirSmoke;

            if (model.MTurnoverRent != null)
                model.MaterialTotal += (int)model.MTurnoverRent;
            if (model.MTurnovers != null)
                model.MaterialTotal += (int)model.MTurnovers;
            if (model.MOther != null)
                model.MaterialTotal += (int)model.MOther; this.ProjectService.SaveMaterialCost(model);

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
