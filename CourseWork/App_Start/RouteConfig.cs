using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CourseWork
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Account", "Account/{action}/{id}", new { controller = "Account", action = "Index", id = UrlParameter.Optional },
                new[] { "CourseWork.Controllers" });

            routes.MapRoute("ResidenceDTOes", "ResidenceDTOes/{action}/{id}", new { controller = "ResidenceDTOes", action = "Index", id = UrlParameter.Optional },
                new[] { "CourseWork.Controllers" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pages", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
