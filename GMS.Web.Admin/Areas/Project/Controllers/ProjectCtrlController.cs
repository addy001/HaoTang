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
    [Permission(EnumBusinessPermission.ProjectManage_ProjectCtrl)]
    public class ProjectCtrlController : AdminControllerBase
    {
        //
        // GET: /Crm/Project/

        public ActionResult Index(ProjectCtrlRequest requset)
        {
            var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");
            
            var result = this.ProjectService.GetProjectCtrlList(requset);
            return View(result);
        }

        //
        // GET: /Crm/Project/Create

        public ActionResult Create()
        {
            var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");
            
            var model = new ProjectCtrl();
            return View("Edit", model);
        }

        //
        // POST: /Crm/Project/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new ProjectCtrl();
            this.TryUpdateModel<ProjectCtrl>(model);
            model.oddnum=model.CreateTime.ToFileTimeUtc().ToString();
            model.Total = model.Num *model.obb;
            this.ProjectService.SaveProjectCtrl(model);

            var odder = new Odder();
            odder.oddnum = model.oddnum;
            this.ProjectService.SaveOdder(odder);
            return this.RefreshParent();
        }

        //
        // GET: /Crm/Project/Edit/5

        public ActionResult Edit(int id)
        {
            var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");
            
            var model = this.ProjectService.GetProjectCtrl(id);
            return View(model);
        }

        //
        // POST: /Crm/Project/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetProjectCtrl(id);
            this.TryUpdateModel<ProjectCtrl>(model);
            model.Total = model.Num * model.obb;
            this.ProjectService.SaveProjectCtrl(model);

            return this.RefreshParent();
        }

        public ActionResult Add(string oddNum)
        {
            var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");

            var model = new ProjectCtrl();
            model.oddnum = oddNum;
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Add(string oddNum, FormCollection collection)
        {
            var model = new ProjectCtrl();
            //var model_last = this.ProjectService.GetProjectCtrl(id);
            this.TryUpdateModel<ProjectCtrl>(model);
            model.oddnum = oddNum;
            model.Total = model.Num * model.obb;
            this.ProjectService.SaveProjectCtrl(model);

            return this.RefreshParent();
        }
        // POST: /Crm/Project/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteProjectCtrl(ids);
            return RedirectToAction("Index");
        }
    }
}
