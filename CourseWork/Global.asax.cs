using CourseWork.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CourseWork
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest()
        {
            if (User == null)
                return;

            string userName = Context.User.Identity.Name;

            string[] roles = null;

            using(HotelDb db = new HotelDb())
            {
                UserDTO dto = db.User.FirstOrDefault(x => x.Username == userName);
                if (dto == null)
                    return;
                roles = db.UserRole.Where(x => x.UserID == dto.UserID).Select(x => x.Role.Name).ToArray();
            }

            IIdentity userIdentity = new GenericIdentity(userName);
            IPrincipal newUserObj = new GenericPrincipal(userIdentity, roles);

            Context.User = newUserObj;
        }

    }
}
