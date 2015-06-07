using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Basedata
{
    public class BasedataAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Basedata";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Basedata_default",
                "Basedata/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
