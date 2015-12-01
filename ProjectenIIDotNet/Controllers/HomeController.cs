using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ProjectenIIDotNet.Models.DAL;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Controllers
{
    
    public class HomeController : Controller
    {

        private IDeterminatieTreeRepository determinatieTreeRepository;

        public HomeController(IDeterminatieTreeRepository determinatieTreeRepository)
        {
            this.determinatieTreeRepository = determinatieTreeRepository;
        }

        public ActionResult Index()
        { 
            return View();
        }

        [HttpGet]
        public ActionResult StartApplicatie(Leerling leerling, Graad graad, Jaar jaar)
        {
            try
            {
                if (leerling == null) leerling = new Leerling();
                leerling.Graad = graad;
                leerling.Jaar = jaar;
                leerling.IsActief = true;
                leerling.GekozenLocatie = null;
                leerling.DeterminatieTabel = determinatieTreeRepository.FindByGraad(graad).FirstOrDefault();
                return RedirectToAction("Index", "Klimatogram");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("StartApplicatie", ex.Message);
                return View("Index");
            }
        }

        public ActionResult StopApplicatie(Leerling leerling)
        {
            if (leerling == null) leerling = new Leerling();
            leerling.IsActief = false;
            leerling.DeterminatieTabel = null;
            leerling.GekozenLocatie = null;
            return RedirectToAction("Index", "Home");
        }

    }
}