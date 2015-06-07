using GMS.Account.Contract;
using GMS.Basedata.Contract;
using GMS.Framework.Utility;
using GMS.OA.Contract;
using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Basedata.Controllers
{
     [Permission(EnumBusinessPermission.BasedataManage_Material)]
    public class MaterialController : AdminControllerBase
    {
        //
        // GET: /Basedata/Material/

        public ActionResult Index(MaterialRequest request)
        {
            var result = this.BasedataService.GetMaterialList(request);
            return View(result);
        }

        //
        // GET: /Basedata/Material/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /Basedata/Material/Create

        public ActionResult Create()
        {
            var model = new Material();
            return View("Edit", model);
           
        }

        //
        // POST: /Basedata/Material/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Material();
            this.TryUpdateModel<Material>(model);

            this.BasedataService.SaveMaterial(model);

            return this.RefreshParent();
        }

        //
        // GET: /Basedata/Material/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.BasedataService.GetMaterial(id);
            return View(model);
        }

        //
        // POST: /Basedata/Material/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.BasedataService.GetMaterial(id);
            this.TryUpdateModel<Material>(model);

            this.BasedataService.SaveMaterial(model);

            return this.RefreshParent();
        }

        //
        // GET: /Basedata/Material/Delete/5

      
        //
        // POST: /Basedata/Material/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.BasedataService.DeleteMaterial(ids);
            return RedirectToAction("Index");
        }

      
    }
}
