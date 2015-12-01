using System;
using System.Collections.Generic;

namespace ProjectenIIDotNet.Models.Domein.Determinatie
{
    public class VraagNode : Node
    {

        [Obsolete("Only needed for serialization and materialization", true)]
        public VraagNode() { }

        public VraagNode(DeterminatieVraag vraag)
        {
            if (vraag == null) throw new ArgumentException("Argument klimatogramVraag is null.");
            Vraag = vraag;
        }

        public virtual Node JaKind { get; private set;}

        public virtual Node NeeKind { get; private set; }

        public virtual DeterminatieVraag Vraag { get; private set; }

        public override IList<bool> GaNaarCorrectKenmerk(Klimatogram klimatogram, IList<bool> antwoorden)
        {
            if (klimatogram == null) throw new ArgumentException("Argument klimatogram is null.");
            if ((JaKind == null) || (NeeKind == null)) throw new InvalidOperationException("Een van de kinderen is null.");
            bool antwoord = Vraag.LosOp(klimatogram);
            antwoorden.Add(antwoord);
            if (antwoord) return JaKind.GaNaarCorrectKenmerk(klimatogram, antwoorden);
            else return NeeKind.GaNaarCorrectKenmerk(klimatogram, antwoorden);
        }

        public override Kenmerk DetermineerKenmerk(Klimatogram klimatogram)
        {
            if (klimatogram == null) throw new ArgumentException("Argument klimatogram is null.");
            if ((JaKind == null) ||(NeeKind == null)) throw new InvalidOperationException("Een van de kinderen is null.");
            if (Vraag.LosOp(klimatogram)) return JaKind.DetermineerKenmerk(klimatogram);
            else return NeeKind.DetermineerKenmerk(klimatogram);
        }

        public override void VoegKindToeAanNeeNode(Node kind)
        {
            if (kind == null) throw new ArgumentException("Argument node is null.");
            kind.Ouder = this;
            NeeKind = kind;
        }

        public override void VoegKindToeAanJaNode(Node kind)
        {
            if (kind == null) throw new ArgumentException("Argument node is null.");
            kind.Ouder = this;
            JaKind = kind;
        }
    }
}
