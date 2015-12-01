using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.VragenEersteGraad;
using WebGrease.Css.Extensions;

namespace ProjectenIIDotNet
{
    public class KoudsteMaandVraag : VraagEersteGraad
    {

        public KoudsteMaandVraag(Klimatogram k)
        {
            this.Vraag = "Wat is de koudste maand?";
            this.Klimatogram = k;
        }

        public override double LosOp()
        {
            return (double)Klimatogram.GeefDeKoudsteMaand();
        }

        public override IEnumerable<double> GeefMogelijkeAntwoorden()
        {
            List<Double> antwoorden = new List<Double>();
            Klimatogram.MaandGegevens.ForEach(maand => antwoorden.Add((double)maand.Maand));
            return antwoorden;
        }
    }
}
