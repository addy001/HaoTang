using GMS.Account.Contract;
using GMS.Framework.Utility;
using GMS.Project.Contract;
using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Project
{
     [Permission(EnumBusinessPermission.ProjectManage_Income)]
    public class IncomeController : AdminControllerBase
    {
       
        public ActionResult Index(IncomeRequest request)
        {
            var model = new Income();
            //this.RenderMyViewData(model);
            var result = this.ProjectService.GetIncomeList(request);            
            return View(result);
        }

      
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Project/Income/Create

        public ActionResult Create()
        {
            var model = new Income();
            //this.RenderMyViewData(model);
            return View("Edit",model);
        }

        //
        // POST: /Project/Income/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var model = new Income();
                this.TryUpdateModel<Income>(model);
                this.ProjectService.SaveIncome(model);
                return this.RefreshParent();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Project/Income/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetIncome(id);
            //this.RenderMyViewData(model);
            return View(model);
        }

        //
        // POST: /Project/Income/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var model = this.ProjectService.GetIncome(id);
                this.TryUpdateModel<Income>(model);
                this.ProjectService.SaveIncome(model);
                return this.RefreshParent();
              
            }
            catch
            {
                return View();
            }
        }

       

        //
        // POST: /Project/Income/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            try
            {
                this.ProjectService.DeleteIncome(ids);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //private void RenderMyViewData(Income model)
        //{
        //    ViewData.Add("Rank", new SelectList(EnumHelper.GetItemValueList<EnumRank>(), "Key", "Value", model.Rank));
        //    ViewData.Add("AccountDep", new SelectList(EnumHelper.GetItemValueList<EnumDep>(), "Key", "Value", model.AccountDep));
        //}
    }
}
