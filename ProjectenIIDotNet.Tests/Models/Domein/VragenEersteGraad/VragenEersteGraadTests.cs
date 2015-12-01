using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.VragenEersteGraad;
using ProjectenIIDotNet.Tests.Dummies;

namespace ProjectenIIDotNet.Tests.Models.Domein.VragenEersteGraad
{
    [TestClass]
    public class VragenEersteGraadTests
    {
        private Klimatogram klimatogramNoord;
        private Klimatogram klimatogramZuid;

        /*Initializer*/
        [TestInitialize]
        public void Initialize()
        {
            klimatogramNoord = new KlimatogramNoordDummy();
            klimatogramZuid = new KlimatogramZuidDummy();
        }

        /*Testen van de constructors bij de vragen van de eerste graad*/
        [TestMethod]
        public void ConstructorWarmsteMaandVraagTest()
        {
            VraagEersteGraad vraag = new WarmsteMaandVraag(klimatogramNoord);
            Assert.AreEqual("Wat is de warmste maand?", vraag.Vraag);
            Assert.AreSame(klimatogramNoord, vraag.Klimatogram);
        }

        [TestMethod]
        public void ConstructorKoudsteMaandVraagTest()
        {
            VraagEersteGraad vraag = new KoudsteMaandVraag(klimatogramNoord);
            Assert.AreEqual("Wat is de koudste maand?", vraag.Vraag);
            Assert.AreSame(klimatogramNoord, vraag.Klimatogram);
        }

        [TestMethod] 
        public void ConstructorTemperatuurWarmsteMaandTest()
        {
            VraagEersteGraad vraag = new TemperatuurWarmsteMaandVraag(klimatogramNoord);
            Assert.AreEqual("Wat is de temperatuur van de warmste maand?", vraag.Vraag);
            Assert.AreSame(klimatogramNoord, vraag.Klimatogram);
        }

        [TestMethod]
        public void ConstructorTemperatuurKoudsteMaandVraagTest()
        {
            VraagEersteGraad vraag = new TemperatuurKoudsteMaandVraag(klimatogramNoord);
            Assert.AreEqual("Wat is de temperatuur van de koudste maand?", vraag.Vraag);
            Assert.AreSame(klimatogramNoord, vraag.Klimatogram);
        }

        [TestMethod]
        public void ConstructorNeerslagZomerVraagTest()
        {
            VraagEersteGraad vraag = new NeerslagZomerVraag(klimatogramNoord);
            Assert.AreEqual("Hoeveelheid neerslag in de zomer?", vraag.Vraag);
            Assert.AreSame(klimatogramNoord, vraag.Klimatogram);
        }

        [TestMethod]
        public void ConstructorNeerslagWinterVraagTest()
        {
            VraagEersteGraad vraag = new NeerslagWinterVraag(klimatogramNoord);
            Assert.AreEqual("Hoeveelheid neerslag in de winter?", vraag.Vraag);
            Assert.AreSame(klimatogramNoord, vraag.Klimatogram);
        }

        [TestMethod]
        public void ConstructorAantalDrogeMaandenVraagTest()
        {
            VraagEersteGraad vraag = new AantalDrogeMaandenVraag(klimatogramNoord);
            Assert.AreEqual("Hoeveel droge maanden zijn er?", vraag.Vraag);
            Assert.AreSame(klimatogramNoord, vraag.Klimatogram);
        }

        /*Testen van de oplossingen bij de vragen van de eerste graad*/
        [TestMethod]
        public void WarmsteMaandVraagGeeftJuisteOplossing()
        {
            VraagEersteGraad vraagNoord = new WarmsteMaandVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new WarmsteMaandVraag(klimatogramZuid);
            Assert.AreEqual(6, vraagNoord.LosOp());
            Assert.AreEqual(6, vraagZuid.LosOp());
        }

        [TestMethod]
        public void KoudsteMaandVraagGeeftJuisteOplossing()
        {
            VraagEersteGraad vraagNoord = new KoudsteMaandVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new KoudsteMaandVraag(klimatogramZuid);
            Assert.AreEqual(0, vraagNoord.LosOp());
            Assert.AreEqual(0, vraagZuid.LosOp());
        }

        [TestMethod]
        public void TemperatuurWarmsteMaandVraagGeeftJuisteOplossing()
        {
            VraagEersteGraad vraagNoord = new TemperatuurWarmsteMaandVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new TemperatuurWarmsteMaandVraag(klimatogramZuid);
            Assert.AreEqual(17.2, vraagNoord.LosOp());
            Assert.AreEqual(17.2, vraagZuid.LosOp());
        }

        [TestMethod]
        public void TemperatuurKoudsteMaandVraagGeeftJuisteOplossing()
        {
            VraagEersteGraad vraagNoord = new TemperatuurKoudsteMaandVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new TemperatuurKoudsteMaandVraag(klimatogramZuid);
            Assert.AreEqual(2.5, vraagNoord.LosOp());
            Assert.AreEqual(2.5, vraagZuid.LosOp());
        }

        [TestMethod]
        public void NeerslagZomerVraagGeeftJuisteOplossing()
        {
            VraagEersteGraad vraagNoord = new NeerslagZomerVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new NeerslagZomerVraag(klimatogramZuid);
            Assert.AreEqual(316, vraagNoord.LosOp());
            Assert.AreEqual(419, vraagZuid.LosOp());
        }

        [TestMethod]
        public void NeerslagWinterVraagGeeftJuisteOplossing()
        {
            VraagEersteGraad vraagNoord = new NeerslagWinterVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new NeerslagWinterVraag(klimatogramZuid);
            Assert.AreEqual(419, vraagNoord.LosOp());
            Assert.AreEqual(316, vraagZuid.LosOp());
        }

        [TestMethod]
        public void AantalDriogeMaandenVraagGeeftJuisteOplossing()
        {
            VraagEersteGraad vraagNoord = new AantalDrogeMaandenVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new AantalDrogeMaandenVraag(klimatogramZuid);
            Assert.AreEqual(2, vraagNoord.LosOp());
            Assert.AreEqual(2, vraagZuid.LosOp());
        }

        /*Testen van de antwoorden bij de vragen van de eerste graad*/
        [TestMethod]
        public void WarmsteMaandVraagGeeftMogelijkeAntwoorden()
        {
            VraagEersteGraad vraagNoord = new WarmsteMaandVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new WarmsteMaandVraag(klimatogramZuid);
            List<Double> lijst = new List<Double>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            CollectionAssert.AreEqual(lijst, vraagNoord.GeefMogelijkeAntwoorden().ToList());
            CollectionAssert.AreEqual(lijst, vraagZuid.GeefMogelijkeAntwoorden().ToList());
        }

        [TestMethod]
        public void KoudsteMaandVraagGeeftMogelijkeAntwoorden()
        {
            VraagEersteGraad vraagNoord = new KoudsteMaandVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new KoudsteMaandVraag(klimatogramZuid);
            List<Double> lijst = new List<Double>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            CollectionAssert.AreEqual(lijst, vraagNoord.GeefMogelijkeAntwoorden().ToList());
            CollectionAssert.AreEqual(lijst, vraagZuid.GeefMogelijkeAntwoorden().ToList());
        }

        [TestMethod]
        public void TemperatuurWarmsteMaandVraagGeeftMogelijkeAntwoorden()
        {
            VraagEersteGraad vraagNoord = new TemperatuurWarmsteMaandVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new TemperatuurWarmsteMaandVraag(klimatogramZuid);
            List<double> lijst = new List<double> { 2.5, 3.2, 5.7, 8.7, 12.7, 15.5, 17.2, 17, 14.4, 10.4, 6, 3.4};
            CollectionAssert.AreEqual(lijst, vraagNoord.GeefMogelijkeAntwoorden().ToList());
            CollectionAssert.AreEqual(lijst, vraagZuid.GeefMogelijkeAntwoorden().ToList());
        }

        [TestMethod]
        public void TemperatuurKoudsteMaandVraagGeeftMogelijkeAntwoorden()
        {
            VraagEersteGraad vraagNoord = new TemperatuurKoudsteMaandVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new TemperatuurKoudsteMaandVraag(klimatogramZuid);
            List<double> lijst = new List<double> { 2.5, 3.2, 5.7, 8.7, 12.7, 15.5, 17.2, 17, 14.4, 10.4, 6, 3.4 };
            CollectionAssert.AreEqual(lijst, vraagNoord.GeefMogelijkeAntwoorden().ToList());
            CollectionAssert.AreEqual(lijst, vraagZuid.GeefMogelijkeAntwoorden().ToList());
        }

        [TestMethod]
        public void NeerslagZomerVraagGeeftMogelijkeAntwoorden()
        {
            VraagEersteGraad vraagNoord = new NeerslagZomerVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new NeerslagZomerVraag(klimatogramZuid);
            List<double> lijst = new List<double> ();
            CollectionAssert.AreEqual(lijst, vraagNoord.GeefMogelijkeAntwoorden().ToList());
            CollectionAssert.AreEqual(lijst, vraagZuid.GeefMogelijkeAntwoorden().ToList());
        }

        [TestMethod]
        public void NeerslagWinterVraagGeeftMogelijkeAntwoorden()
        {
            VraagEersteGraad vraagNoord = new NeerslagWinterVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new NeerslagWinterVraag(klimatogramZuid);
            List<double> lijst = new List<double>();
            CollectionAssert.AreEqual(lijst, vraagNoord.GeefMogelijkeAntwoorden().ToList());
            CollectionAssert.AreEqual(lijst, vraagZuid.GeefMogelijkeAntwoorden().ToList());
        }

        [TestMethod]
        public void AantalDrogeMaandenVragenGeeftMogelijkeAntwoorden()
        {
            VraagEersteGraad vraagNoord = new AantalDrogeMaandenVraag(klimatogramNoord);
            VraagEersteGraad vraagZuid = new AantalDrogeMaandenVraag(klimatogramZuid);
            List<Double> lijst = new List<Double>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            CollectionAssert.AreEqual(lijst, vraagNoord.GeefMogelijkeAntwoorden().ToList());
            CollectionAssert.AreEqual(lijst, vraagZuid.GeefMogelijkeAntwoorden().ToList());
        }
    }
}
