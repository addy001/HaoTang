using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Account.Contract;
using GMS.Web.Admin.Common;
using GMS.Framework.Utility;
using GMS.Core.Log;

namespace GMS.Web.Admin.Areas.Account.Controllers
{
    [Permission(EnumBusinessPermission.AccountManage_Role)]
    public class LogController : AdminControllerBase
    {
        //
        // GET: /Account/Log/

        public ActionResult Index(LogRequest request)
        {
            var result = this.AccountService.GetLogList(request);
            return View(result);
        }

        //
        // GET: /Account/Role/Create

        public ActionResult Create()
        {
            var businessPermissionList = EnumHelper.GetItemValueList<EnumBusinessPermission>();
            this.ViewBag.BusinessPermissionList = new SelectList(businessPermissionList, "Key", "Value");

            var model = new AuditLog();
            return View("Edit", model);
        }

    }
}