using System;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace ProjectenIIDotNet.Models.Domein.VragenEersteGraad
{
    public class TemperatuurKoudsteMaandVraag : VraagEersteGraad
    {
        public TemperatuurKoudsteMaandVraag(Klimatogram k)
        {
            this.Vraag = "Wat is de temperatuur van de koudste maand?";
            this.Klimatogram = k;
        }

        public override double LosOp()
        {
            return Klimatogram.GeefTemperatuurKoudsteMaand();
        }

        public override IEnumerable<double> GeefMogelijkeAntwoorden()
        {
            List<double> antwoorden = new List<double>();
            Klimatogram.MaandGegevens.ForEach(maand => antwoorden.Add(maand.Temperatuur));
            return antwoorden;
        }
    }
}
