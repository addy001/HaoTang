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
    [Permission(EnumBusinessPermission.Basis_Supplier)]
    public class SupplierController : AdminControllerBase
    {
        public ActionResult Index(SupplierRequest request)
        {
            //var materialList = this.BasisDataService.GetSupplierList(new SupplierRequest());
            //this.ViewBag.ChannelId = new SelectList(classList, "ID", "Name");
            this.ViewData["BasisDataService"] = this.BasisDataService;
            var result = this.BasisDataService.GetSupplierList(request);
            return View(result);
        }
        [HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            string Material = collection["Material"];
            string Price = collection["Price"];
            this.ViewData["ma"] = Material;
            this.ViewData["pr"] = Price;
            this.ViewData["BasisDataService"] = this.BasisDataService;
            if (string.IsNullOrEmpty(Material) && string.IsNullOrEmpty(Price))
            {
                var supplist = this.BasisDataService.GetSupplierList(new SupplierRequest());
                return View(supplist);
            }
            else
            {
                var materialList = this.BasisDataService.GetMaterialSupplierList(new MaterialSupplierRequest() { MaterialName = Material });
                try
                {
                    double p = double.Parse(Price);
                    materialList = this.BasisDataService.GetMaterialSupplierList(new MaterialSupplierRequest() { MaterialName = Material, Price = p });
                }
                catch
                {
                }
                List<Supplier> suList = new List<Supplier>();
                List<int> mids = new List<int>();

                foreach (var each in materialList)
                {
                    Supplier s = this.BasisDataService.GetSupplier(each.SupplierID);
                    if (!mids.Contains(s.ID))
                    {
                        mids.Add(s.ID);
                        suList.Add(s);
                    }
                }
                return View(suList);

            }
            //this.ViewBag.ChannelId = new SelectList(classList, "ID", "Name");
        }
        //
        // GET: /Cms/Article/Create

        public ActionResult Create()
        {
            var classlList = this.BasisDataService.GetClassificationList(new ClassificationRequest());
            //this.ViewBag.Tags = this.CmsService.GetTagList(new TagRequest() { Top = 20, Orderby = Orderby.Hits });
            var model = new Supplier();
            ViewData.Add("material", new SelectList(classlList, "ID", "Name", ""));
            return View("Edit", model);
        }
        public ActionResult AddMaterial(int id)
        {
            List<Material> mList = this.BasisDataService.GetMaterialList(new MaterialRequest()).ToList();
            var mslist = this.BasisDataService.GetMaterialSupplierList(new MaterialSupplierRequest() { SupplierID = id });
            //List<Material> l1 = mList.ToList();
            //List<Material> l2=new List<Material>();
            ViewData["BasisDataService"] = this.BasisDataService;
            List<int> l1 = new List<int>();

            ////this.ViewBag.Tags = this.CmsService.GetTagList(new TagRequest() { Top = 20, Orderby = Orderby.Hits });
            //var model = new Supplier();, mList);
            ViewData.Add("material", mList);
            ViewData.Add("materialSupplier", mslist);

            return View(id);
        }
        public ActionResult ShowSupplierMaterial(int id)
        {
            //List<Material> mList = this.BasisDataService.GetMaterialList(new MaterialRequest()).ToList();
            var mslist = this.BasisDataService.GetMaterialSupplierList(new MaterialSupplierRequest() { SupplierID = id });
            var supplier = this.BasisDataService.GetSupplier(id);
            ViewData["BasisDataService"] = this.BasisDataService;

            List<MaSu> list = new List<MaSu>();
            //List<Material> l2=new List<Material>();
            //List<int> l1 = new List<int>();
            foreach (MaterialSupplier each in mslist)
            {
                Material ma = this.BasisDataService.GetMaterial(each.MaterialID);
                list.Add(new MaSu() { ID = ma.ID, Name = ma.Name, IsAvailability = ma.IsAvailability, ClassificationID = ma.ClassificationID, Remark = each.Remark, Price = each.Price });

            }
            ////this.ViewBag.Tags = this.CmsService.GetTagList(new TagRequest() { Top = 20, Orderby = Orderby.Hits });
            //var model = new Supplier();, mList);
            ViewData.Add("material", list);
            return View(supplier);
        }
        //
        // POST: /Cms/Article/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Supplier();
            this.TryUpdateModel<Supplier>(model);
            this.BasisDataService.SaveSupplier(model);
            return this.RefreshParent();
        }


        public ActionResult Edit(int id)
        {
            var model = this.BasisDataService.GetSupplier(id);

            var classlList = this.BasisDataService.GetSupplierList(new SupplierRequest());
            //this.ViewBag.Tags = this.CmsService.GetTagList(new TagRequest() { Top = 20, Orderby = Orderby.Hits });
            return View(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.BasisDataService.GetSupplier(id);
            this.TryUpdateModel<Supplier>(model);

            this.BasisDataService.SaveSupplier(model);

            return this.RefreshParent();
        }


        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.BasisDataService.DeleteSupplier(ids);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string AddMaterial(int sId, int mId, string price, string remark)
        {
            try
            {
                double p = 0;
                var model = new MaterialSupplier();


                //this.TryUpdateModel<MaterialSupplier>(model);
                try
                {
                    p = double.Parse(price);
                    model.Price = p;
                }
                catch
                {
                }
                model.MaterialID = mId;
                model.SupplierID = sId;
                model.Remark = remark;
                model.MaterialName = this.BasisDataService.GetMaterial(mId).Name;
                model.SupplierName = this.BasisDataService.GetSupplier(sId).Name;
                this.BasisDataService.SaveMaterialSupplier(model);
                this.RefreshParent();
                return "true";
            }
            catch
            {
                return "false";
            }
        }
        [HttpPost]
        public string DelMaterial(int sId, int mId)
        {
            try
            {
                this.BasisDataService.DeleteMaterialSupplier(mId, sId);
                return "true";
            }
            catch
            {
                return "false";
            }
        }
    }
    public class MaSu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public bool? IsAvailability { get; set; }
        public double? Price { get; set; }
        public int? ClassificationID { get; set; }
    }
}
