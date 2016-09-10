using ContosoSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ContosoSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            using (var dbTotalUser = new ContosoUniversityDataEntities())
            {
                Application["Totaluser"] = dbTotalUser.TotalUsers.FirstOrDefault().TotalUser1;
            }
        }

        protected void Session_Start()
        {
            Application.Lock();
            Application["Totaluser"] = (int)Application["Totaluser"] + 1 ;
            using (var dbInsertTotalUser = new ContosoUniversityDataEntities())
            {
                foreach (var b in dbInsertTotalUser.TotalUsers)
                {
                    b.TotalUser1 = (int)Application["Totaluser"];
                }
                dbInsertTotalUser.SaveChanges();
               
            }
                Application.UnLock();
        }
    }
}
