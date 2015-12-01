using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;
using ProjectenIIDotNet.ViewModels;

namespace ProjectenIIDotNet.Controllers
{
    public class DeterminatieController : Controller
    {

        public ActionResult Index(Leerling leerling)
        {
            if ((!leerling.IsActief) || (leerling.DeterminatieTabel == null)) return RedirectToAction("Index", "Home");
            if (leerling.GekozenLocatie == null) return RedirectToAction("Index", "Klimatogram");
            ViewBag.Graad = leerling.Graad.ToString();
            ViewBag.Jaar = leerling.Jaar.ToString();
            return View();
        }

        public ActionResult GetDeterminatieTree(Leerling leerling)
        {
            if ((!leerling.IsActief) || (leerling.DeterminatieTabel == null)) return RedirectToAction("Index", "Home");
            if (leerling.GekozenLocatie == null) return RedirectToAction("Index", "Klimatogram");
            return Json(new DeterminatieTreeViewModel(leerling.DeterminatieTabel), JsonRequestBehavior.AllowGet);
        }

        public ActionResult StapVerder(Leerling leerling, bool antwoord)
        {
            if ((!leerling.IsActief) || (leerling.DeterminatieTabel == null)) return RedirectToAction("Index", "Home");
            if (leerling.GekozenLocatie == null) return RedirectToAction("Index", "Klimatogram");
            if (!leerling.DeterminatieTabel.IsCompleet()) leerling.DeterminatieTabel.StapVerder(antwoord);
            return Json(new DeterminatieTreeViewModel(leerling.DeterminatieTabel), JsonRequestBehavior.AllowGet);
        }

        public ActionResult StapTerug(Leerling leerling)
        {
            if ((!leerling.IsActief) || (leerling.DeterminatieTabel == null)) return RedirectToAction("Index", "Home");
            if (leerling.GekozenLocatie == null) return RedirectToAction("Index", "Klimatogram");
            if (!leerling.DeterminatieTabel.IsBegin()) leerling.DeterminatieTabel.StapTerug();
            return Json(new DeterminatieTreeViewModel(leerling.DeterminatieTabel), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GeefOplossing(Leerling leerling)
        {
            if ((!leerling.IsActief) || (leerling.DeterminatieTabel == null)) return RedirectToAction("Index", "Home");
            if (leerling.GekozenLocatie == null) return RedirectToAction("Index", "Klimatogram");
            leerling.DeterminatieTabel.GaNaarCorrectKenmerk(leerling.GekozenLocatie.Klimatogram);
            return Json(new DeterminatieTreeViewModel(leerling.DeterminatieTabel), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetKenmerk(Leerling leerling)
        {
            if ((!leerling.IsActief) || (leerling.DeterminatieTabel == null)) return RedirectToAction("Index", "Home");
            if (leerling.GekozenLocatie == null) return RedirectToAction("Index", "Klimatogram");
            return Json(new KenmerkViewModel( leerling.DeterminatieTabel.DetermineerKenmerk(leerling.GekozenLocatie.Klimatogram)),
                    JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsDeterminatieCorrect(Leerling leerling, string klimaat)
        {
            if ((!leerling.IsActief) || (leerling.DeterminatieTabel == null)) return RedirectToAction("Index", "Home");
            if (leerling.GekozenLocatie == null) return RedirectToAction("Index", "Klimatogram");
            if (leerling.DeterminatieTabel.IsCompleet())
            {
                leerling.DeterminatieTabel.GaNaarLaatsteCorrecteStap(leerling.GekozenLocatie.Klimatogram);
                return
                    Json(
                        (klimaat.Equals(
                            leerling.DeterminatieTabel.DetermineerKenmerk(leerling.GekozenLocatie.Klimatogram)
                                .KlimaatKenmerk)), JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

	}
}