using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;
using ProjectenIIDotNet.Tests.Dummies;

namespace ProjectenIIDotNet.Tests.Models.Domein.Determinatie
{
    [TestClass]
    public class DeterminatieTreeTest
    {
        /*
         * Deze TestFile zal de volledige determinatietree testen.
         * !!!Eerst dient nodestest te slagen!!!
         * Eerst zal er een kleine tree worden gebouwd uit Nodes om
         * als dummy te dienen. De layout staat hieronder.
         * Het breedste is tot aan KlimatogramVraag(Waar/Onwaar).
         * De dummies worden hier gebruikt om te weten welk pad
         * er MOET doorlopen worden om zo te testen.
         * De klimatogram dat wordt meegegeven is dus van geen belang.
         * De kenmerken zullen ook simpel zijn. In de trees hieronder
         * staat T voor een antwoord die waar is en de jaNode moet genomen
         * worden, F voor een antwoord die onwaar is en de neeNode moet
         * genomen worden. K staat dan voor een leaf in de tree die 
         * een kenmerk bevat. Kc is correcte leaf, Kw is wrong leaf.
         * Als antwoord T is dan moet naar rechts gegaan worden hieronder.
         * Als antwoord F is dan ga je recht omlaag naar eerst volgende.
         * 
         * tree1: Kc
         * 
         * tree2: T -> Kc
         *        Kw
         *        
         * tree3: F -> T -> Kw
         *             Kw
         *        T -> F -> Kw
         *             Kc
         *        T -> Kw
         *        Kw
         */

        private DeterminatieTree tree;
        private Kenmerk correctKenmerk;
        private Kenmerk foutiefKenmerk;
        private Klimatogram klimatogram;
        private DeterminatieVraag vraagWaar;
        private DeterminatieVraag vraagOnwaar;
        private Node rootTree1;
        private Node rootTree2;
        private Node rootTree3;

        private Node correctNodeTree1;
        private Node correctNodeTree2;
        private Node correctNodeTree3;

        // Opbouwen van de trees en instellen van de variabelen
        [TestInitialize]
        public void BuildUpTheTrees()
        {
            // Kenmerken opstellen
            correctKenmerk = new Kenmerk();
            correctKenmerk.KlimaatKenmerk = "correct";
            foutiefKenmerk = new Kenmerk();
            foutiefKenmerk.KlimaatKenmerk = "foutief";
            
            // KlimatogramVragen opstellen
            vraagWaar = new KlimatogramVraagWaarDummy();
            vraagOnwaar = new KlimatogramVraagOnwaarDummy();

            // Klimatogram opstellen
            klimatogram = new KlimatogramNoordDummy();

            /*
             * Tree 1 opstellen
             * Kc
             */
            //Root zetten
            rootTree1 = new KenmerkNode(correctKenmerk);
            correctNodeTree1 = rootTree1;

            /*
             * Tree 2 opstellen
             * T -> Kc
             * Kw
             */
            //T
            Node vNode = new VraagNode(vraagWaar);
            correctNodeTree2 = new KenmerkNode(correctKenmerk);

            vNode.VoegKindToeAanJaNode(correctNodeTree2);
            vNode.VoegKindToeAanNeeNode(new KenmerkNode(foutiefKenmerk));
            //Root zetten
            rootTree2 = vNode;

            /*
             * Tree 3 opstellen
             * F2 -> T3 -> Kw
             *      Kw
             * T2 -> F1 -> Kw
             *      Kc
             * T1 -> Kw
             * Kw
             */
            //T1
            VraagNode t1 = new VraagNode(vraagWaar);
            correctNodeTree3 = new KenmerkNode(correctKenmerk);

            t1.VoegKindToeAanJaNode(new KenmerkNode(foutiefKenmerk));
            t1.VoegKindToeAanNeeNode(new KenmerkNode(foutiefKenmerk));
            //F1
            VraagNode f1 = new VraagNode(vraagOnwaar);
            f1.VoegKindToeAanJaNode(new KenmerkNode(foutiefKenmerk));
            f1.VoegKindToeAanNeeNode(correctNodeTree3);
            //T2
            VraagNode t2 = new VraagNode(vraagWaar);
            t2.VoegKindToeAanJaNode(f1);
            t2.VoegKindToeAanNeeNode(t1);
            //T3
            VraagNode t3 = new VraagNode(vraagWaar);
            t3.VoegKindToeAanJaNode(new KenmerkNode(foutiefKenmerk));
            t3.VoegKindToeAanNeeNode(new KenmerkNode(foutiefKenmerk));
            //F2
            VraagNode f2 = new VraagNode(vraagOnwaar);
            f2.VoegKindToeAanJaNode(t3);
            f2.VoegKindToeAanNeeNode(t2);
            //Root zetten
            rootTree3 = f2;
        }

        /*
         * Na het vele opbouwen zullen we nu beginnen met het testen.
         */

        //DeterminatieTree constructor gooit argument exception als root node null is
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void DeterminatieTreeConstructorGooitArgumentExceptionAlsRootNodeNullIs()
        {
            tree = new DeterminatieTree(null, Graad.graad2);
        }

        //DetermineerKenmerk gooit argument exception als klimatogram null is
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void DetermineerKenmerkGooitArgumentExceptionAlsKlimatogramNullIs()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            tree.DetermineerKenmerk(null);
        }

        //DetermineerKenmerk geeft correcte kenmerk terug bij diepte 1
        [TestMethod]
        public void DetermineerKenmerkGeeftCorrecteKenmerkTerug()
        {
            tree = new DeterminatieTree(rootTree1, Graad.graad2);
            Assert.AreEqual(correctKenmerk, tree.DetermineerKenmerk(klimatogram));
        }

        //DetermineerKenmerk geeft correcte kenmerk terug bij diepte >1
        [TestMethod]
        public void DetermineerKenmerkGeeftCorrecteKenmerkTerugBijDiepteGroterDan1()
        {
            //Test met diepte 2
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            Assert.AreEqual(correctKenmerk, tree.DetermineerKenmerk(klimatogram));
            //Test met diepte 3
            tree = new DeterminatieTree(rootTree3, Graad.graad2);
            Assert.AreEqual(correctKenmerk, tree.DetermineerKenmerk(klimatogram));
        }

        //StapVerder op leaf gooit invalid operation
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StapVerderOpLeafGooitInvalidOperation()
        {
            tree = new DeterminatieTree(rootTree1, Graad.graad2);
            tree.StapVerder(true);
        }

        //StapVerder neemt het juiste kind
        [TestMethod]
        public void StapVerderGaatNaarHetJuisteKindEnGeeftDitTerug()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            Node n = tree.StapVerder(true);
            Assert.AreEqual(correctNodeTree2, n);
        }

        //Nieuwe tree maakt lege lijst van leerlingkeuzes
        [TestMethod]
        public void NieuweTreeMaaktLegeLijstVanLeerlingKeuzes()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            Assert.IsNotNull(tree.Keuzes);
            Assert.AreEqual(0, tree.Keuzes.Count);
        }

        //StapVerder voegt keuze toe aan lijst leerlingkeuze
        [TestMethod]
        public void StapVerderVoegtKeuzeToeAanLeerlingKeuzes()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            tree.StapVerder(true);
            Assert.AreEqual(1, tree.Keuzes.Count);
            Assert.IsTrue(tree.Keuzes[0]);
        }

        //StapTerug op root gooit invalid operation
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void StapTerugGooitInvalidOperationOpRootNode()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            tree.StapTerug();
        }

        //StapTerug geeft correcte node
        //StapVerder moet eerst werken
        [TestMethod]
        public void StapTerugGeeftCorrecteNodeTerug()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            tree.StapVerder(false);
            Node n = tree.StapTerug();
            Assert.AreEqual(rootTree2, n);
        }

        //StapTerug verwijdert laatste keuze uit leerlingkeuzes
        //StapVerder moet eerst werken
        [TestMethod]
        public void StapTerugVerwijdertLaatsteKeuzeUitLeerlingKeuzes()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            tree.StapVerder(false);
            Assert.AreEqual(1, tree.Keuzes.Count);
            tree.StapTerug();
            Assert.AreEqual(0, tree.Keuzes.Count);
        }

        //IsBegin geeft true na constructie bij diepte 1
        [TestMethod]
        public void IsBeginGeeftTrueBijEenNieuweTreeMetDiepte1()
        {
            tree = new DeterminatieTree(rootTree1, Graad.graad2);
            Assert.IsTrue(tree.IsBegin());
        }

        //IsBegin geeft true na constructie bij diepte > 1
        [TestMethod]
        public void IsBeginGeeftTrueBijEenNieuweTreeMetDiepteGroterDan1()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            Assert.IsTrue(tree.IsBegin());
        }

        //IsCompleet geeft true na constructie als tree 1 node is
        [TestMethod]
        public void IsCompleetGeeftTrueBijEenNieuweTreeAlsTree1NodeDiepIs()
        {
            tree = new DeterminatieTree(rootTree1, Graad.graad1);
            Assert.IsTrue(tree.IsCompleet());
        }

        //IsCompleet geeft false na constructie als tree > 1 node is
        [TestMethod]
        public void IsCompleetGeeftFalseBijEenNieuweTreeAlsTreeDieperDan1NodeIs()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            Assert.IsFalse(tree.IsCompleet());
        }

        //IsBegin geeft false als huidig niet op begin staat
        [TestMethod]
        public void IsBeginGeeftFalseNaEenStapVerder()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            tree.StapVerder(false);
            Assert.IsFalse(tree.IsBegin());
        }

        //IsCompleet geeft true als hij op een leaf staat
        [TestMethod]
        public void IsCompleetGeeftTrueAlsCurrentEenLeafIs()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            tree.StapVerder(false);
            Assert.IsTrue(tree.IsCompleet());
        }

        //GeefHuidgeNode geeft root als er nog niet door de determinatie is gegaan
        [TestMethod]
        public void GeefHuidigeNodeGeeftRootAlsBijEenNieuweTree()
        {
            tree = new DeterminatieTree(rootTree3, Graad.graad2);
            Assert.IsNotNull(tree.GeefHuidigeNode());
            Assert.AreEqual(rootTree3, tree.GeefHuidigeNode());
        }

        //GeefHuidigeNode geeft correcte kind na stapverder
        [TestMethod]
        public void GeefHuidigeNodeGeeftCorrecteNodeNaStapVerder()
        {
            Node jNode = ((VraagNode) rootTree3).JaKind;
            tree = new DeterminatieTree(rootTree3, Graad.graad3);
            tree.StapVerder(true);
            Assert.AreEqual(jNode, tree.GeefHuidigeNode());
        }

        //GeefKenmerk gooit invalidOperation als huidige geen leaf is
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GeefKenmerkGooitInvalidOperationExceptionAlsHuidigeNodeGeenLeafIs()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            tree.GeefKenmerk();
        }

        //GeefKenmerk geeft het correcte kenmerk terug als huidge een leaf is
        [TestMethod]
        public void GeefKenmerkGeeftHetCorrecteKenmerkAlsHuidigeEenLeafIs()
        {
            tree = new DeterminatieTree(rootTree3, Graad.graad2);
            tree.StapVerder(false);
            tree.StapVerder(true);
            tree.StapVerder(false);
            Assert.AreEqual(correctKenmerk, tree.GeefKenmerk());
        }

        //GeefVraag gooit invalidOperation bij tree met diepte 1 / current is direct leaf
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GeefDeterminatieVraagGooitInvalidOperationBijTreeMetDiepte1()
        {
            tree = new DeterminatieTree(rootTree1, Graad.graad2);
            tree.GeefDeterminatieVraag();
        }

        //GeefDeterminatieVraag gooit invalidOperation bij een leaf
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GeefDeterminatieVraagGooitInvalidOperationAlsHuidigeEenLeafIs()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            tree.StapVerder(true);
            tree.GeefDeterminatieVraag();
        }

        //GeefDeterminatieVraag geeft correct vraag terug bij vraagnode
        [TestMethod]
        public void GeefDeterminatieVraagGeeftCorrecteVraagTerug()
        {
            tree = new DeterminatieTree(rootTree3, Graad.graad2);
            Assert.IsNotNull(tree.GeefDeterminatieVraag());
            Assert.AreEqual(vraagOnwaar, tree.GeefDeterminatieVraag());
        }

        //GaNaarLaatsteCorrecteStap gooit invalid operation als determinatie niet compleet is
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void GaNaarLaatsteCorrecteStapGooitInvalidOperationExceptionAlsDeterminatieNietCompleetIs()
        {
            tree = new DeterminatieTree(rootTree2, Graad.graad2);
            tree.GaNaarLaatsteCorrecteStap(klimatogram);
        }

        //GaNaarLaatsteCorrecteStap geeft root bij diepte 1
        [TestMethod]
        public void GaNaarLaatsteCorrecteStapGeeftRootBijDiepte1()
        {
            tree = new DeterminatieTree(rootTree1, Graad.graad1);
            Node n = tree.GaNaarLaatsteCorrecteStap(klimatogram);
            Assert.AreEqual(rootTree1, n);
            Assert.AreEqual(rootTree1, tree.GeefHuidigeNode());
        }

        //GaNaarLaatsteCorrecteStap geeft root als dit laatste correcte stap is
        [TestMethod]
        public void GaNaarLaatsteCorrecteStapGeeftRootAlsDitLaatsteCorrecteStapIs()
        {
            tree = new DeterminatieTree(rootTree3, Graad.graad2);
            tree.StapVerder(true);
            tree.StapVerder(false);
            Node n = tree.GaNaarLaatsteCorrecteStap(klimatogram);
            Assert.AreEqual(rootTree3, n);
            Assert.AreEqual(rootTree3, tree.GeefHuidigeNode());
        }

        //GaNaarLaatsteCorrecteStap geeft laatste correcte stap in determinatietabel
        [TestMethod]
        public void GaNaarLaatsteCorrecteStapGeeftCorrecteNode()
        {
            tree = new DeterminatieTree(rootTree3, Graad.graad2);
            tree.StapVerder(false);
            tree.StapVerder(true);
            tree.StapVerder(true);
            Node current = rootTree3;
            current = ((VraagNode) current).NeeKind;
            current = ((VraagNode) current).JaKind;
            Assert.AreEqual(current, tree.GaNaarLaatsteCorrecteStap(klimatogram));
            Assert.AreEqual(current, tree.GeefHuidigeNode());
        }
    }
}
