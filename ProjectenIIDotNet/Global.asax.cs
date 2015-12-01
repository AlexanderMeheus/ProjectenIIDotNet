using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ProjectenIIDotNet.Infrastructure;
using ProjectenIIDotNet.Models.DAL;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(Leerling), new LeerlingModelBinder());

            //KlimatogramContext db = new KlimatogramContext();
            //db.Database.Initialize(true);
        }
    }
}
