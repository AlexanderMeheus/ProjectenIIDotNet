using System;
using System.Collections.Generic;

namespace ProjectenIIDotNet.Models.Domein.Determinatie
{
    public class KenmerkNode : Node
    {

        [Obsolete("Only needed for serialization and materialization", true)]
        public KenmerkNode() { }

        public KenmerkNode(Kenmerk kenmerk)
        {
            if (kenmerk == null) throw new ArgumentException("Kenmerk kan niet null zijn!");
            Kenmerk = kenmerk;
        }

        public virtual Kenmerk Kenmerk { get; private set; }

        public override IList<bool> GaNaarCorrectKenmerk(Klimatogram klimatogram, IList<bool> antwoorden)
        {
            return antwoorden;
        }

        public override Kenmerk DetermineerKenmerk(Klimatogram klimatogram)
        {
            if (klimatogram == null) throw new ArgumentException("Argument klimatogram is null.");
            return Kenmerk;
        }
    }
}
