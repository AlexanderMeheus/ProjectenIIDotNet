using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Tests.Models.Domein
{
    [TestClass]
    public class ContinentTest
    {
        //Een nieuw continent wordt aangemaakt en er wordt een _naam gegeven
        [TestMethod]
        public void ContinentWordtAangemaaktEnKrijgtNaam()
        {
            Continent c = new Continent("Europa");
            Assert.IsNotNull(c);
            Assert.AreEqual("Europa", c.Naam);
        }

        //Een nieuw continent zonder correcte _naam kan niet worden aangemaakt
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContinentZonderNaamGeeftException()
        {
            Continent c = new Continent("");
        }

        //Een nieuw continent zonder correcte _naam kan niet worden aangemaakt
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContinentMetNaamNullGeeftException()
        {
            Continent c = new Continent(null);
        }

        //Een nieuw continent zonder correcte _naam kan niet worden aangemaakt
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContinentMetNaamWhitespaceGeeftException()
        {
            Continent c = new Continent("         ");
        }

        //VoegLandToe voegt ook werkelijk een land toe aan de lijst van landen
        [TestMethod]
        public void VoegLandToeVoegtEenLandToe()
        {
            Continent c = new Continent("TestContinent");
            Land belgië = new Land("België");
            c.VoegLandToe(belgië);
            Assert.IsTrue(c.Landen.Contains(belgië));
        }

        //Landen worden niet alfabetisch toegevoegd aan een continent en worden alfabetisch terug gegeven.
        [TestMethod]
        public void GeefLandenAlfabetischGeeftLandenAlfabetisch()
        {
            Continent c = new Continent("TestContinent");
            Land nederland = new Land("Nederland");
            Land belgië = new Land("België");
            Land albanië = new Land("Albanië");
            c.VoegLandToe(nederland);
            c.VoegLandToe(belgië);
            c.VoegLandToe(albanië);
            Assert.AreEqual(albanië, c.GeefLandenAlfabetisch().ElementAt(0));
            Assert.AreEqual(belgië, c.GeefLandenAlfabetisch().ElementAt(1));
            Assert.AreEqual(nederland, c.GeefLandenAlfabetisch().ElementAt(2));
        }

        //Attribuut continent van een land word aangepast na toevoegen van een land
        [TestMethod]
        public void LandToevoegenPastAttribuutContinentVanDatLandAan()
        {
            Continent c = new Continent("Europa");
            Land belgie = new Land("België");
            c.VoegLandToe(belgie);
            Assert.AreEqual(c, belgie.Continent);
        }

        //Land kan kan maar 1 maal toegevoegd worden
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void LandKanMaarEenMaalToegevoegdWorden()
        {
            Continent c = new Continent("Europa");
            Land ned = new Land("Nederland");
            c.VoegLandToe(ned);
            c.VoegLandToe(ned);
        }
    }
}
