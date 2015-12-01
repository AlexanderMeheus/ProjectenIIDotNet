using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace ProjectenIIDotNet.Models.Domein.VragenEersteGraad
{
    public class TemperatuurWarmsteMaandVraag : VraagEersteGraad
    {
        public TemperatuurWarmsteMaandVraag(Klimatogram k)
        {
            this.Vraag = "Wat is de temperatuur van de warmste maand?";
            this.Klimatogram = k;
        }

        public override double LosOp()
        {
            return Klimatogram.GeefTemperatuurWarmsteMaand();
        }

        public override IEnumerable<double> GeefMogelijkeAntwoorden()
        {
            List<double> antwoorden = new List<double>();
            Klimatogram.MaandGegevens.ForEach(maand => antwoorden.Add(maand.Temperatuur));
            return antwoorden;
        }
    }
}
