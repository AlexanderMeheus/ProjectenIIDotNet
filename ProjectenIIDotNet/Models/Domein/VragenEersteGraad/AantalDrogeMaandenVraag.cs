using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace ProjectenIIDotNet.Models.Domein.VragenEersteGraad
{
    public class AantalDrogeMaandenVraag : VraagEersteGraad
    {
        public AantalDrogeMaandenVraag(Klimatogram k)
        {
            this.Vraag = "Hoeveel droge maanden zijn er?";
            this.Klimatogram = k;
        }

        public override double LosOp()
        {
            return Klimatogram.GeefAantalDrogeMaanden();
        }

        public override IEnumerable<double> GeefMogelijkeAntwoorden()
        {
            List<double> antwoorden = new List<double>();
            for (int i = 0; i <= Klimatogram.MaandGegevens.Count; i++)
            {
                antwoorden.Add(i);
            }
            return antwoorden;
        }
    }
}
