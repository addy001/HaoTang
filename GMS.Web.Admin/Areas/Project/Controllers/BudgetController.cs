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
    [Permission(EnumBusinessPermission.ProjectManage_Budget)]
    public class BudgetController : AdminControllerBase
    {
        public ActionResult Index(BudgetRequest request)
        {
            var result = this.ProjectService.GetBudgetList(request);
            return View(result);
        }

        //
        // GET: /Project/budget/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /Project/ProjectBasedata/Create

        public ActionResult Create()
        {
            var model = new Budget();
            return View("Edit", model);
        }

        //
        // POST: /Project/budget/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Budget();

            this.TryUpdateModel<Budget>(model);
            this.ProjectService.SaveBudget(model);

            return this.RefreshParent();
        }

        //
        // GET: /Project/ProjectBasedata/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetBudget(id);
            return View(model);
        }

        //
        // POST: /Project/ProjectBasedata/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            var model = this.ProjectService.GetBudget(id);
            this.TryUpdateModel<Budget>(model);

            this.ProjectService.SaveBudget(model);

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
            this.ProjectService.DeleteBudget(ids);
            return RedirectToAction("Index");
        }
    }
}