using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectenIIDotNet;
using ProjectenIIDotNet.Controllers;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;
using ProjectenIIDotNet.Tests.Dummies;

namespace ProjectenIIDotNet.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        private HomeController controller;
        private IDeterminatieTreeRepository determinatieTreeRepository;

        [TestInitialize]
        public void InitHomeControllerTest()
        {
            determinatieTreeRepository = new DeterminatieTreeRepositoryDummy();
            controller = new HomeController(determinatieTreeRepository);
        }

        [TestMethod]
        public void IndexGeeftViewResult()
        {
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void StartApplicatieRedirectNaarIndexVanKlimatogramController()
        {
            //Arrange
            Leerling leerling = new Leerling();

            //Act
            var result = controller.StartApplicatie(leerling, Graad.graad2, Jaar.jaar1) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result, "Result is null");
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Klimatogram", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void StartApplicatieZetLeerlingOpActief()
        {
            //Arrange
            Leerling leerling = new Leerling();
            leerling.IsActief = false;

            //Act
            var result = controller.StartApplicatie(leerling, Graad.graad2, Jaar.jaar1) as RedirectToRouteResult;

            //Assert
            Assert.IsTrue(leerling.IsActief);
        }

        [TestMethod]
        public void StartApplicatieZetLeerlingGraadEnJaarCorrect()
        {
            //Arrange
            Leerling leerling = new Leerling();

            //Act
            var result = controller.StartApplicatie(leerling, Graad.graad2, Jaar.jaar1) as RedirectToRouteResult;

            //Assert
            Assert.AreEqual(Graad.graad2, leerling.Graad);
            Assert.AreEqual(Jaar.jaar1, leerling.Jaar);
        }

        [TestMethod]
        public void StartApplicatieZetLeerlingLocatieOpNull()
        {
            //Arrange
            Leerling leerling = new Leerling();

            //Act
            leerling.GekozenLocatie = new Locatie("Test");
            var result = controller.StartApplicatie(leerling, Graad.graad2, Jaar.jaar1) as RedirectToRouteResult;

            //Assert
            Assert.IsNull(leerling.GekozenLocatie);
        }

        [TestMethod]
        public void StartApplicatieZetLeerlingDeterminatieTreeOpDeCorrecteTree()
        {
            //Arrange
            Leerling leerling = new Leerling();

            //Act
            leerling.DeterminatieTabel = null;
            var result = controller.StartApplicatie(leerling, Graad.graad2, Jaar.jaar1) as RedirectToRouteResult;

            DeterminatieTree created = ((DeterminatieTreeRepositoryDummy) determinatieTreeRepository).GetCurrent();

            //Assert
            Assert.AreEqual(created, leerling.DeterminatieTabel);
        }

        [TestMethod]
        public void StopApplicatieRedirectNaarIndexVanHomeControllerMetLeerlingMetIsActiefTrue()
        {
            //Arrange
            Leerling leerling = new Leerling();
            leerling.IsActief = true;

            //Act
            var result = controller.StopApplicatie(leerling) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result, "Result is null");
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void StopApplicatieRedirectNaarIndexVanHomeControllerMetLeerlingMetIsActiefFalse()
        {
            //Arrange
            Leerling leerling = new Leerling();
            leerling.IsActief = false;

            //Act
            var result = controller.StopApplicatie(leerling) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result, "Result is null");
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void StopApplicatieZetLeerlingOpNietActiefMetLeerlingMetIsActiefTrue()
        {
            //Arrange
            Leerling leerling = new Leerling();
            leerling.IsActief = true;

            //Act
            var result = controller.StopApplicatie(leerling) as RedirectToRouteResult;

            //Assert
            Assert.IsFalse(leerling.IsActief);
        }

        [TestMethod]
        public void StopApplicatieZetLeerlingOpNietActiefMetLeerlingMetIsActiefFalse()
        {
            //Arrange
            Leerling leerling = new Leerling();
            leerling.IsActief = false;

            //Act
            var result = controller.StopApplicatie(leerling) as RedirectToRouteResult;

            //Assert
            Assert.IsFalse(leerling.IsActief);
        }
    }
}
