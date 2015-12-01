using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Tests.Models.Domein.Determinatie
{
    [TestClass]
    public class KenmerkTest
    {
        
        /*
         * TestFile om de klasse Kenmerk te testen.
         */

        private Kenmerk kenmerk;

        [TestInitialize]
        public void MijnTestSetup()
        {
            kenmerk = new Kenmerk();
        }

        // Kenmerk geeft na constructie enkel lege strings terug
        [TestMethod]
        public void KenmerkGeeftNaConstructieLegeStringsTerug()
        {
            Assert.AreEqual("", kenmerk.KlimaatKenmerk);
            Assert.AreEqual("", kenmerk.VegetatieKenmerk);
        }

        // Kenmerk past klimaatkenmerk correct aan
        [TestMethod]
        public void KenmerkPastKlimaatKenmerkCorrectAan()
        {
            String klimaatKenmerk = "Koud gematigd";
            kenmerk.KlimaatKenmerk = klimaatKenmerk;
            Assert.AreEqual(klimaatKenmerk, kenmerk.KlimaatKenmerk);
        }

        // Kenmerk past vegetatiekenmerk correct aan
        [TestMethod]
        public void KenmerkPastVegetatieKenmerkCorrectAan()
        {
            String vegetatieKenmerk = "Toendra";
            kenmerk.VegetatieKenmerk = vegetatieKenmerk;
            Assert.AreEqual(vegetatieKenmerk, kenmerk.VegetatieKenmerk);
        }
    }
}
