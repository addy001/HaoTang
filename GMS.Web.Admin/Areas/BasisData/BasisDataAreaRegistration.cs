using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.BasisData
{
    public class BasisDataAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BasisData";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BasisData_default",
                "BasisData/{controller}/{action}/{id}",
                new { action = "Default", id = UrlParameter.Optional }
            );
        }
    }
}
