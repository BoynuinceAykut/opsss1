using System.Web.Mvc;

namespace OgrenciPortal.UI.Areas.Ogrenci
{
    public class OgrenciAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Ogrenci";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Ogrenci_default",
                "Ogrenci/{controller}/{action}/{id}",
                new { controller = "Home" ,action = "Index", id = UrlParameter.Optional }

            );
        }
    }
}
