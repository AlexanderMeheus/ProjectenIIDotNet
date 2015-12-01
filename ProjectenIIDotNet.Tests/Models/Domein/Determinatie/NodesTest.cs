using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;
using ProjectenIIDotNet.Tests.Dummies;

namespace ProjectenIIDotNet.Tests.Models.Domein.Determinatie
{
    [TestClass]
    public class NodesTest
    {
        /*
         * In deze testfile zullen alle nodes getest worden.
         * Momenteel is dit KenmerkNode en VraagNode.
         * Alles zit in 1 file om niet teveel bestanden te hebben
         * en aangezien ze toch bij elkander passen.
         * 
         * Voor deze testen wordt een KlimatogramVraag aangemaakt
         * maar zonder dat een van zijn attributen wordt toegekend.
         * Aangezien er geen businesslogica daaruit nodig is om de
         * werking van de vraagnode te garanderen
         * 
         * Hetzelfde voor Kenmerk bij KenmerkNode.
         */

        private DeterminatieVraag vraagWaar;
        private DeterminatieVraag vraagOnwaar;
        private Klimatogram noordKlimatogram;
        private Kenmerk kenmerk;

        [TestInitialize]
        public void SetupVanMijnNodesTest()
        {
            vraagWaar = new KlimatogramVraagWaarDummy();
            vraagOnwaar = new KlimatogramVraagOnwaarDummy();
            kenmerk = new Kenmerk();
            noordKlimatogram = new KlimatogramNoordDummy();
        }

        /*
         * Kenmerknode testen
         * Sommige zaken dien in de abstrate class Node 
         * geplaatst te worden opdat kenmerknode zou werken
         */

        //KenmerkNode aanmaken met null gooit argument exceptie
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void KenmerkNodeAanmakenGooitArgumentExceptionBijNull()
        {
            Node n = new KenmerkNode(null);
        }

        //KenmerkNode geeft correct kenmerk terug na constructie
        [TestMethod]
        public void KenmerkNodeConstructorPlaatsKenmerkJuist()
        {
            KenmerkNode n = new KenmerkNode(kenmerk);
            Assert.AreEqual(kenmerk, n.Kenmerk);
        }

        //KenmerkNode HeeftOuder is false na constructie
        [TestMethod]
        public void KenmerkNodeHeeftGeenOuderNaConstructie()
        {
            Node n = new KenmerkNode(kenmerk);
            Assert.IsFalse(n.HeeftOuder());
        }

        //KenmerkNode Ouder geeft null na constructie
        [TestMethod]
        public void KenmerkNodeOuderGeeftNullNaConstructie()
        {
            Node n = new KenmerkNode(kenmerk);
            Assert.IsNull(n.Ouder);
        }

        //KenmerkNode determineerKenmerk gooit argument exception bij null
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void KenmerkNodeDetermineerKenmerkGooitArgumentExceptionBijNull()
        {
            Node n = new KenmerkNode(kenmerk);
            n.DetermineerKenmerk(null);
        }

        //KenmerkNode determineerKenmerk geeft kenmerkNode
        [TestMethod]
        public void KenmerkNodeDetermineerKenmerkGeeftKenmerkTerug()
        {
            Node n = new KenmerkNode(kenmerk);
            Assert.AreEqual(kenmerk, n.DetermineerKenmerk(noordKlimatogram));
        }

        //KenmerkNode VoegKindToeAanJaNode gooit invalidoperation exceptie bij geldig kind
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void KenmerkNodeVoegKindToeAanJaNodeGooitInvalidOperationExceptionBijGeldigArgument()
        {
            Node n = new KenmerkNode(kenmerk);
            n.VoegKindToeAanJaNode(new KenmerkNode(kenmerk));
        }

        //KenmerkNode VoegKindToeAanNeeNode gooit invalidoperation exceptie bij geldig kind
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void KenmerkNodeVoegKindToeAanNeeNodeGooitInvalidOperationExceptieBijGeldigArgument()
        {
            Node n = new KenmerkNode(kenmerk);
            n.VoegKindToeAanNeeNode(new KenmerkNode(kenmerk));
        }

        //KenmerkNode VoegKindToeAanJaNode gooit invalidoperation exceptie bij null
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void KenmerkNodeVoegKindToeAanJaNodeGooitInvalidOperationExceptionBijNullArgument()
        {
            Node n = new KenmerkNode(kenmerk);
            n.VoegKindToeAanJaNode(null);
        }

        //KenmerkNode VoegKindToeAanNeeNode gooit invalidoperation exceptie bij null
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void KenmerkNodeVoegKindToeAanNeeNodeGooitInvalidOperationExceptieBijNullArgument()
        {
            Node n = new KenmerkNode(kenmerk);
            n.VoegKindToeAanNeeNode(null);
        }

        /*
         * VraagNode testen
         * Ook hier dienen sommige zaken in de abstracte node geplaatst te zijn
         */

        //VraagNode constructor gooit argument exception bij null
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void VraagNodeConstructorGooitArgumentExceptionBijNull()
        {
            Node n = new VraagNode(null);
        }

        //VraagNode Vraag geeft correcte antwoord na constructie
        [TestMethod]
        public void VraagNodeConstructorPlaatstVraagCorrect()
        {
            VraagNode n = new VraagNode(vraagWaar);
            Assert.AreEqual(vraagWaar, n.Vraag);
        }


        //VraagNode HeeftOuder is false na constructie
        [TestMethod]
        public void VraagNodeHeeftOuderIsFalseNaConstructie()
        {
            Node n = new VraagNode(vraagWaar);
            Assert.IsFalse(n.HeeftOuder());
        }

        //VraagNode Ouder is null na constructie
        [TestMethod]
        public void VraagNodeOuderIsNullNaConstructie()
        {
            Node n = new VraagNode(vraagWaar);
            Assert.IsNull(n.Ouder);
        }

        //VraagNode VoegKindToeAanJaNode gooit argument exception bij null
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void VraagNodeVoegKindToeAanJaNodeGooitArgumentExceptionBijNull()
        {
            Node n = new VraagNode(vraagWaar);
            n.VoegKindToeAanJaNode(null);
        }

        //VraagNode VoegKindToeAanNeeNode gooit argument exception bij null
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VraagNodeVoegKindToeAanNeeNodeGooitArgumentExceptionBijNull()
        {
            Node n = new VraagNode(vraagWaar);
            n.VoegKindToeAanNeeNode(null);
        }

        //VraagNode VoegKindToeAanJaNode plaatst kind in jakind
        //kenmerknode moet correct werken
        [TestMethod]
        public void VraagNodeVoegKindToeAanJaNodePlaatstKindInJaNode()
        {
            Node n = new VraagNode(vraagWaar);
            Node dummy = new KenmerkNode(kenmerk);
            n.VoegKindToeAanJaNode(dummy);
            Assert.AreEqual(dummy, ((VraagNode)n).JaKind);
        }

        //VraagNode VoegKindToeAanNeeNode plaatst kind in neekind
        //Kenmerknode moet correct werken
        [TestMethod]
        public void VraagNodeVoegKindToeAanNeeNodePlaatstKindInNeeNode()
        {
            Node n = new VraagNode(vraagWaar);
            Node dummy = new KenmerkNode(kenmerk);
            n.VoegKindToeAanNeeNode(dummy);
            Assert.AreEqual(dummy, ((VraagNode)n).NeeKind);
        }

        //VraagNode VoegKindToeAanJaNode plaatst zichzelf als ouder
        //KenmerkNode moet correct werken
        [TestMethod]
        public void VraagNodeVoegKindToeAanJaNodePlaatstZichzelfAlsOuder()
        {
            Node n = new VraagNode(vraagWaar);
            Node dummy = new KenmerkNode(kenmerk);
            n.VoegKindToeAanJaNode(dummy);
            Assert.AreEqual(n, ((VraagNode)n).JaKind.Ouder);
        }

        //VraagNode VoegKindToeAanNeeNode plaatst zichzelf als ouder
        //KenmerkNode moet correct werken
        [TestMethod]
        public void VraagNodeVoegKindToeAanNeeNodePlaatstZichzelfAlsOuder()
        {
            Node n = new VraagNode(vraagWaar);
            Node dummy = new KenmerkNode(kenmerk);
            n.VoegKindToeAanNeeNode(dummy);
            Assert.AreEqual(n, ((VraagNode)n).NeeKind.Ouder);
        }

        //KenmerkNode HeeftOuder is true als hij een ouder heeft
        //VraagNode VoegKindToeAanJaNode moet correct werken
        [TestMethod]
        public void KenmerkNodeHeeftOuderIsWaarAlsHijEenOuderHeeft()
        {
            Node n = new VraagNode(vraagWaar);
            Node dummy = new KenmerkNode(kenmerk);
            n.VoegKindToeAanNeeNode(dummy);
            Assert.IsTrue(dummy.HeeftOuder());
        }

        //VraagNode DetermineerKenmerk gooit argument exception bij null
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void VraagNodeDetermineerKenmerkGooitArgumentExceptionBijNull()
        {
            Node n = new VraagNode(vraagWaar);
            n.DetermineerKenmerk(null);
        }

        //VraagNode DetermineerKenmerk gooit invalid operation exception als JaKind null is
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void VraagNodeDetermineerKenmerkGooitInvalidOperationAlsJaKindNullIs()
        {
            Node n = new VraagNode(vraagWaar);
            n.VoegKindToeAanNeeNode(new KenmerkNode(kenmerk));
            n.DetermineerKenmerk(noordKlimatogram);
        }

        //VraagNode DetermineerKenmerk gooit invalid operation exception als NeeKind null is
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void VraagNodeDetermineerKenmerkGooitInvalidOperationAlsNeeKindNullIs()
        {
            Node n = new VraagNode(vraagWaar);
            n.VoegKindToeAanJaNode(new KenmerkNode(kenmerk));
            n.DetermineerKenmerk(noordKlimatogram);
        }
        
        //VraagNode determineerKenmerk geeft oplossing ja kind als antwoord waar is
        [TestMethod]
        public void VraagNodeDetermineerKenmerkGeeftOplossingJaKindAlsVraagWaarIs()
        {
            Node n = new VraagNode(vraagWaar);
            n.VoegKindToeAanNeeNode(new KenmerkNode(new Kenmerk()));
            n.VoegKindToeAanJaNode(new KenmerkNode(kenmerk));
            Assert.AreEqual(kenmerk, n.DetermineerKenmerk(noordKlimatogram));
        }

        //VraagNode determineerKenmerk geeft oplossing nee kind als antwoord vals is
        [TestMethod]
        public void VraagNodeDetermineerKenmerkGeeftOplossingNeeKindAlsVraagValsIs()
        {
            Node n = new VraagNode(vraagOnwaar);
            n.VoegKindToeAanJaNode(new KenmerkNode(new Kenmerk()));
            n.VoegKindToeAanNeeNode(new KenmerkNode(kenmerk));
            Assert.AreEqual(kenmerk, n.DetermineerKenmerk(noordKlimatogram));
        }

    }
}
