using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;

namespace ProjectenIIDotNet.Tests.Models.Domein.Determinatie
{
    [TestClass]
    public class VergelijkingenTest
    {
        /*
         * In deze unit test worden alle vergelijkingen die erven van vergelijkingType getest.
         * Om niet met 6 verschillende testfiles te werken waarin hooguit 3 testen staan te werken
         * worden ze allen samen in 1 testfile gebracht.
         * 
         * Van iedere Vergelijking moet de werking van de constructor en de methode Vergelijk getest worden.
         */

        //Een variabele om met te werken
        private Vergelijking vergelijking;

        /*
         * =================================================================================================
         * #################################  GelijkAan testen
         * =================================================================================================
         */

        [TestMethod]
        public void GelijkAanConstructorZetCorrecteBenamingEnSymbool()
        {
            // Act
            vergelijking = new GelijkAan();
            // Assert
            Assert.AreEqual("=", vergelijking.Symbool, "GelijkAan, symbool niet correct.");
            Assert.AreEqual("is gelijk aan", vergelijking.Benaming, "GelijkAan, benaming niet correct.");
        }

        [TestMethod]
        public void GelijkAanMethodeVergelijkGeeftTrueAlsWaardenGelijkZijn()
        {
            // Arrange
            vergelijking = new GelijkAan();
            // Assert
            Assert.IsTrue(vergelijking.Vergelijk(7.5, 7.5));
            Assert.IsTrue(vergelijking.Vergelijk(0, 0));
            Assert.IsTrue(vergelijking.Vergelijk(-99, -99));
        }

        [TestMethod]
        public void GelijkAanMethodeVergelijkGeeftFalseAlsWaardenNietGelijkZijn()
        {
            // Arrange
            vergelijking = new GelijkAan();
            // Assert
            Assert.IsFalse(vergelijking.Vergelijk(7.5, 9));
            Assert.IsFalse(vergelijking.Vergelijk(7.5, 9.95));
            Assert.IsFalse(vergelijking.Vergelijk(0, 9));
            Assert.IsFalse(vergelijking.Vergelijk(9, 0));
            Assert.IsFalse(vergelijking.Vergelijk(-5, 0));
            Assert.IsFalse(vergelijking.Vergelijk(-6.3, -20));
        }

        /*
         * =================================================================================================
         * #################################  NietGelijkAan testen
         * =================================================================================================
         */

        [TestMethod]
        public void NietGelijkAanConstructorZetJuisteBenamingEnSymbool()
        {
            // Act
            vergelijking = new NietGelijkAan();
            // Assert
            Assert.AreEqual("!=", vergelijking.Symbool, "NietGelijkAan, symbool niet correct.");
            Assert.AreEqual("is niet gelijk aan", vergelijking.Benaming, "NietGelijkAan, benaming niet correct.");
        }

        [TestMethod]
        public void NietGelijkAanMethodeVergelijkGeeftTrueAlsWaardenVerschillendZijn()
        {
            // Arrange
            vergelijking = new NietGelijkAan();
            // Assert
            Assert.IsTrue(vergelijking.Vergelijk(7.5, 9));
            Assert.IsTrue(vergelijking.Vergelijk(7.5, 9.95));
            Assert.IsTrue(vergelijking.Vergelijk(0, 9));
            Assert.IsTrue(vergelijking.Vergelijk(9, 0));
            Assert.IsTrue(vergelijking.Vergelijk(-5, 0));
            Assert.IsTrue(vergelijking.Vergelijk(-6.3, -20));
        }

        [TestMethod]
        public void NietGelijkAanMethodeVergelijkGeeftFalseAlsWaardenGelijkZijn()
        {
            // Arrange
            vergelijking = new NietGelijkAan();
            // Assert
            Assert.IsFalse(vergelijking.Vergelijk(7.5, 7.5));
            Assert.IsFalse(vergelijking.Vergelijk(0, 0));
            Assert.IsFalse(vergelijking.Vergelijk(-99, -99));
        }

        /*
         * =================================================================================================
         * #################################  GroterDan testen
         * =================================================================================================
         */

        [TestMethod]
        public void GroterDanConstructorZetJuisteBenamingEnSymbool()
        {
            // Act
            vergelijking = new GroterDan();
            // Assert
            Assert.AreEqual(">", vergelijking.Symbool, "GroterDan, symbool niet correct.");
            Assert.AreEqual("is groter dan", vergelijking.Benaming, "GroterDan, benaming niet correct.");
        }

        [TestMethod]
        public void GroterDanMethodeVergelijkGeeftTrueAlsParam1GroterDanParam2Is()
        {
            // Arrange
            vergelijking = new GroterDan();
            // Assert
            Assert.IsTrue(vergelijking.Vergelijk(1, 0));
            Assert.IsTrue(vergelijking.Vergelijk(1, 0.9999));
            Assert.IsTrue(vergelijking.Vergelijk(-1, -20));
            Assert.IsTrue(vergelijking.Vergelijk(15, -4));
        }

        [TestMethod]
        public void GroterDanMethodeVergelijkGeeftFalseAlsParam1KleinerDanOfGelijkAanParam2Is()
        {
            // Arrange
            vergelijking = new GroterDan();
            // Assert
            Assert.IsFalse(vergelijking.Vergelijk(5, 5));
            Assert.IsFalse(vergelijking.Vergelijk(-3, -3));
            Assert.IsFalse(vergelijking.Vergelijk(0, 0));
            Assert.IsFalse(vergelijking.Vergelijk(4.999, 5));
            Assert.IsFalse(vergelijking.Vergelijk(4, 5));
            Assert.IsFalse(vergelijking.Vergelijk(-20, -1));
            Assert.IsFalse(vergelijking.Vergelijk(-4, 15));
        }

        /*
         * =================================================================================================
         * #################################  GroterDanOfGelijkAan testen
         * =================================================================================================
         */

        [TestMethod]
        public void GroterDanOfGelijkAanConstructorZetJuisteBenamingEnSymbool()
        {
            // Act
            vergelijking = new GroterDanOfGelijkAan();
            // Assert
            Assert.AreEqual(">=", vergelijking.Symbool, "GroterDanOfGelijkAan, symbool niet correct.");
            Assert.AreEqual("is groter dan of gelijk aan", vergelijking.Benaming, "GroterDanOfGelijkAan, benaming niet correct.");
        }

        [TestMethod]
        public void GroterDanOfGelijkAanMethodeVergelijkGeeftTrueAlsParam1GroterDanOfGelijkAanParam2Is()
        {
            // Arrange
            vergelijking = new GroterDanOfGelijkAan();
            // Assert
            Assert.IsTrue(vergelijking.Vergelijk(1, 0));
            Assert.IsTrue(vergelijking.Vergelijk(1, 0.9999));
            Assert.IsTrue(vergelijking.Vergelijk(-1, -20));
            Assert.IsTrue(vergelijking.Vergelijk(15, -4));
            Assert.IsTrue(vergelijking.Vergelijk(5, 5));
            Assert.IsTrue(vergelijking.Vergelijk(-3, -3));
            Assert.IsTrue(vergelijking.Vergelijk(0, 0));
        }

        [TestMethod]
        public void GroterDanOfGelijkAanMethodeVergelijkGeeftFalseAlsParam1KleinerDanParam2Is()
        {
            // Arrange
            vergelijking = new GroterDanOfGelijkAan();
            // Assert
            Assert.IsFalse(vergelijking.Vergelijk(4.999, 5));
            Assert.IsFalse(vergelijking.Vergelijk(4, 5));
            Assert.IsFalse(vergelijking.Vergelijk(-20, -1));
            Assert.IsFalse(vergelijking.Vergelijk(-4, 15));
        }

        /*
         * =================================================================================================
         * #################################  KleinerDan testen
         * =================================================================================================
         */

        [TestMethod]
        public void KleinerDanConstructorZetJuisteBenamingEnSymbool()
        {
            // Act
            vergelijking = new KleinerDan();
            // Assert
            Assert.AreEqual("<", vergelijking.Symbool, "KleinerDan, symbool niet correct.");
            Assert.AreEqual("is kleiner dan", vergelijking.Benaming, "KleinerDan, benaming niet correct.");
        }

        [TestMethod]
        public void KleinerDanMethodeVergelijkGeeftTrueAlsParam1KleinerDanParam2Is()
        {
            // Arrange
            vergelijking = new KleinerDan();
            // Assert
            Assert.IsTrue(vergelijking.Vergelijk(3, 9));
            Assert.IsTrue(vergelijking.Vergelijk(0, 9));
            Assert.IsTrue(vergelijking.Vergelijk(3, 3.0001));
            Assert.IsTrue(vergelijking.Vergelijk(-1, 0));
            Assert.IsTrue(vergelijking.Vergelijk(-3, -2.9999));
        }

        [TestMethod]
        public void KleinerDanMethodeVergelijkGeeftFalseAlsParam1GroterDanOfGelijkAanParam2Is()
        {
            // Arrange
            vergelijking = new KleinerDan();
            // Assert
            Assert.IsFalse(vergelijking.Vergelijk(7, 7));
            Assert.IsFalse(vergelijking.Vergelijk(7.2, 7.2));
            Assert.IsFalse(vergelijking.Vergelijk(0, 0));
            Assert.IsFalse(vergelijking.Vergelijk(-5, -5));
            Assert.IsFalse(vergelijking.Vergelijk(2.5, 1));
            Assert.IsFalse(vergelijking.Vergelijk(0.0001, 0));
            Assert.IsFalse(vergelijking.Vergelijk(-1, -1.000001));
            Assert.IsFalse(vergelijking.Vergelijk(7, -5));
        }

        /*
         * =================================================================================================
         * #################################  KleinerDanOfGelijkAan testen
         * =================================================================================================
         */

        [TestMethod]
        public void KleinerDanOfGelijkAanConstructorZetJuisteBenamingEnSymbool()
        {
            // Act
            vergelijking = new KleinerDanOfGelijkAan();
            // Assert
            Assert.AreEqual("<=", vergelijking.Symbool, "KleinerDanOfGelijkAan, symbool niet correct.");
            Assert.AreEqual("is kleiner dan of gelijk aan", vergelijking.Benaming, "KleinerDanOfGelijkAan, benaming niet correct.");
        }

        [TestMethod]
        public void KleinerDanOfGelijkAanMethodeVergelijkGeeftTrueAlsParam1KleinerDanOfGelijkAanParam2Is()
        {
            // Arrange
            vergelijking = new KleinerDanOfGelijkAan();
            // Assert
            Assert.IsTrue(vergelijking.Vergelijk(3, 9));
            Assert.IsTrue(vergelijking.Vergelijk(0, 9));
            Assert.IsTrue(vergelijking.Vergelijk(3, 3.0001));
            Assert.IsTrue(vergelijking.Vergelijk(-1, 0));
            Assert.IsTrue(vergelijking.Vergelijk(-3, -2.9999));
            Assert.IsTrue(vergelijking.Vergelijk(7, 7));
            Assert.IsTrue(vergelijking.Vergelijk(7.2, 7.2));
            Assert.IsTrue(vergelijking.Vergelijk(0, 0));
            Assert.IsTrue(vergelijking.Vergelijk(-5, -5));
        }

        [TestMethod]
        public void KleinerDanOfGelijkAanMethodeVergelijkGeeftFalseAlsParam1GroterDanParam2Is()
        {
            // Arrange
            vergelijking = new KleinerDanOfGelijkAan();
            // Assert
            Assert.IsFalse(vergelijking.Vergelijk(2.5, 1));
            Assert.IsFalse(vergelijking.Vergelijk(0.0001, 0));
            Assert.IsFalse(vergelijking.Vergelijk(-1, -1.000001));
            Assert.IsFalse(vergelijking.Vergelijk(7, -5));
        }
    }
}
