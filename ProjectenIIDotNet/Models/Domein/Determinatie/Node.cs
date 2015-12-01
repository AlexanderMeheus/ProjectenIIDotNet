using System;
using System.Collections.Generic;

namespace ProjectenIIDotNet.Models.Domein.Determinatie
{
    public abstract class Node
    {

        public virtual Node Ouder { get; set; }

        public int NodeID { get; set;}

        public bool HeeftOuder()
        {
            return (Ouder != null);
        }

        public abstract IList<bool> GaNaarCorrectKenmerk(Klimatogram klimatogram, IList<bool> antwoorden);

        public abstract Kenmerk DetermineerKenmerk(Klimatogram klimatogram);

        public virtual void VoegKindToeAanNeeNode(Node kind)
        {
            throw new InvalidOperationException();
        }

        public virtual void VoegKindToeAanJaNode(Node kind)
        {
            throw new InvalidOperationException();
        }
    }
}
