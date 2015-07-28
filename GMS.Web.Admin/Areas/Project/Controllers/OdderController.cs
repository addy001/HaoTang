using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Project.Contract;
using GMS.Account.Contract;
using GMS.Web.Admin.Common;
using GMS.Framework.Utility;

namespace GMS.Web.Admin.Areas.Project.Controllers
{
    [Permission(EnumBusinessPermission.ProjectManage_Odder)]
    public class OdderController : AdminControllerBase
    {
        //
        // GET: /Crm/Project/

        public ActionResult Index(OdderRequest requset)
        {
            //var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            //this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");

            var result = this.ProjectService.GetOdderList(requset);
            return View(result);
        }

        //
        // GET: /Crm/Project/Create

        public ActionResult Create()
        {
            //var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            //this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");
            
            var model = new Odder();
            return View("Edit", model);
        }

        //
        // POST: /Crm/Project/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Odder();
            this.TryUpdateModel<Odder>(model);
            model.oddnum = model.CreateTime.ToFileTimeUtc().ToString();
            this.ProjectService.SaveOdder(model);
            return this.RefreshParent();
        }

        //
        // GET: /Crm/Project/Edit/5

        public ActionResult Edit(int id)
        {
            //var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            //this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");
            
            var model = this.ProjectService.GetOdder(id);
            return View(model);
        }

        //
        // POST: /Crm/Project/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetOdder(id);
            this.TryUpdateModel<Odder>(model);
           
            this.ProjectService.SaveOdder(model);

            return this.RefreshParent();
        }

        // POST: /Crm/Project/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteOdder(ids);
            return RedirectToAction("Index");
        }
    }
}
