using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Tests.Models.Domein
{
    [TestClass]
    public class LandTest
    {
        //Een nieuw land wordt aangemaakt en er wordt een _naam gegeven
        [TestMethod]
        public void LandWordtAangemaaktEnKrijgtNaam()
        {
            Land l = new Land("België");
            Assert.IsNotNull(l);
            Assert.AreEqual("België", l.Naam);
        }

        //Een nieuw land zonder _naam kan niet worden aangemaakt
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LandZonderNaamGeeftException()
        {
            Land c = new Land("");
        }

        //Een nieuw land zonder _naam kan niet worden aangemaakt
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LandMetNaamNullGeeftException()
        {
            Land c = new Land(null);
        }

        //Een nieuw land zonder _naam kan niet worden aangemaakt
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LandMetNaamWhitespaceGeeftException()
        {
            Land c = new Land("         ");
        }

        //VoegLocatieToe voegt ook werkelijk een locatie toe aan de lijst van locaties
        [TestMethod]
        public void VoegLocatieToeVoegtEenLocatieToe()
        {
            Land belgië = new Land("België");
            Locatie gent = new Locatie("TestLocatie");
            belgië.VoegLocatieToe(gent);
            Assert.IsTrue(belgië.Locaties.Contains(gent));
        }

        //Locaties worden niet alfabetisch toegevoegd aan een land en worden alfabetisch terug gegeven.
        [TestMethod]
        public void GeefLocatiesAlfabetischGeeftLocatiesAlfabetisch()
        {
            Land l = new Land("Testland");
            Locatie gent = new Locatie("Gent");
            Locatie zomergem = new Locatie("Zomergem");
            Locatie antwerpen = new Locatie("Antwerpen");
            l.VoegLocatieToe(gent);
            l.VoegLocatieToe(zomergem);
            l.VoegLocatieToe(antwerpen);
            Assert.AreEqual(antwerpen, l.GeefLocatiesAlfabetisch().ElementAt(0));
            Assert.AreEqual(gent, l.GeefLocatiesAlfabetisch().ElementAt(1));
            Assert.AreEqual(zomergem, l.GeefLocatiesAlfabetisch().ElementAt(2));
        }

        //Attribuut land van een locatie word aangepast na toevoegen van een locatie
        [TestMethod]
        public void LandToevoegenPastAttribuutContinentVanDatLandAan()
        {
            Land belgie = new Land("België");
            Locatie ukkel = new Locatie("Ukkel");
            belgie.VoegLocatieToe(ukkel);
            Assert.AreEqual(belgie, ukkel.Land);
        }

        //Locatie kan maar 1 maal toegevoegd worden
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void LocatieKanSlechtsEenmaalToegevoegdWorden()
        {
            Land l = new Land("België");
            Locatie naz = new Locatie("Nazareth");
            l.VoegLocatieToe(naz);
            l.VoegLocatieToe(naz);
        }
    }
}

