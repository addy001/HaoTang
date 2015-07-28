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
    [Permission(EnumBusinessPermission.ProjectManage_OfficeCtrl)]
    public class OfficeCtrlController : AdminControllerBase
    {
        //
        // GET: /Cms/Office/

        public ActionResult Index(OfficeCtrlRequest requset)
        {
            var result = this.ProjectService.GetOfficeCtrlList(requset);
            return View(result);
        }

        //
        // GET: /Cms/Office/Create

        public ActionResult Create()
        {
            var model = new OfficeCtrl();
            return View("Edit", model);
        }

        //
        // POST: /Cms/Office/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new OfficeCtrl();
            this.TryUpdateModel<OfficeCtrl>(model);
            model.oddnum = model.CreateTime.ToFileTimeUtc().ToString();
            model.total = model.num * model.obb;
            this.ProjectService.SaveOfficeCtrl(model);

            var odder = new Odder();
            odder.oddnum = model.oddnum;
            this.ProjectService.SaveOdder(odder);
            return this.RefreshParent();
        }

        //
        // GET: /Cms/Office/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetOfficeCtrl(id);
            return View(model);
        }

        //
        // POST: /Cms/Office/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetOfficeCtrl(id);
            this.TryUpdateModel<OfficeCtrl>(model);
            model.total = model.num * model.obb;
            this.ProjectService.SaveOfficeCtrl(model);

            return this.RefreshParent();
        }
        public ActionResult Add(string oddNum)
        {
            var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");

            var model = new OfficeCtrl();
            model.oddnum = oddNum;
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Add(string oddNum, FormCollection collection)
        {
            var model = new OfficeCtrl();
            //var model_last = this.ProjectService.GetProjectCtrl(id);
            this.TryUpdateModel<OfficeCtrl>(model);
            model.oddnum = oddNum;
            model.total = model.num * model.obb;
            this.ProjectService.SaveOfficeCtrl(model);

            return this.RefreshParent();
        }
        // POST: /Cms/Office/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteOfficeCtrl(ids);
            return RedirectToAction("Index");
        }
    }
}
