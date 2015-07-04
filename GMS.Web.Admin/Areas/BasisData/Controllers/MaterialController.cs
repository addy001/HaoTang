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
     [Permission(EnumBusinessPermission.Basis_Material)]
    public class MaterialController :AdminControllerBase  {
        public ActionResult Index(MaterialRequest request,int? id)
        {
            this.ViewData["BasisDataService"] = this.BasisDataService;
            if (id > 0)
            {
                return View(this.BasisDataService.GetMaterialList(new MaterialRequest(){ ClassificationID=id}));
            }
            else {
            //var materialList = this.BasisDataService.GetMaterialList(new MaterialRequest());
            //this.ViewBag.ChannelId = new SelectList(classList, "ID", "Name");
            var result = this.BasisDataService.GetMaterialList(request);
            return View(result);
            }
        }

        //
        // GET: /Cms/Article/Create
         [HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            string Material = collection["Material"];
            this.ViewData["mat"] = Material;
            this.ViewData["BasisDataService"] = this.BasisDataService;

            if (!string.IsNullOrEmpty(collection["many"]) && !string.IsNullOrEmpty(collection["once"]))
            {   this.ViewData["all"]="all";
                return View(this.BasisDataService.GetMaterialList(new MaterialRequest() { Name = Material }));
            }
            else if (!string.IsNullOrEmpty(collection["many"]))
            {
                this.ViewData["all"] = "many";
                return View(this.BasisDataService.GetMaterialList(new MaterialRequest() { Name = Material, IsAvailability=true}));

            }
            else
            {
                this.ViewData["all"] = "once";

                return View(this.BasisDataService.GetMaterialList(new MaterialRequest() { Name = Material, IsAvailability = false }));

            }
            //this.ViewBag.ChannelId = new SelectList(classList, "ID", "Name");
        }
        public ActionResult Create()
        {
            var classlList = this.BasisDataService.GetClassificationList(new ClassificationRequest());
            //this.ViewBag.Tags = this.CmsService.GetTagList(new TagRequest() { Top = 20, Orderby = Orderby.Hits });

            var model = new Material();
            ViewData.Add("ClassificationID", new SelectList(classlList, "ID", "Name", model.ClassificationID));
            var stu = new { Name = "一次性材料", IsAvailability =false };
            var list = Enumerable.Repeat(stu, 1).ToList();
            list.Add(new { Name = "可复用材料", IsAvailability = true });
            ViewData.Add("IsAvailability", new SelectList(list,"IsAvailability","Name"));
            return View("Edit", model);
        }

        //
        // POST: /Cms/Article/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Material();
            this.TryUpdateModel<Material>(model);

            this.BasisDataService.SaveMaterial(model);

            return this.RefreshParent();
        }


        public ActionResult Edit(int id)
        {
            var model = this.BasisDataService.GetMaterial(id);

            var classlList = this.BasisDataService.GetClassificationList(new ClassificationRequest());
            //this.ViewBag.Tags = this.CmsService.GetTagList(new TagRequest() { Top = 20, Orderby = Orderby.Hits });
            ViewData.Add("ClassificationID", new SelectList(classlList, "ID", "Name", model.ClassificationID));
            var stu = new { Name = "一次性材料", IsAvailability = false };
            var list = Enumerable.Repeat(stu, 1).ToList();
            list.Add(new { Name = "可复用材料", IsAvailability = true });
            ViewData.Add("IsAvailability", new SelectList(list, "IsAvailability", "Name",model.IsAvailability));
            return View(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.BasisDataService.GetMaterial(id);
            this.TryUpdateModel<Material>(model);

            this.BasisDataService.SaveMaterial(model);

            return this.RefreshParent();
        }


        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {   
            this.BasisDataService.DeleteMaterial(ids);
            return RedirectToAction("Index");
        }
       
    }
}
