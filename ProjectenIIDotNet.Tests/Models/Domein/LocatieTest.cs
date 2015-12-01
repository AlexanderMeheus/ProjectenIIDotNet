using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Tests.Dummies;

namespace ProjectenIIDotNet.Tests.Models.Domein
{
    [TestClass]
    public class LocatieTest
    {
        
        /*
         * Deze file test de klass Locatie.
         */

        private Klimatogram klimatogram;
        private Locatie locatie;

        [TestInitialize]
        public void LocatieTestSetup()
        {
            klimatogram = new KlimatogramNoordDummy();
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void ConstructorMetLegeStringGooitExceptie()
        {
            locatie = new Locatie("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorMetWhiteSpaceStringGooitExceptie()
        {
            locatie = new Locatie("   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorMetNullGooitExceptie()
        {
            locatie = new Locatie(null);
        }

        [TestMethod]
        public void NaConstructieIsNaamCorrectAangepast()
        {
            string naam = "Ukkel";
            locatie = new Locatie(naam);
            Assert.AreEqual(naam, locatie.Naam);
        }

        [TestMethod]
        public void NaConstructieGeeftLandNullTerug()
        {
            string naam = "Ukkel";
            locatie = new Locatie(naam);
            Assert.IsNull(locatie.Land);
        }

        [TestMethod]
        public void NaConstructieGeeftKlimatogramNullTerug()
        {
            string naam = "Ukkel";
            locatie = new Locatie(naam);
            Assert.IsNull(locatie.Klimatogram);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void LandToekennenGooitArgumentExceptionBijNull()
        {
            string naam = "Ukkel";
            locatie = new Locatie(naam);
            locatie.Land = null;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void KlimatogramToekennenGooitArgumentExceptionBijNull()
        {
            string naam = "Ukkel";
            locatie = new Locatie(naam);
            locatie.Klimatogram = null;
        }

        [TestMethod]
        public void KlimatogramToekennenEnOpvragenGeeftCorrecteKlimatogram()
        {
            string naam = "Ukkel";
            locatie = new Locatie(naam);
            locatie.Klimatogram = klimatogram;
            Assert.AreEqual(klimatogram,locatie.Klimatogram);
        }

        [TestMethod]
        public void LandToekennenEnOpvragenGeeftCorrectLand()
        {
            string naam = "Ukkel";
            locatie = new Locatie(naam);
            Land land = new Land("België");
            locatie.Land = land;
            Assert.AreEqual(land, locatie.Land);
        }
    }
}
