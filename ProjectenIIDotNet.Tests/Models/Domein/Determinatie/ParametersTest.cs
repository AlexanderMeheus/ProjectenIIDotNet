using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie.Parameters;
using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;
using ProjectenIIDotNet.Tests.Dummies;

namespace ProjectenIIDotNet.Tests.Models.Domein.Determinatie
{
    [TestClass]
    public class ParametersTest
    {
        
        /*
         * In deze testfile zullen alle soorten parameters getest worden.
         * Hiervoor zal een dummy klimatogram gebruikt worden om te weten
         * wat de uitkomst moet zijn.
         * 
         * Alle parameters zullen samen in deze testfile getest worden om
         * niet allemaal verschillende files met daarin 1 methode te hebben.
         * 
         * De klimatogramdummy noord en zuid bevatten gegevens van fictieve plaats.
         * Enkel is bij ene gezegd dat het van het zuidelijkhalfrond is en 
         * andere van noordelijk.
         * Deze dummies niet wijzigen want dan veranderen de uitkomsten hier
         * mogelijk ook.
         */

        private Parameter parameter;
        private Klimatogram klimatogramNoord;
        private Klimatogram klimatogramZuid;

        [TestInitialize]
        public void InitializeMyParameterTest()
        {
            klimatogramNoord = new KlimatogramNoordDummy();
            klimatogramZuid = new KlimatogramZuidDummy();
        }

        [TestMethod]
        public void AantalDrogeMaandenGeeftCorrectAantalDrogeMaanden()
        {
            parameter = new AantalDrogeMaandenParameter();
            Assert.AreEqual(2, parameter.GeefParameterWaarde(klimatogramNoord));
            Assert.AreEqual(2, parameter.GeefParameterWaarde(klimatogramZuid));
        }

        [TestMethod]
        public void AantalDrogeMaandenGeeftCorrecteSymboolEnBenaming()
        {
            parameter = new AantalDrogeMaandenParameter();
            Assert.AreEqual("D", parameter.Symbool);
            Assert.AreEqual("aantal droge maanden", parameter.Benaming);
        }

        [TestMethod]
        public void ConstanteWaardeGeeftIngesteldeWaardeTerug()
        {
            double vast = 4.2;
            parameter = new ConstanteWaardeParameter(vast);
            Assert.AreEqual(vast, parameter.GeefParameterWaarde(klimatogramNoord));
            Assert.AreEqual(vast, parameter.GeefParameterWaarde(klimatogramZuid));
        }

        [TestMethod]
        public void ConstanteWaardeGeeftCorrecteSymboolEnBenaming()
        {
            double vast = 4.3;
            parameter = new ConstanteWaardeParameter(vast);
            Assert.AreEqual("" + vast, parameter.Symbool);
            Assert.AreEqual("" + vast, parameter.Benaming);
        }

        [TestMethod]
        public void GemiddeldeJaarTemperatuurGeeftJuisteWaarde()
        {
            parameter = new GemiddeldeJaarTemperatuurParameter();
            Assert.AreEqual(klimatogramNoord.GeefGemiddeldeJaarTemperatuur(), parameter.GeefParameterWaarde(klimatogramNoord));
            Assert.AreEqual(klimatogramZuid.GeefGemiddeldeJaarTemperatuur(), parameter.GeefParameterWaarde(klimatogramZuid));
        }

        [TestMethod]
        public void GemiddeldeJaarTemperatuurGeeftCorrecteSymboolEnBenaming()
        {
            parameter = new GemiddeldeJaarTemperatuurParameter();
            Assert.AreEqual("Tj", parameter.Symbool);
            Assert.AreEqual("de gemiddelde jaartemperatuur in °C", parameter.Benaming);
        }

        [TestMethod]
        public void NeerslagWinterGeeftCorrecteHoeveelheidNeerslag()
        {
            int neerslagWinterNoordelijk = 419;
            int neerslagWinterZuidelijk = 316;
            parameter = new NeerslagWinterParameter();
            Assert.AreEqual(neerslagWinterNoordelijk, parameter.GeefParameterWaarde(klimatogramNoord));
            Assert.AreEqual(neerslagWinterZuidelijk, parameter.GeefParameterWaarde(klimatogramZuid));
        }

        [TestMethod]
        public void NeerslagWinterGeeftCorrecteSymboolEnBenaming()
        {
            parameter = new NeerslagWinterParameter();
            Assert.AreEqual("NW", parameter.Symbool);
            Assert.AreEqual("hoeveelheid neerslag in de winter", parameter.Benaming);
        }

        [TestMethod]
        public void NeerslagZomerGeeftCorrecteHoeveelheidNeerslag()
        {
            int neerslagZomerNoordelijk = 316;
            int neerslagZomerZuidelijk = 419;
            parameter = new NeerslagZomerParameter();
            Assert.AreEqual(neerslagZomerNoordelijk, parameter.GeefParameterWaarde(klimatogramNoord));
            Assert.AreEqual(neerslagZomerZuidelijk, parameter.GeefParameterWaarde(klimatogramZuid));
        }

        [TestMethod]
        public void NeerslagZomerGeeftCorrecteSymboolEnBenaming()
        {
            parameter = new NeerslagZomerParameter();
            Assert.AreEqual("NZ", parameter.Symbool);
            Assert.AreEqual("hoeveelheid neerslag in de zomer", parameter.Benaming);
        }

        [TestMethod]
        public void TemperatuurKoudsteMaandGeeftKoudsteTemperatuur()
        {
            double koudste = 2.5;
            parameter = new TemperatuurKoudsteMaandParameter();
            Assert.AreEqual(koudste, parameter.GeefParameterWaarde(klimatogramNoord));
            Assert.AreEqual(koudste, parameter.GeefParameterWaarde(klimatogramZuid));
        }

        [TestMethod]
        public void TemperatuurKoudsteMaandGeeftCorrecteSymboolEnBenaming()
        {
            parameter = new TemperatuurKoudsteMaandParameter();
            Assert.AreEqual("Tk", parameter.Symbool);
            Assert.AreEqual("temperatuur koudste maand", parameter.Benaming);
        }

        [TestMethod]
        public void TemperatuurWarmsteMaandGeeftWarmsteTemperatuur()
        {
            double warmste = 17.2;
            parameter = new TemperatuurWarmsteMaandParameter();
            Assert.AreEqual(warmste, parameter.GeefParameterWaarde(klimatogramNoord));
            Assert.AreEqual(warmste, parameter.GeefParameterWaarde(klimatogramZuid));
        }

        [TestMethod]
        public void TemperatuurWarmsteMaandGeeftCorrecteSymboolEnBenaming()
        {
            parameter = new TemperatuurWarmsteMaandParameter();
            Assert.AreEqual("Tw", parameter.Symbool);
            Assert.AreEqual("temperatuur warmste maand", parameter.Benaming);
        }

        [TestMethod]
        public void TotaleJaarNeerslagGeeftTotaleHoeveelheidNeerslagPerJaar()
        {
            int hoeveelheid = 735;
            parameter = new TotaleJaarNeerslagParameter();
            Assert.AreEqual(hoeveelheid, parameter.GeefParameterWaarde(klimatogramNoord));
            Assert.AreEqual(hoeveelheid, parameter.GeefParameterWaarde(klimatogramZuid));
        }

        [TestMethod]
        public void TotaleJaarNeerslagGeeftCorrecteSymboolEnBenaming()
        {
            parameter = new TotaleJaarNeerslagParameter();
            Assert.AreEqual("Nj", parameter.Symbool);
            Assert.AreEqual("de totale jaarneerslag in mm", parameter.Benaming);
        }

        [TestMethod]
        public void AantalMaandenMetNeerslagGeeftHetAantalMaandenDatAanVergelijkingVoldoet()
        {
            Vergelijking vDummy = new VergelijkingWaarDummy();
            parameter = new AantalMaandenMetNeerslagParameter(0, vDummy);
            Assert.AreEqual(12,parameter.GeefParameterWaarde(klimatogramNoord));
        }

        [TestMethod]
        public void AantalMaandenMetNeerslagGeeftCorrecteSymboolEnBenaming()
        {
            Vergelijking vDummy = new VergelijkingWaarDummy();
            parameter = new AantalMaandenMetNeerslagParameter(1, vDummy);
            string correctVol = "aantal maanden (met een gemiddelde neerslag " + vDummy.Benaming + " 1)";
            string correctKor = "# maanden (met Nm " + vDummy.Symbool + " 1)";
            Assert.AreEqual(correctVol, parameter.Benaming);
            Assert.AreEqual(correctKor, parameter.Symbool);
        }

        [TestMethod]
        public void AantalMaandenMetTemperatuurGeeftHetAantalMaandenDatAanVergelijkingVoldoet()
        {
            Vergelijking vDummy = new VergelijkingWaarDummy();
            parameter = new AantalMaandenMetTemperatuurParameter(0, vDummy);
            Assert.AreEqual(12, parameter.GeefParameterWaarde(klimatogramNoord));
        }

        [TestMethod]
        public void AantalMaandenMetTemperatuurGeeftCorrecteSymboolEnBenaming()
        {
            Vergelijking vDummy = new VergelijkingWaarDummy();
            parameter = new AantalMaandenMetTemperatuurParameter(2, vDummy);
            string correctVol = "aantal maanden (met een gemiddelde temperatuur " + vDummy.Benaming + " 2)";
            string correctKor = "# maanden (met Tm " + vDummy.Symbool + " 2)";
            Assert.AreEqual(correctVol, parameter.Benaming);
            Assert.AreEqual(correctKor, parameter.Symbool);
        }
    }
}
