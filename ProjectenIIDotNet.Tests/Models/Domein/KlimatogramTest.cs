using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Tests.Dummies;

namespace ProjectenIIDotNet.Tests.Models.Domein
{
    [TestClass]
    public class KlimatogramTest
    {
        private KlimatogramDummyCreator klimatogramDummy;
        private Klimatogram klimatogram;
        
        //Wat testgegevens voorzien en berekenen
        [TestInitialize]
        public void TestInit()
        {
            klimatogramDummy = new KlimatogramDummyCreator();
            klimatogram = klimatogramDummy.GeefNieuwKlimatogram();
        }

        //Kijken of de constructor zijn werk doet.
        //Enkel de properties hier testen dus niet de methodes
        [TestMethod]
        public void AanmakenNieuwKlimatogramZetGegevensCorrect()
        {
            Assert.AreEqual(klimatogramDummy.GeefStartWaarnemingen(), klimatogram.StartWaarnemingen);
            Assert.AreEqual(klimatogramDummy.GeefEindeWaarnemingen(), klimatogram.EindeWaarnemingen);
            Assert.AreEqual(klimatogramDummy.GeefBreedtegraad(), klimatogram.Breedtegraad);
            Assert.AreEqual(klimatogramDummy.GeefLengtegraad(), klimatogram.Lengtegraad);
            //Assert.AreEqual(klimatogramDummy.IsNoordelijkHalfrond(), klimatogram.NoordelijkHalfrond);
        }

        //NoordelijkHalfrond haalt correct uit de gegevens het halfrond
        [TestMethod]
        public void NoordelijkHalfrondHaaltCorrecteHalfrondUitDeGegevens()
        {
            Assert.IsTrue(klimatogram.NoordelijkHalfrond);
        }

        //GeefCoordinaten geeft coordinaten in graden structuur
        [TestMethod]
        public void GeefCoordinatenGeeftCorrecteStructuurEnWaarden()
        {
            string correct = klimatogramDummy.GeefCoordinaten();
            string uitkomst = klimatogram.GeefCoordinaten();
            Assert.AreEqual(correct, uitkomst);
        }

        //Methode voor opvragen temperatuur van maand testen
        [TestMethod]
        public void GeefGemiddeldeMaandTemperatuurGeeftDeCorrecteTemperatuur()
        {
            foreach (Maand maand in Enum.GetValues(typeof(Maand)))
            {
                Assert.AreEqual(klimatogramDummy.GeefTemperatuurVanMaand(maand), klimatogram.GeefGemiddeldeMaandTemperatuur(maand));
            }
        }

        //Methode voor opvragen neerslag van maand testen
        [TestMethod]
        public void GeefTotaleMaandNeerslagGeeftDeCorrecteNeerslag()
        {
            foreach (Maand maand in Enum.GetValues(typeof(Maand)))
            {
                Assert.AreEqual(klimatogramDummy.GeefNeerslagVanMaand(maand), klimatogram.GeefTotaleMaandNeerslag(maand));
            }
        }

        //Methode voor gemiddelde jaar temperatuur berekent correct
        [TestMethod]
        public void GeefGemiddeldeJaarTemperatuurBerekenCorrect()
        {
            Assert.AreEqual(klimatogramDummy.GeefGemiddeldeJaarTemperatuur(), klimatogram.GeefGemiddeldeJaarTemperatuur());
        }

        //Methode voor totale jaar neerslag berekent correct
        [TestMethod]
        public void GeefTotaleJaarNeerslagBerekentCorrect()
        {
            Assert.AreEqual(klimatogramDummy.GeefTotaleJaarNeerslag(), klimatogram.GeefTotaleJaarNeerslag());
        }

        [TestMethod]
        public void GeefAantalDrogeMaandenBerekenCorrect()
        {
            Assert.AreEqual(klimatogramDummy.GeefAantalDrogeMaanden(), klimatogram.GeefAantalDrogeMaanden());
        }

        [TestMethod]
        public void GeefDeKoudsteMaandBerekenCorrect()
        {
            Assert.AreEqual(klimatogramDummy.GeefDeKoudsteMaand(), klimatogram.GeefDeKoudsteMaand());
        }

        [TestMethod]
        public void GeefDeWarmsteMaandBerekenCorrect()
        {
            Assert.AreEqual(klimatogramDummy.GeefDeWarmsteMaand(), klimatogram.GeefDeWarmsteMaand());
        }

        [TestMethod]
        public void GeefNeerslagWinterBerekenCorrect()
        {
            Assert.AreEqual(klimatogramDummy.GeefNeerslagWinter(), klimatogram.GeefNeerslagWinter());
        }

        [TestMethod]
        public void GeefNeerslagZomerBerekenCorrect()
        {
            Assert.AreEqual(klimatogramDummy.GeefNeerslagZomer(), klimatogram.GeefNeerslagZomer());
        }

        [TestMethod]
        public void GeefTemperatuurKoudsteMaandBerekenCorrect()
        {
            Assert.AreEqual(klimatogramDummy.GeefTemperatuurKoudsteMaand(), klimatogram.GeefTemperatuurKoudsteMaand());
        }

        [TestMethod]
        public void GeefTemperatuurWarmsteMaandBerekenCorrect()
        {
            Assert.AreEqual(klimatogramDummy.GeefTemperatuurWarmsteMaand(), klimatogram.GeefTemperatuurWarmsteMaand());
        }

    }
}
