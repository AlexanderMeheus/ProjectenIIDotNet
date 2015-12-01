using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Infrastructure
{
    public class LeerlingModelBinder : IModelBinder
    {
        private const string LeerlingSessionKey = "leerling";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Leerling leerling = controllerContext.HttpContext.Session[LeerlingSessionKey] as Leerling;
            if (leerling == null)
            {
                leerling = new Leerling();
                leerling.IsActief = false;
                leerling.DeterminatieTabel = null;
                leerling.GekozenLocatie = null;
                leerling.AantalPogingenVragen = null;
                controllerContext.HttpContext.Session[LeerlingSessionKey] = leerling;
            }
            return leerling;
        }
    }
}