using System;
using System.Collections.Generic;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen
{
    public class VergelijkingFactory
    {
        private Dictionary<VergelijkingenEnum, Vergelijking> vergelijkingen;

        public VergelijkingFactory()
        {
            vergelijkingen = new Dictionary<VergelijkingenEnum, Vergelijking>();
            vergelijkingen.Add(VergelijkingenEnum.GelijkAan, new GelijkAan());
            vergelijkingen.Add(VergelijkingenEnum.GroterDan, new GroterDan());
            vergelijkingen.Add(VergelijkingenEnum.GroterDanOfGelijkAan, new GroterDanOfGelijkAan());
            vergelijkingen.Add(VergelijkingenEnum.KleinerDan, new KleinerDan());
            vergelijkingen.Add(VergelijkingenEnum.KleinerDanOfGelijkAan, new KleinerDanOfGelijkAan());
            vergelijkingen.Add(VergelijkingenEnum.NietGelijkAan, new NietGelijkAan());
        }

        public Vergelijking GeefVergelijking(VergelijkingenEnum type)
        {
            if (!vergelijkingen.ContainsKey(type)) throw new ArgumentException("Het opgegeven vergelijkingstype is niet gevonden.");
            return vergelijkingen[type];
        }
    }
}
