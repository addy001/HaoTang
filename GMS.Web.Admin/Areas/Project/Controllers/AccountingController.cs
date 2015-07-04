using GMS.Account.Contract;
using GMS.Framework.Utility;
using GMS.Project.Contract;
using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Project.Controllers
{
     [Permission(EnumBusinessPermission.ProjectManage_Accounting)]
    public class AccountingController : AdminControllerBase
    {
        //
        // GET: /Project/Accounting/

        public ActionResult Index(AccountingRequest request)
        {
            var model = new Accounting();
            ViewData.Add("Rank", new SelectList(EnumHelper.GetItemValueList<EnumRank>(), "Key", "Value", model.Rank));
            ViewData.Add("AccountDep", new SelectList(EnumHelper.GetItemValueList<EnumDep>(), "Key", "Value", model.AccountDep));

            var result = this.ProjectService.GetAccountingList(request);
            
            return View(result);
        }

        //
        // GET: /Project/Accounting/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Project/Accounting/Create

        public ActionResult Create()
        {
            var model = new Accounting();
            this.RenderMyViewData(model);
            return View("Edit",model);
        }

        //
        // POST: /Project/Accounting/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var model = new Accounting();
                this.TryUpdateModel<Accounting>(model);
                this.ProjectService.SaveAccounting(model);
                return this.RefreshParent();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Project/Accounting/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetAccounting(id);
            this.RenderMyViewData(model);
            return View();
        }

        //
        // POST: /Project/Accounting/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var model = this.ProjectService.GetAccounting(id);
                this.TryUpdateModel<Accounting>(model);
                this.ProjectService.SaveAccounting(model);
                return this.RefreshParent();
              
            }
            catch
            {
                return View();
            }
        }

       

        //
        // POST: /Project/Accounting/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            try
            {
                this.ProjectService.DeleteAccounting(ids);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private void RenderMyViewData(Accounting model)
        {
            ViewData.Add("Rank", new SelectList(EnumHelper.GetItemValueList<EnumRank>(), "Key", "Value", model.Rank));
            ViewData.Add("AccountDep", new SelectList(EnumHelper.GetItemValueList<EnumDep>(), "Key", "Value", model.AccountDep));
        }
    }
}
