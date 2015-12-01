using System;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;
using ProjectenIIDotNet.Models.Domein.Determinatie.Parameters;
using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;
using ProjectenIIDotNet.Tests.Dummies;

namespace ProjectenIIDotNet.Tests.Models.Domein.Determinatie
{
    [TestClass]
    public class KlimatogramVraagTest
    {
        /*
         * Test de klimatogramvraag.
         * Er zijn 3 dummies voorzien om zekerheid te hebben over wat
         * de uitkomsten moeten zijn.
         * 
         * VergelijkingWaarDummy : heeft altijd waar in de methode vergelijk
         * VergelijkingOnwaarDummy : heeft altijd onwaar in de methode vergelijk
         * 
         * ParameterDummy : heeft altijd de waarde 1.0 als paramter
         * 
         * KlimatogramNoordDummy : de waarden hiervan zijn niet belangrijk
         * maar er dient wel een klimatogram meegegeven te worden vandaar dat
         * deze toch wordt gemaakt.
         */

        private Vergelijking onwaarVergelijking;
        private Vergelijking waarVergelijking;
        private Parameter param1;
        private Parameter param2;
        private Klimatogram klimatogram;
        private DeterminatieVraag vraag;

        [TestInitialize]
        public void SetupMijnTestKlasse()
        {
            onwaarVergelijking = new VergelijkingOnwaarDummy();
            waarVergelijking = new VergelijkingWaarDummy();
            param1 = new ParameterDummy();
            param2 = new ParameterDummy();
            klimatogram = new KlimatogramNoordDummy();
            vraag = new DeterminatieVraag();
        }

        // Een nieuwe Vraag heeft null terug voor al zijn gegevens
        [TestMethod]
        public void KlimatogramVraagGeeftNaConstructieNullVoorAlleGegevens()
        {
            // Assert
            Assert.IsNull(vraag.Parameter1);
            Assert.IsNull(vraag.Parameter2);
            Assert.IsNull(vraag.Vergelijking);
        }

        // Methode losop gooit argument exception als alle gegevens null zijn
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void LosOpGooitArgumentExceptionAlsAlleGegevensNullZijn()
        {
            // Act
            vraag.LosOp(klimatogram);
        }

        // Methode losop gooit argument exception als klimatogram null is
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void LosOpGooitArgumentExceptionAlsKlimatogramNullIs()
        {
            // Arrange
            vraag.Parameter1 = param1;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = waarVergelijking;
            // Act
            bool antwoord = vraag.LosOp(null);
        }

        // Methode losop gooit argument exception als parameter 1 ontbreekt
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void LosOpGooitArgumentExceptionAlsParameter1Ontbreekt()
        {
            // Arrange
            vraag.Parameter2 = param2;
            vraag.Vergelijking = waarVergelijking;
            // Act
            bool antwoord = vraag.LosOp(klimatogram);
        }

        // Methode losop gooit argument exception als parameter 2 ontbreekt
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void LosOpGooitArgumentExceptionAlsParameter2Ontbreekt()
        {
            // Arrange
            vraag.Parameter1 = param1;
            vraag.Vergelijking = waarVergelijking;
            // Act
            bool antwoord = vraag.LosOp(klimatogram);
        }

        // Methode losop gooit argument exception als vergelijkingType ontbreekt
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void LosOpGooitArgumentExceptionAlsVergelijkingOntbreekt()
        {
            // Arrange
            vraag.Parameter1 = param1;
            vraag.Parameter2 = param2;
            // Act
            bool antwoord = vraag.LosOp(klimatogram);
        }

        // Methode losop gooit argument exception als parameter 1 en vergelijkingType ontbreekt
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void LosOpGooitArgumentExceptionAlsParameter1EnVergelijkingOntbreken()
        {
            // Arrange
            vraag.Parameter2 = param2;
            // Act
            bool antwoord = vraag.LosOp(klimatogram);
        }

        // Methode losop gooit argument exception als parameter 2 en vergelijkingType ontbreekt
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void LosOpGooitArgumentExceptionAlsParameter2EnVergelijkingOntbreken()
        {
            // Arrange
            vraag.Parameter1 = param1;
            // Act
            bool antwoord = vraag.LosOp(klimatogram);
        }

        // Methode losop geeft true terug als vergelijkingType klopt
        [TestMethod]
        public void LosOpGeeftTrueAlsDeVergelijkingVanDe2ParamtersKlopt()
        {
            // Arrange
            vraag.Parameter1 = param1;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = waarVergelijking;
            // Assert
            Assert.IsTrue(vraag.LosOp(klimatogram));
        }

        // Methode losop geeft false terug als vergelijkingType niet klopt
        [TestMethod]
        public void LosOpGeeftFalseAlsDeVergelijkingVanDe2ParametersNietKlopt()
        {
            // Arrange
            vraag.Parameter1 = param1;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = onwaarVergelijking;
            // Assert
            Assert.IsFalse(vraag.LosOp(klimatogram));
        }

        // Methode GeefVerkorteVraag geeft de correcte layout terug
        [TestMethod]
        public void GeefVerkorteVraagGeeftCorrecteLayoutTerug()
        {
            // Arrange
            vraag.Parameter1 = param1;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = waarVergelijking;
            String oplossing = param1.Symbool + " " + waarVergelijking.Symbool + " " + param2.Symbool;
            // Act
            String layout = vraag.GeefVerkorteVraag();
            // Assert
            Assert.AreEqual(oplossing, layout);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void GeefVerkorteVraagGooitArgumentExceptionAlsParameter1NullIs()
        {
            vraag.Parameter1 = null;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = waarVergelijking;

            vraag.GeefVerkorteVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVerkorteVraagGooitArgumentExceptionAlsParameter2NullIs()
        {
            vraag.Parameter1 = param1;
            vraag.Parameter2 = null;
            vraag.Vergelijking = waarVergelijking;

            vraag.GeefVerkorteVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVerkorteVraagGooitArgumentExceptionAlsVergelijkingNullIs()
        {
            vraag.Parameter1 = param1;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = null;

            vraag.GeefVerkorteVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVerkorteVraagGooitArgumentExceptionAlsVergelijkingEnParameter1NullZijn()
        {
            vraag.Parameter1 = null;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = null;

            vraag.GeefVerkorteVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVerkorteVraagGooitArgumentExceptionAlsVergelijkingEnParameter2NullZijn()
        {
            vraag.Parameter1 = param1;
            vraag.Parameter2 = null;
            vraag.Vergelijking = null;

            vraag.GeefVerkorteVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVerkorteVraagGooitArgumentExceptionAlsParameter1EnParameter2NullZijn()
        {
            vraag.Parameter1 = null;
            vraag.Parameter2 = null;
            vraag.Vergelijking = waarVergelijking;

            vraag.GeefVerkorteVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVerkorteVraagGooitArgumentExceptionAlsParameter1EnParameter2EnVergelijkingNullZijn()
        {
            vraag.Parameter1 = null;
            vraag.Parameter2 = null;
            vraag.Vergelijking = null;

            vraag.GeefVerkorteVraag();
        }

        // Methode GeefVolledigeVraag geeft de correcte layout terug
        [TestMethod]
        public void GeefVolledigeVraagGeeftCorrecteLayoutTerug()
        {
            // Arrange
            vraag.Parameter1 = param1;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = waarVergelijking;
            String oplossing = param1.Benaming + " " + waarVergelijking.Benaming + " " + param2.Benaming;
            // Act
            String layout = vraag.GeefVolledigeVraag();
            // Assert
            Assert.AreEqual(oplossing, layout);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVolledigeVraagGooitArgumentExceptionAlsParameter1NullIs()
        {
            vraag.Parameter1 = null;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = waarVergelijking;

            vraag.GeefVolledigeVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVolledigeVraagGooitArgumentExceptionAlsParameter2NullIs()
        {
            vraag.Parameter1 = param1;
            vraag.Parameter2 = null;
            vraag.Vergelijking = waarVergelijking;

            vraag.GeefVolledigeVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVolledigeVraagGooitArgumentExceptionAlsVergelijkingNullIs()
        {
            vraag.Parameter1 = param1;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = null;

            vraag.GeefVolledigeVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVolledigeVraagGooitArgumentExceptionAlsVergelijkingEnParameter1NullZijn()
        {
            vraag.Parameter1 = null;
            vraag.Parameter2 = param2;
            vraag.Vergelijking = null;

            vraag.GeefVolledigeVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVolledigeVraagGooitArgumentExceptionAlsVergelijkingEnParameter2NullZijn()
        {
            vraag.Parameter1 = param1;
            vraag.Parameter2 = null;
            vraag.Vergelijking = null;

            vraag.GeefVolledigeVraag();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVolledigeVraagGooitArgumentExceptionAlsParameter1EnParameter2NullZijn()
        {
            vraag.Parameter1 = null;
            vraag.Parameter2 = null;
            vraag.Vergelijking = waarVergelijking;

            vraag.GeefVolledigeVraag();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeefVolledigeVraagGooitArgumentExceptionAlsParameter1EnParameter2EnVergelijkingNullZijn()
        {
            vraag.Parameter1 = null;
            vraag.Parameter2 = null;
            vraag.Vergelijking = null;

            vraag.GeefVolledigeVraag();
        }
    }
}
