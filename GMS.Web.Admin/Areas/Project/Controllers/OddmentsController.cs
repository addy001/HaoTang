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
    [Permission(EnumBusinessPermission.ProjectManage_Oddments)]
    public class OddmentsController : AdminControllerBase
    {
        //
        // GET: /Cms/Oddments/

        public ActionResult Index(OddmentsRequest requset)
        {
            var model = new Oddments();
            this.RenderMyViewData(model);
            var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");
            var result = this.ProjectService.GetOddmentsList(requset);
            return View(result);
        }

        //
        // GET: /Cms/Oddments/Create

        public ActionResult Create()
        {
            var model = new Oddments();
            this.RenderMyViewData(model);
            var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");
            return View("Edit", model);
        }

        //
        // POST: /Cms/Oddments/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Oddments();
            this.TryUpdateModel<Oddments>(model);
            model.ChangTime = model.CreateTime.ToCnDataString();
            this.ProjectService.SaveOddments(model);

            return this.RefreshParent();
        }

        //
        // GET: /Cms/Oddments/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetOddments(id);
            this.RenderMyViewData(model);
            var ProjectBasedataIDList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectBasedataIDList, "ID", "PName");
            return View(model);
        }

        //
        // POST: /Cms/Oddments/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetOddments(id);
            
            
            this.TryUpdateModel<Oddments>(model);
            var temp = model.obb.ToDouble() * model.Way.ToDouble();
            model.Discount = (model.obb.ToDouble() - temp).ToString();
            model.obb = temp.ToString();
            model.CreateTime = DateTime.Now;
            this.ProjectService.SaveOddments(model);

            return this.RefreshParent();
        }

        // POST: /Cms/Oddments/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteOddments(ids);
            return RedirectToAction("Index");
        }
        private void RenderMyViewData(Oddments model)
        {
            ViewData.Add("OType", new SelectList(EnumHelper.GetItemValueList<EnumOType>(), "Key", "Value", model.OType));
        }
    }
}
