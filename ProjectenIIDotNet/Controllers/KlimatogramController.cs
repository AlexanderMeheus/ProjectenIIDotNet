using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.VragenEersteGraad;
using ProjectenIIDotNet.ViewModels;
using WebGrease.Css.Extensions;

namespace ProjectenIIDotNet.Controllers
{
    public class KlimatogramController : Controller
    {

        private IContinentRepository continentRepository;
        private IDeterminatieTreeRepository determinatieTreeRepository;

        public KlimatogramController(IContinentRepository continentRepository, IDeterminatieTreeRepository determinatieTreeRepository)
        {
            this.continentRepository = continentRepository;
            this.determinatieTreeRepository = determinatieTreeRepository;
        }

        //Index pagina waar beslist wordt wat er moet gebeuren
        //Hier is er geen view van deze fungeert enkel en alleen
        //als director die zegt waar naar toe.
        public ActionResult Index(Leerling leerling)
        {
            if (!leerling.IsActief) return RedirectToAction("Index", "Home");
            if (leerling.Graad == Graad.graad1 || leerling.Graad == Graad.graad2)
                return RedirectToAction("KlimatogramSelecteren");
            else
                return RedirectToAction("StopApplicatie", "Home");
        }

        public ActionResult KlimatogramSelecteren(Leerling leerling)
        {
            if (!leerling.IsActief) return RedirectToAction("Index", "Home");
            if (leerling.Graad == Graad.graad3) return RedirectToAction("StopApplicatie", "Home");
            ViewBag.Graad = leerling.Graad.ToString();
            ViewBag.Jaar = leerling.Jaar.ToString();
            return View();
        }

        public ActionResult GetContinenten(Leerling leerling)
        {
            if (!leerling.IsActief) return RedirectToAction("Index", "Home");
            ICollection<Continent> continenten = continentRepository.GeefAlleContinentenAlfabetisch(leerling.Graad);
            return Json(continenten.Select(c => new ContinentViewModel(c)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLanden(Leerling leerling, string continentNaam)
        {
            if (!leerling.IsActief) return RedirectToAction("Index", "Home");
            ICollection<Land> landen = continentRepository.GeefAlleLandenAlfabetisch(continentNaam);
            return Json(landen.Select(l => new LandViewModel(l)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocaties(Leerling leerling, string continentNaam, string landNaam)
        {
            if (!leerling.IsActief) return RedirectToAction("Index", "Home");
            ICollection<Locatie> locaties = continentRepository.GeefAlleLocatiesAlfabetisch(continentNaam, landNaam);
            return Json(locaties.Select(l => new LocatieViewModel(l)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetKlimatogram(Leerling leerling)
        {
            if (!leerling.IsActief) return RedirectToAction("Index", "Home");
            if (leerling.GekozenLocatie == null) return RedirectToAction("Index");
            return Json(new KlimatogramViewModel(leerling.GekozenLocatie), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SelecteerLocatie(Leerling leerling, string continentNaam, string landNaam,
            string locatieNaam)
        {
            if (!leerling.IsActief) return RedirectToAction("Index", "Home");
            leerling.GekozenLocatie = continentRepository.GeefLocatie(continentNaam, landNaam, locatieNaam);
            //if (leerling.GekozenLocatie != null) return RedirectToAction("ToonKlimatogram");
            if (leerling.GekozenLocatie != null)
            {
                if (leerling.Graad == Graad.graad1) return RedirectToAction("ToonVragenEersteGraad");
                else return RedirectToAction("Index", "Determinatie");
            }
            return RedirectToAction("Index");
        }

        public ActionResult ToonKlimatogram(Leerling leerling)
        {
            if (!leerling.IsActief) return RedirectToAction("Index", "Home");
            if (leerling.Graad == Graad.graad3) return RedirectToAction("Index");
            if (leerling.GekozenLocatie == null) return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public ActionResult ToonVragenEersteGraad(Leerling leerling)
        {
            if (!leerling.IsActief || leerling.Graad != Graad.graad1) return RedirectToAction("Index", "Home");
            leerling.AantalPogingenVragen = 1;
            Klimatogram k = leerling.GekozenLocatie.Klimatogram;
            ViewBag.AntwoordenTemperatuurWarmsteMaand = new TemperatuurWarmsteMaandVraag(k).GeefMogelijkeAntwoorden().ToArray();
            ViewBag.AntwoordenTemperatuurKoudsteMaand = new TemperatuurKoudsteMaandVraag(k).GeefMogelijkeAntwoorden().ToArray();
            ViewBag.AntwoordenAantalDrogeMaanden = new AantalDrogeMaandenVraag(k).GeefMogelijkeAntwoorden().ToArray();
            return View(new VragenEersteGraadViewModel());
        }
            
        [HttpPost, ActionName("ToonVragenEersteGraad")]
        public ActionResult ToonVragenEersteGraad(Leerling leerling, VragenEersteGraadViewModel vm)
        {
            Klimatogram k = leerling.GekozenLocatie.Klimatogram;
            if (leerling.AantalPogingenVragen == 1)
            {
                if ((double) vm.WarmsteMaandVraag != new WarmsteMaandVraag(k).LosOp())
                    ModelState.AddModelError("WarmsteMaandVraag", "Warmste maand niet correct!");
                if (Double.Parse(vm.TemperatuurWarmsteMaandVraag) != new TemperatuurWarmsteMaandVraag(k).LosOp())
                    ModelState.AddModelError("TemperatuurWarmsteMaandVraag", "Temperatuur warmste maand niet correct!");
                if ((double) vm.KoudsteMaandVraag != new KoudsteMaandVraag(k).LosOp())
                    ModelState.AddModelError("KoudsteMaandVraag", "Koudste maand niet correct!");
                if (Double.Parse(vm.TemperatuurKoudsteMaandVraag) != new TemperatuurKoudsteMaandVraag(k).LosOp())
                    ModelState.AddModelError("TemperatuurKoudsteMaandVraag", "Temperatuur Koudste maand niet correct!");
                if (vm.AantalDrogeMaandenVraag != new AantalDrogeMaandenVraag(k).LosOp())
                    ModelState.AddModelError("AantalDrogeMaandenVraag", "Aantal droge maanden niet correct!");
                if (vm.NeerslagWinterVraag != new NeerslagWinterVraag(k).LosOp())
                    ModelState.AddModelError("NeerslagWinterVraag", "Neerslag winter niet correct!");
                if (vm.NeerslagZomerVraag != new NeerslagZomerVraag(k).LosOp())
                    ModelState.AddModelError("NeerslagZomerVraag", "Neerslag zomer niet correct!");
            }
            else
            {
                if ((double)vm.WarmsteMaandVraag != new WarmsteMaandVraag(k).LosOp())
                    ModelState.AddModelError("WarmsteMaandVraag", "Warmste maand niet correct! Het juiste antwoord is: " + Enum.GetName(typeof(Maand), (Int32)new WarmsteMaandVraag(k).LosOp()));
                if (Double.Parse(vm.TemperatuurWarmsteMaandVraag) != new TemperatuurWarmsteMaandVraag(k).LosOp())
                    ModelState.AddModelError("TemperatuurWarmsteMaandVraag", "Temperatuur warmste maand niet correct! Het juiste antwoord is: " + new TemperatuurWarmsteMaandVraag(k).LosOp());
                if ((double)vm.KoudsteMaandVraag != new KoudsteMaandVraag(k).LosOp())
                    ModelState.AddModelError("KoudsteMaandVraag", "Koudste maand niet correct! Het juiste antwoord is: " + Enum.GetName(typeof(Maand), (Int32)new WarmsteMaandVraag(k).LosOp()));
                if (Double.Parse(vm.TemperatuurKoudsteMaandVraag) != new TemperatuurKoudsteMaandVraag(k).LosOp())
                    ModelState.AddModelError("TemperatuurKoudsteMaandVraag", "Temperatuur Koudste maand niet correct! Het juiste antwoord is: " + new TemperatuurKoudsteMaandVraag(k).LosOp());
                if (vm.AantalDrogeMaandenVraag != new AantalDrogeMaandenVraag(k).LosOp())
                    ModelState.AddModelError("AantalDrogeMaandenVraag", "Aantal droge maanden niet correct! Het juiste antwoord is: " + new AantalDrogeMaandenVraag(k).LosOp());
                if (vm.NeerslagWinterVraag != new NeerslagWinterVraag(k).LosOp())
                    ModelState.AddModelError("NeerslagWinterVraag", "Neerslag winter niet correct! Het juiste antwoord is: " + new NeerslagWinterVraag(k).LosOp());
                if (vm.NeerslagZomerVraag != new NeerslagZomerVraag(k).LosOp())
                    ModelState.AddModelError("NeerslagZomerVraag", "Neerslag zomer niet correct! Het juiste antwoord is: " + new NeerslagZomerVraag(k).LosOp());
            }
            leerling.AantalPogingenVragen++;
            if(ModelState.IsValid)
                return RedirectToAction("Index", "Determinatie");
            ViewBag.AntwoordenTemperatuurWarmsteMaand = new TemperatuurWarmsteMaandVraag(k).GeefMogelijkeAntwoorden().ToArray();
            ViewBag.AntwoordenTemperatuurKoudsteMaand = new TemperatuurKoudsteMaandVraag(k).GeefMogelijkeAntwoorden().ToArray();
            ViewBag.AntwoordenAantalDrogeMaanden = new AantalDrogeMaandenVraag(k).GeefMogelijkeAntwoorden().ToArray();
            return View(vm);
        }
    }
}