using GMS.Account.Contract;
using GMS.Project.Contract;
using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Framework.Utility;


namespace GMS.Web.Admin.Areas.Project.Controllers
{
     [Permission(EnumBusinessPermission.ProjectManage_Basedata)]
    public class ProjectBasedataController : AdminControllerBase
    {
        //
        // GET: /Project/ProjectBasedata/

        public ActionResult Index(ProjectRequest request)
        {
            var result = this.ProjectService.GetProjectBasedataList(request);
            return View(result);
        }

        //
        // GET: /Project/ProjectBasedata/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /Project/ProjectBasedata/Create

        public ActionResult Create()
        {
            var model = new ProjectBasedata();
            return View("Edit",model);
        }

        //
        // POST: /Project/ProjectBasedata/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new ProjectBasedata();
            model.codeID =DateTime.Now.ToString();
            this.TryUpdateModel<ProjectBasedata>(model);

            this.ProjectService.SaveProjectBasedata(model);

            return this.RefreshParent();
        }

        //
        // GET: /Project/ProjectBasedata/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetProjectBasedata(id);
            return View(model);
        }

        //
        // POST: /Project/ProjectBasedata/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            var model = this.ProjectService.GetProjectBasedata(id);
            this.TryUpdateModel<ProjectBasedata>(model);

            this.ProjectService.SaveProjectBasedata(model);

            return this.RefreshParent();
        }

        //
        // GET: /Project/ProjectBasedata/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Project/ProjectBasedata/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteProjectBasedata(ids);
            return RedirectToAction("Index");
        }
    }
}
