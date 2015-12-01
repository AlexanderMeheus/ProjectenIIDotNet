using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Controllers;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Tests.Dummies;
using System.Web.Mvc;
using System.Linq;
using ProjectenIIDotNet.ViewModels;
using System.Collections.Generic;

namespace ProjectenIIDotNet.Tests.Controllers
{
    [TestClass]
    public class KlimatogramControllerTest
    {
        private KlimatogramController controller;
        private IContinentRepository continentRepository;
        private IDeterminatieTreeRepository determinatieTreeRepository;

        [TestInitialize]
        public void InitKlimatogramControllerTest()
        {
            continentRepository = new ContinentRepositoryDummy();
            determinatieTreeRepository = new DeterminatieTreeRepositoryDummy();
            controller = new KlimatogramController(continentRepository, determinatieTreeRepository);
        }

        [TestMethod]
        public void TestIndexMetLeerlingNietActief()
        {
            Leerling l = new Leerling();
            l.IsActief = false;

            var result = controller.Index(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestIndexMetLeerlingGraad2()
        {
            Leerling l = new Leerling();
            l.Graad = Graad.graad2;
            l.IsActief = true;

            var result = controller.Index(l) as RedirectToRouteResult;

            Assert.IsTrue(l.IsActief);
            Assert.AreEqual("KlimatogramSelecteren", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void TestIndexMetLeerlingMetGraad3()
        {
            Leerling l = new Leerling();
            l.Graad = Graad.graad3;
            l.IsActief = true;

            var result = controller.Index(l) as RedirectToRouteResult;

            Assert.IsTrue(l.IsActief);
            Assert.AreEqual("StopApplicatie", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestKlimatogramSelecterenMetLeerlingNietActief()
        {
            Leerling l = new Leerling();
            l.IsActief = false;

            var result = controller.KlimatogramSelecteren(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestKlimatogramSelecterenMetLeerlingGraad3()
        {
            Leerling l = new Leerling();
            l.Graad = Graad.graad3;
            l.IsActief = true;

            var result = controller.KlimatogramSelecteren(l) as RedirectToRouteResult;

            Assert.IsTrue(l.IsActief);
            Assert.AreEqual("StopApplicatie", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestKlimatogramSelecterenMetLeerlingGraad2Jaar2()
        {
            Leerling l = new Leerling();
            l.Graad = Graad.graad2;
            l.Jaar = Jaar.jaar2;
            l.IsActief = true;

            var result = controller.KlimatogramSelecteren(l) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(Graad.graad2.ToString(), result.ViewBag.Graad);
            Assert.AreEqual(Jaar.jaar2.ToString(), result.ViewBag.Jaar);            
        }

        [TestMethod]
        public void TestGetContinentenMetLeerlingNietActief()
        {
            Leerling l = new Leerling();
            l.IsActief = false;

            var result = controller.GetContinenten(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestGetContinentenMetLeerlingIsActiefGraad2()
        {
            Leerling l = new Leerling();
            l.Graad = Graad.graad2;
            l.IsActief = true;

            var result = controller.GetContinenten(l) as JsonResult;

            IEnumerable<ContinentViewModel> continenten = (IEnumerable<ContinentViewModel>) result.Data;
                       
            
            Assert.AreEqual("Afrika", continenten.ElementAt(0).Naam);
            Assert.AreEqual("Europa", continenten.ElementAt(1).Naam);
        }

        [TestMethod]
        public void TestGetLandenMetLeerlingNietActief()
        {
            Leerling l = new Leerling();
            l.IsActief = false;

            var result = controller.GetLanden(l, "Europa") as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        
        [TestMethod]
        public void TestGetLandenMetLeerlingActief()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.GetLanden(l, "Europa") as JsonResult;

            IEnumerable<LandViewModel> landen = (IEnumerable<LandViewModel>) result.Data;

            Assert.AreEqual("België", landen.ElementAt(0).Naam); 
        }


        [TestMethod]
        public void TestGetLocatiesMetLeerlingNietActief()
        {
            Leerling l = new Leerling();
            l.IsActief = false;

            var result = controller.GetLocaties(l, "Europa", "België") as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestGetLocatiesMetLeerlingActief()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.GetLocaties(l, "Europa", "België") as JsonResult;

            IEnumerable<LocatieViewModel> locatie = (IEnumerable<LocatieViewModel>) result.Data;

            Assert.AreEqual("Gent-Melle", locatie.ElementAt(0).Naam);
        }

        [TestMethod]
        public void TestGetKlimatogramMetLeerlingNietActief()
        {
            Leerling l = new Leerling();
            l.IsActief = false;

            var result = controller.GetKlimatogram(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestGetKlimatogramMetLeerlingIsActiefGekozenLocatieIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.GetKlimatogram(l) as RedirectToRouteResult;

            Assert.IsNull(l.GekozenLocatie);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void TestGetKlimatogramMetLeerlingActiefGekozenLocatieIsNotNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;
            l.GekozenLocatie = continentRepository.GeefLocatie("Europa", "België", "Gent-Melle");//eventueel new object van locatie

            var result = controller.GetKlimatogram(l) as JsonResult;

            KlimatogramViewModel klimatogram = (KlimatogramViewModel) result.Data;

            Assert.AreEqual("Europa", klimatogram.ContinentNaam);
            Assert.AreEqual("België", klimatogram.LandNaam);
            Assert.AreEqual("Gent-Melle", klimatogram.LocatieNaam);
        }

        [TestMethod]
        public void TestSelecteerLocatieMetLeerlingNietActief()
        {
            Leerling l = new Leerling();
            l.IsActief = false;

            var result = controller.SelecteerLocatie(l, "Europa", "België", "Ukkel") as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestSelecteerLocatieMetLeerlingIsActiefGekozenLocatieIsNotNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.SelecteerLocatie(l, "Europa", "België", "Ukkel") as RedirectToRouteResult;

            Assert.IsNotNull(l.GekozenLocatie);
            Assert.AreEqual("ToonKlimatogram", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void TestSelecteerLocatieMetLeerlingIsActiefGekozenLocatieIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;
            l.GekozenLocatie = null;

            var result = controller.GetKlimatogram(l) as RedirectToRouteResult;

            Assert.IsNull(l.GekozenLocatie);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void TestToonKlimatogramMetLeerlingNietActief()
        {
            Leerling l = new Leerling();
            l.IsActief = false;

            var result = controller.ToonKlimatogram(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestToonKlimatogramMetLeerlingGraad3()
        {
            Leerling l = new Leerling();
            l.Graad = Graad.graad3;
            l.IsActief = true;

            var result = controller.ToonKlimatogram(l) as RedirectToRouteResult;

            Assert.IsTrue(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void TestToonKlimatogramMetLeerlingIsActiefGekozenLocatieIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.ToonKlimatogram(l) as RedirectToRouteResult;

            Assert.IsNull(l.GekozenLocatie);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

    }
}
