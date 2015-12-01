using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectenIIDotNet.Controllers;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Tests.Dummies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ProjectenIIDotNet.ViewModels;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Tests.Controllers
{
    [TestClass]
    public class DeterminatieControllerTest
    {

        private DeterminatieController controller;
        private IDeterminatieTreeRepository determinatieTreeRepository;
        private KlimatogramDummyCreator klimatogramDummy;
        private Klimatogram klimatogram;

        [TestInitialize]
        public void InitDeterminatieControllerTest()
        {
            this.controller = new DeterminatieController();
            this.determinatieTreeRepository = new DeterminatieTreeRepositoryDummy();
            klimatogramDummy = new KlimatogramDummyCreator();
            klimatogram = klimatogramDummy.GeefNieuwKlimatogram();
        }

        [TestMethod]
        public void TestIndexMetLeerlingNietActief()
        {
            Leerling l = new Leerling();
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();//anders test ie 2x of tabel null is...

            var result = controller.Index(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestIndexMetLeerlingNietActiefDeterminatieTabelNull()
        {
            Leerling l = new Leerling();

            var result = controller.Index(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestIndexMetDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.Index(l) as RedirectToRouteResult;

            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestIndexMetLeerlingIsActiefGekozenLocatieIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();         

            var result = controller.Index(l) as RedirectToRouteResult;

            Assert.IsNull(l.GekozenLocatie);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Klimatogram", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestIndexGeeftViewResult()
        {
            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();      
            l.GekozenLocatie = new Locatie("Ukkel");
   
            // Act
            ViewResult result = controller.Index(l) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetDeterminatieTreeMetLeerlingNietActief()
        {
            Leerling l = new Leerling();
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.GetDeterminatieTree(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestGetDeterminatieTreeMetLeerlingNietActiefDeterminatieTabelNull()
        {
            Leerling l = new Leerling();

            var result = controller.GetDeterminatieTree(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }


        [TestMethod]
        public void TestGetDeterminatieTreeMetDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.GetDeterminatieTree(l) as RedirectToRouteResult;

            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestGetDeterminatieTreeMetLeerlingIsActiefGekozenLocatieIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();            

            var result = controller.GetDeterminatieTree(l) as RedirectToRouteResult;

            Assert.IsNull(l.GekozenLocatie);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Klimatogram", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestGetDeterminatieTreeMetLeerlingIsActiefGekozenLocatieIsNotNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();
            l.GekozenLocatie = new Locatie("Ukkel");

            var result = controller.GetDeterminatieTree(l) as JsonResult;

            DeterminatieTreeViewModel tabel = (DeterminatieTreeViewModel) result.Data;

            Assert.IsNotNull(tabel);
        }

        [TestMethod]
        public void TestStapVerderMetLeerlingIsNotActief()
        {
            Leerling l = new Leerling();
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.StapVerder(l, true) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestStapVerderMetLeerlingIsNotActiefDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();

            var result = controller.StapVerder(l, true) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }


        [TestMethod]
        public void TestStapVerderMetLeerlingIsActiefDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.StapVerder(l, true) as RedirectToRouteResult;

            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestStapVerderMetLeerlingActiefDeterminatieTabelNotNullGekozenLocatieNull()
        {

            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.StapVerder(l, true) as RedirectToRouteResult;

            Assert.IsNull(l.GekozenLocatie);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Klimatogram", result.RouteValues["Controller"]);

        }

        [TestMethod]
        public void TestStapVerderMetDeterminatieTabelCompletedIsFalse()
        {

            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();
            l.GekozenLocatie = new Locatie("Ukkel");
            
            var result = controller.StapVerder(l, true) as JsonResult;

            DeterminatieTreeViewModel tabel = (DeterminatieTreeViewModel)result.Data;

            Assert.IsNotNull(tabel);//? is dit wat ik moet teste, gwn zien da ie geen null is? of specifieke waarde vergelijke?
        }

        [TestMethod]
        public void TestStapTerugMetLeerlingNotActief()
        {
            Leerling l = new Leerling();
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.StapTerug(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestStapTerugMetLeerlingIsNotActiefDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();

            var result = controller.StapTerug(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }


        [TestMethod]
        public void TestStapTerugMetLeerlingIsActiefDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.StapTerug(l) as RedirectToRouteResult;

            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestStapTerugMetLeerlingActiefDeterminatieTabelNotNullGekozenLocatieNull()
        {

            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.StapTerug(l) as RedirectToRouteResult;

            Assert.IsNull(l.GekozenLocatie);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Klimatogram", result.RouteValues["Controller"]);

        }

        [TestMethod]
        public void TestStapTerugMetDeterminatieTabelCompletedIsFalse()
        {

            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();
            l.GekozenLocatie = new Locatie("Ukkel");

            var result = controller.StapTerug(l) as JsonResult;

            DeterminatieTreeViewModel tabel = (DeterminatieTreeViewModel)result.Data;

            Assert.IsNotNull(tabel);//? is dit wat ik moet teste, gwn zien da ie geen null is? of specifieke waarde vergelijke?
        }

        [TestMethod]
        public void TestGeefOplossingMetLeerlingNotActief()
        {
            Leerling l = new Leerling();
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.GeefOplossing(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestGeefOplossingMetLeerlingIsNotActiefDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();

            var result = controller.GeefOplossing(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }


        [TestMethod]
        public void TestGeefOplossingMetLeerlingIsActiefDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.GeefOplossing(l) as RedirectToRouteResult;

            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestGeefOplossingMetLeerlingActiefDeterminatieTabelNotNullGekozenLocatieNull()
        {

            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.GeefOplossing(l) as RedirectToRouteResult;

            Assert.IsNull(l.GekozenLocatie);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Klimatogram", result.RouteValues["Controller"]);

        }

        [TestMethod]
        public void TestGeefOplossing()
        {

            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();
            l.GekozenLocatie = new Locatie("Ukkel");
            l.GekozenLocatie.Klimatogram = this.klimatogram;//weet niet of dit helemaal juist is? maar klimatogram mag niet null zijn...

            var result = controller.GeefOplossing(l) as JsonResult;

            DeterminatieTreeViewModel tabel = (DeterminatieTreeViewModel)result.Data;

            Assert.IsNotNull(tabel);//? is dit wat ik moet teste, gwn zien da ie geen null is? of specifieke waarde vergelijke?
        }

        [TestMethod]
        public void TestGetKenmerkMetLeerlingNotActief()
        {
            Leerling l = new Leerling();
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.GetKenmerk(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestGetKenmerkMetLeerlingIsNotActiefDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();

            var result = controller.GetKenmerk(l) as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }


        [TestMethod]
        public void TestGetKenmerkMetLeerlingIsActiefDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.GetKenmerk(l) as RedirectToRouteResult;

            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestGetKenmerkMetLeerlingActiefDeterminatieTabelNotNullGekozenLocatieNull()
        {

            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.GetKenmerk(l) as RedirectToRouteResult;

            Assert.IsNull(l.GekozenLocatie);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Klimatogram", result.RouteValues["Controller"]);

        }

        [TestMethod]
        public void TestGetKenmerk()
        {

            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();
            l.GekozenLocatie = new Locatie("Ukkel");
            l.GekozenLocatie.Klimatogram = this.klimatogram;//weet niet of dit helemaal juist is? maar klimatogram mag niet null zijn...

            var result = controller.GetKenmerk(l) as JsonResult;

            KenmerkViewModel kenmerk = (KenmerkViewModel)result.Data;

            Assert.IsNotNull(kenmerk);//? is dit wat ik moet teste, gwn zien da ie geen null is? of specifieke waarde vergelijke?
        }

        [TestMethod]
        public void TestIsDeterminatieCorrectMetLeerlingNotActief()
        {
            Leerling l = new Leerling();
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.IsDeterminatieCorrect(l, "koud") as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestIsDeterminatieCorrectMetLeerlingIsNotActiefDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();

            var result = controller.IsDeterminatieCorrect(l, "koud") as RedirectToRouteResult;

            Assert.IsFalse(l.IsActief);
            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }


        [TestMethod]
        public void TestIsDeterminatieCorrectMetLeerlingIsActiefDeterminatieTabelIsNull()
        {
            Leerling l = new Leerling();
            l.IsActief = true;

            var result = controller.IsDeterminatieCorrect(l, "koud") as RedirectToRouteResult;

            Assert.IsNull(l.DeterminatieTabel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestIsDeterminatieCorrectMetLeerlingActiefDeterminatieTabelNotNullGekozenLocatieNull()
        {

            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();

            var result = controller.IsDeterminatieCorrect(l, "koud") as RedirectToRouteResult;

            Assert.IsNull(l.GekozenLocatie);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Klimatogram", result.RouteValues["Controller"]);

        }

        [TestMethod]
        public void TestIsDeterminatieCorrectDeterminatieTableIsNotCompleet()
        {
            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).FirstOrDefault();
            l.GekozenLocatie = new Locatie("Ukkel");

            var result = controller.IsDeterminatieCorrect(l, "koud") as JsonResult;

            bool kenmerk = (bool) result.Data;

            Assert.AreEqual(false, kenmerk);//returned false als hij niet compleet is
       }

        [TestMethod]
        public void TestIsDeterminatieCorrectDeterminatieTableIsCompleet()
        {
            Leerling l = new Leerling();
            l.IsActief = true;
            l.DeterminatieTabel = determinatieTreeRepository.FindByGraad(l.Graad).LastOrDefault();
            l.GekozenLocatie = new Locatie("Ukkel");
            l.GekozenLocatie.Klimatogram = this.klimatogram;//weet niet of dit helemaal juist is? maar klimatogram mag niet null zijn...
            l.DeterminatieTabel.StapVerder(true);//laatste stap om te zien of hij compleet is

            var result = controller.IsDeterminatieCorrect(l, "koud") as JsonResult;

            bool kenmerk = (bool)result.Data;

            Assert.AreEqual(false, kenmerk);//waarom false?????
        }



    }
}
