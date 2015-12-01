using System;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace ProjectenIIDotNet.Models.Domein.VragenEersteGraad
{
    public class NeerslagWinterVraag : VraagEersteGraad
    {
        public NeerslagWinterVraag(Klimatogram k)
        {
            this.Vraag = "Hoeveelheid neerslag in de winter?";
            this.Klimatogram = k;
        }

        public override double LosOp()
        {
            return Klimatogram.GeefNeerslagWinter();
        }

        public override IEnumerable<double> GeefMogelijkeAntwoorden()
        {
            return new List<double>();
        }
    }
}
