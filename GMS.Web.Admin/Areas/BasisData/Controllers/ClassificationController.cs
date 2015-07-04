using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.BasisData.Contract;
using GMS.Account.Contract;
using GMS.Web.Admin.Common;
using GMS.Framework.Utility;


namespace GMS.Web.Admin.Areas.BasisData.Controllers
{
    [Permission(EnumBusinessPermission.Basis_Classification)]
    public class ClassificationController : AdminControllerBase
    {
        //
        // GET: /Basisdata/Classification/

        public ActionResult Index(ClassificationRequest request)
        {
            //var classList = this.BasisDataService.GetClassificationList(null);

            var result = this.BasisDataService.GetClassificationList(request);
            return View(result);
        }

        //
        // GET: /Cms/Article/Create
        [HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            string ClassName = collection["ClassName"];
            string code = collection["Code"];
            this.ViewData["Code"] = code;
            this.ViewData["ClassName"] = ClassName;
            var result = this.BasisDataService.GetClassificationList(new ClassificationRequest() { Name = ClassName, Code = code });
            return View(result);
        }
        public ActionResult Create()
        {
            var classList = this.BasisDataService.GetClassificationList(new ClassificationRequest() { Name ="wenju"});

            this.ViewBag.ChannelId = new SelectList(classList, "ID", "Name");
            //this.ViewBag.Tags = this.CmsService.GetTagList(new TagRequest() { Top = 20, Orderby = Orderby.Hits });

            var model = new Classification() ;
            return View("Edit", model);
        }

        //
        // POST: /Cms/Article/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Classification() ;
            this.TryUpdateModel<Classification>(model);

            this.BasisDataService.SaveClassification(model);

            return this.RefreshParent();
        }


        public ActionResult Edit(int id)
        {
            var model = this.BasisDataService.GetClassification(id);

            var materialList = this.BasisDataService.GetMaterialList(new MaterialRequest());
            this.ViewBag.ChannelId = new SelectList(materialList, "ID", "Name");
            //this.ViewBag.Tags = this.CmsService.GetTagList(new TagRequest() { Top = 20, Orderby = Orderby.Hits });
            return View(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.BasisDataService.GetClassification(id);
            this.TryUpdateModel<Classification>(model);

            this.BasisDataService.SaveClassification(model);

            return this.RefreshParent();
        }


        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.BasisDataService.DeleteClassification(ids);
            return RedirectToAction("Index");
        }

    }
}
