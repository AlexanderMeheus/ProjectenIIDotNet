using System;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace ProjectenIIDotNet.Models.Domein.VragenEersteGraad
{
    public class WarmsteMaandVraag : VraagEersteGraad
    {
        public WarmsteMaandVraag(Klimatogram k)
        {
            this.Vraag = "Wat is de warmste maand?";
            this.Klimatogram = k;
        }

        public override double LosOp()
        {
            return (double)Klimatogram.GeefDeWarmsteMaand();
        }

        public override IEnumerable<double> GeefMogelijkeAntwoorden()
        {
            List<Double> antwoorden = new List<Double>();
            Klimatogram.MaandGegevens.ForEach(maand => antwoorden.Add((double)maand.Maand));
            return antwoorden;
        }
    }
}
