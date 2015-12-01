using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Tests.Models.Domein
{
    [TestClass]
    public class LeerlingTest
    {

        /*
         * Een instantie van leerling houd graad en jaar bij.
         * Ook houd het bij als de gegevens zijn gekozen en de
         * leerling klaar is om het systeemt e gebruiken.
         * 
         * Alles zijn getters en setters dus juist de constructor
         * dient getest te worden.
         * 
        */

        //Na construtie is de leerling niet actief om de software te gebruiken.
        [TestMethod]
        public void NaConstructieIsIsActiefFalse()
        {
            Leerling leerling = new Leerling();
            Assert.IsFalse(leerling.IsActief);
        }

        //Na constructie is de graad 1
        [TestMethod]
        public void NaConstructieIsDeGraad1()
        {
            Leerling leerling = new Leerling();
            Assert.AreEqual(Graad.graad1, leerling.Graad);
        }

        //Na constructie is het jaar 1
        [TestMethod]
        public void NaConstructieIsHetJaar1()
        {
            Leerling leerling = new Leerling();
            Assert.AreEqual(Jaar.jaar1, leerling.Jaar);
        }

    }

}
