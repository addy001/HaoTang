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
    [Permission(EnumBusinessPermission.ProjectManage_Accountant)]
    public class AccountantController : AdminControllerBase
    { //
        // GET: /Basisdata/Classification/

        public ActionResult Index(AccountantRequest request)
        {           
            var result = this.ProjectService.GetAccountantList(request);
            return View(result);
        }

        //
        // GET: /Cms/Article/Create
        //[HttpPost]
        //public ActionResult Search(FormCollection collection)
        //{
        //    string ClassName = collection["ClassName"];
        //    string code = collection["Code"];
        //    this.ViewData["Code"] = code;
        //    this.ViewData["ClassName"] = ClassName;
        //    var result = this.BasisDataService.GetClassificationList(new ClassificationRequest() { Name = ClassName, Code = code });
        //    return View(result);
        //}
        public ActionResult Create()
        {
            //var classList = this.BasisDataService.GetClassificationList(new ClassificationRequest() { Name = "wenju" });

            //this.ViewBag.ChannelId = new SelectList(classList, "ID", "Name");

            var model = new Accountant();
            return View("Edit", model);
        }

        //
        // POST: /Cms/Article/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Accountant();
            this.TryUpdateModel<Accountant>(model);
            this.ProjectService.SaveAccountant(model);
            return this.RefreshParent();
        }


        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetAccount(id);

            //var materialList = this.ProjectService.GetMaterialList(new MaterialRequest());
            //this.ViewBag.ChannelId = new SelectList(materialList, "ID", "Name");
            return View(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetAccount(id);
            this.TryUpdateModel<Accountant>(model);
            this.ProjectService.SaveAccountant(model);
            return this.RefreshParent();
        }


        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteAccountant(ids);
            return RedirectToAction("Index");
        }
    }
}
