using ProjectenIIDotNet.Models.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectenIIDotNet.Controllers
{
    public class CustomActionFilter : ActionFilterAttribute
    {

        /**
         *  Leerling aanroepen of wordt deze meegegeven?
         * 
         *  Boven de methode (in de controller) die deze methode gebruikt: 
         *      [CustomActionFilter]
         *      als je dingen wilt meegeven zoals leerling:
         *      [CustomActionFilter leerling=value (Leerling)]
         *      
         *  Open Global.asx in App_start, in methode Application_Start():
         *      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         *      
         *  In app_start: filterConfig: methode RegisterGlobalFilters():
         *      (add in de methode)   filters.Add(new CustomActionFilter());
         *          add also: using ProjectenIIDotNet.Filters;
         *      
         * **/

        public Leerling leerling { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filter)
        {
            filter.HttpContext.Trace.Write("(Authenticating)Action Executing: " + filter.ActionDescriptor.ActionName);
             
            if ((!leerling.IsActief) || (leerling.DeterminatieTabel == null)) 
                filter.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "action", "Index"},
                    { "controller", "Home"}
                });


            base.OnActionExecuting(filter);
        }
    }
}