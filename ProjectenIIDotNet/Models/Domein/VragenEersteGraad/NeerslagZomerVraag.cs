using System;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace ProjectenIIDotNet.Models.Domein.VragenEersteGraad
{
    public class NeerslagZomerVraag : VraagEersteGraad
    {
        public NeerslagZomerVraag(Klimatogram k)
        {
            this.Vraag = "Hoeveelheid neerslag in de zomer?";
            this.Klimatogram = k;
        }

        public override double LosOp()
        {
            return Klimatogram.GeefNeerslagZomer();
        }

        public override IEnumerable<double> GeefMogelijkeAntwoorden()
        {
            return new List<double>();
        }
    }
}
