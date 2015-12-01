using System;
using System.Collections;
using System.Collections.Generic;
using Ninject.Infrastructure.Language;

namespace ProjectenIIDotNet.Models.Domein.Determinatie
{
    public class DeterminatieTree
    {
        private Node _root;

        [Obsolete("Only needed for serialization and materialization", true)]
        public DeterminatieTree()
        {
            Keuzes = new List<bool>();
        }

        public DeterminatieTree(Node root, Graad graad)
        {
            Root = root;
            Graad = graad;
            Keuzes = new List<bool>();
        }

        public int DeterminatieTreeID { get; set; }

        public virtual Graad Graad { get; protected set; }

        public virtual Node Root
        {
            get { return _root; }
            protected set
            {
                if (value == null) throw new ArgumentException("Root node mag niet null zijn.");
                _root = value;
            }
        }

        public IList<bool> Keuzes { get; private set; }

        public Kenmerk DetermineerKenmerk(Klimatogram klimatogram)
        {
            if (klimatogram == null) throw new ArgumentException("Klimatogram mag niet null zijn.");
            return Root.DetermineerKenmerk(klimatogram);
        }

        public virtual bool IsCompleet()
        {
            return (GeefHuidigeNode() is KenmerkNode);
        }

        public bool IsBegin()
        {
            return Keuzes.Count == 0;
        }

        public Node GeefHuidigeNode()
        {
            Node n = _root;
            foreach (bool keuze in Keuzes)
            {
                if (keuze) n = ((VraagNode) n).JaKind;
                else n = ((VraagNode) n).NeeKind;
            }
            return n;
        }

        public Node StapVerder(bool antwoord)
        {
            if (IsCompleet()) throw new InvalidOperationException("Einde determinatietabel bereikt.");
            Node current = GeefHuidigeNode();
            if (antwoord) current = ((VraagNode) current).JaKind;
            else current = ((VraagNode)current).NeeKind;
            Keuzes.Add(antwoord);
            return current;
        }

        public Node StapTerug()
        {
            if (IsBegin()) throw new InvalidOperationException("Begin van determinatietabel, kan niet terug keren.");
            Keuzes.RemoveAt(Keuzes.Count - 1);
            return GeefHuidigeNode().Ouder;
        }

        public DeterminatieVraag GeefDeterminatieVraag()
        {
            if (IsCompleet()) throw new InvalidOperationException("Einde van determinatietabel bereikt.");
            return ((VraagNode) GeefHuidigeNode()).Vraag;
        }

        public Kenmerk GeefKenmerk()
        {
            if (!IsCompleet()) throw new InvalidOperationException("Determinatie is nog niet compleet.");
            return ((KenmerkNode) GeefHuidigeNode()).Kenmerk;
        }

        public Node GaNaarLaatsteCorrecteStap(Klimatogram klimatogram)
        {
            if (!IsCompleet()) throw new InvalidOperationException("Determinatie is nog niet compleet.");
            Node n = _root;
            int index = 0;
            while ((index < Keuzes.Count) && (Keuzes[index] == ((VraagNode) n).Vraag.LosOp(klimatogram)))
            {
                if (Keuzes[index]) n = ((VraagNode) n).JaKind;
                else n = ((VraagNode)n).NeeKind;
                ++index;
            }
            while (index < Keuzes.Count) Keuzes.RemoveAt(Keuzes.Count-1);
            return n;
        }

        public Node GaNaarCorrectKenmerk(Klimatogram klimatogram)
        {
            Keuzes = _root.GaNaarCorrectKenmerk(klimatogram, new List<bool>());
            return GeefHuidigeNode();
        }
    }
}
