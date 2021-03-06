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
    [Permission(EnumBusinessPermission.ProjectManage_File)]
    public class FilesController : AdminControllerBase
    {
        //
        // GET: /Cms/Files/

        public ActionResult Index(FileRequest request)
        {
          //  ViewData.Add("Channal", new SelectList(EnumHelper.GetItemValueList<EnumChannal>(), "Key", "Value"));
            var result = this.ProjectService.GetFileList(request);
            return View(result);
        }

        //
        // GET: /Cms/Files/Create

        public ActionResult Create()
        {
            var model = new Files();
            return View("Edit", model);
        }

        //
        // POST: /Cms/Files/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Files();
            this.TryUpdateModel<Files>(model);
            this.ProjectService.SaveFile(model);
            return this.RefreshParent();
        }

        //
        // GET: /Cms/Files/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetFile(id);
            return View(model);
        }

        //
        // POST: /Cms/Files/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetFile(id);
            this.TryUpdateModel<Files>(model);
            this.ProjectService.SaveFile(model);            
            return this.RefreshParent();
        }

        // POST: /Cms/Files/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteFile(ids);
            return RedirectToAction("Index");
        }
      
    } 
}
