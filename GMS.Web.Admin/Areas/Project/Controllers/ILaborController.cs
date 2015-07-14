﻿using GMS.Account.Contract;
using GMS.Project.Contract;
using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Project.Controllers
{
    [Permission(EnumBusinessPermission.ProjectManage_InsLabor)]
    public class ILaborController : AdminControllerBase
    {

        public ActionResult Index(InsLaborCostRequest request)
        {
            var ProjectList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectList, "ID", "PName");
          

            var result = this.ProjectService.GetInsLaborCostList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            
            var ProjectList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectList, "ID", "PName");
          
            var model = new InsLaborCost();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new InsLaborCost();
            this.TryUpdateModel<InsLaborCost>(model);
            //if (model.ProjectBasedataID == 0)
            //{
            //    ModelState.AddModelError("error", "项目不能为空");
            //    return View("Edit", model);
            //}

            this.ProjectService.SaveInsLaborCost(model);

            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var ProjectList = this.ProjectService.GetProjectBasedataList(new ProjectRequest());
            this.ViewBag.ProjectBasedataID = new SelectList(ProjectList, "ID", "PName");

            var model = this.ProjectService.GetInsLaborCost(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            var model = this.ProjectService.GetInsLaborCost(id);
            this.TryUpdateModel<InsLaborCost>(model);
            //if (model.ProjectBasedataID == 0)
            //{
            //    ModelState.AddModelError("error", "项目不能为空");
            //    return View();
            //}
            if (model.Masons != null)
                model.LaborTotal +=(int)model.Masons;
            if (model.Painter != null)
                model.LaborTotal +=(int)model.Painter;
            if (model.Painter != null)
                model.LaborTotal +=(int)model.Steel;
            if (model.Painter != null)
                model.LaborTotal +=(int)model.Plumbers;
            if (model.Painter != null)
                model.LaborTotal +=(int)model.TearDown;
            if (model.Painter != null)
                model.LaborTotal +=(int)model.Transportor;
            if (model.Painter != null)
                model.LaborTotal +=(int)model.Carpenter;
            if (model.Painter != null)
                model.LaborTotal +=(int)model.Cleaner;
            if (model.Painter != null)
                model.LaborTotal +=(int)model.ELectricWelder;
            if (model.Painter != null)
                model.LaborTotal +=(int)model.OtherLabor;
            this.ProjectService.SaveInsLaborCost(model);
            return this.RefreshParent();
        }

        //
        // GET: /Project/Labor/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Labor/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteInsLaborCost(ids);
            return RedirectToAction("Index");
        }



    }
}
