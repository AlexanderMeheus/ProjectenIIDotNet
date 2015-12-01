using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein
{
    public class Klimatogram
    {

        [Obsolete("Only needed for serialization and materialization", true)]
        public Klimatogram() { }

        public Klimatogram(IList<double> temperaturen, IList<int> neerslagen, double breedtegraad, double lengtegraad, int startWaarnemingen, int eindeWaarnemingen)
        {
            StartWaarnemingen = startWaarnemingen;
            EindeWaarnemingen = eindeWaarnemingen;
            Lengtegraad = lengtegraad;
            Breedtegraad = breedtegraad;
            MaandGegevens = new List<MaandGegevens>();
            foreach (int maand in Enum.GetValues(typeof(Maand)))
            {
                MaandGegevens.Add(new MaandGegevens(temperaturen[maand], neerslagen[maand], (Maand)maand));
            }
        }
        public virtual int KlimatogramID { get; set; }

        public virtual int StartWaarnemingen { get; set; }

        public virtual int EindeWaarnemingen { get; set; }

        public virtual bool NoordelijkHalfrond { get { return (Breedtegraad >= 0); } }

        public virtual double Lengtegraad { get; set; }

        public virtual double Breedtegraad { get; set; }

        public string GeefCoordinaten()
        {
            String coords = Graden(Breedtegraad);
            if (Breedtegraad >= 0) coords += " N ";
            else coords += " Z ";
            coords += Graden(Lengtegraad);
            if (Lengtegraad >= 0) coords += " O";
            else coords += " W";
            return coords;
        }

        private string Graden(double value)
        {
            value = Math.Abs(value);
            double graden = Math.Floor(value);
            value -= graden;
            double minuten = Math.Floor(value * 60);
            double seconden = Math.Round(((value*60) - minuten)*60,1);
            string result = String.Format("{0:0}", graden) + "°" + String.Format("{0:0}", minuten) + "'" +
                   String.Format("{0:0.#}", seconden) + "\"";
            return result.Replace(",", ".");
        }

        public virtual ICollection<MaandGegevens> MaandGegevens { get; set; }

        public virtual double GeefGemiddeldeJaarTemperatuur()
        {
            return Math.Round(MaandGegevens.Average(m => m.Temperatuur), 1);
        }

        public virtual int GeefTotaleJaarNeerslag()
        {
            return MaandGegevens.Sum(m => m.Neerslag);
        }

        public virtual double GeefGemiddeldeMaandTemperatuur(Maand maand)
        {
            return MaandGegevens.First(m => m.Maand == maand).Temperatuur;
        }

        public virtual int GeefTotaleMaandNeerslag(Maand maand)
        {
            return MaandGegevens.First(m => m.Maand == maand).Neerslag;
        }

        public double GeefAantalDrogeMaanden()
        {
            return MaandGegevens.Count(m => m.Temperatuur * 2 > m.Neerslag);
        }

        public Maand GeefDeKoudsteMaand()
        {
            return MaandGegevens.OrderBy(m => m.Temperatuur).FirstOrDefault().Maand;
        }

        public Maand GeefDeWarmsteMaand()
        {
            return MaandGegevens.OrderByDescending(m => m.Temperatuur).FirstOrDefault().Maand;
        }

        public double GeefNeerslagWinter()
        {
            if (NoordelijkHalfrond)
                return MaandGegevens.Where(m => (int)m.Maand < 3 || (int)m.Maand > 8).Sum(m => m.Neerslag);
            return MaandGegevens.Where(m => (int)m.Maand >= 3 && (int)m.Maand <= 8).Sum(m => m.Neerslag);
        }

        public double GeefNeerslagZomer()
        {
            if (NoordelijkHalfrond)
                return MaandGegevens.Where(m => (((int)m.Maand >= 3) && ((int)m.Maand <= 8))).Sum(m => m.Neerslag);
            return MaandGegevens.Where(m => (((int)m.Maand < 3) || ((int)m.Maand > 8))).Sum(m => m.Neerslag);
        }

        public double GeefTemperatuurKoudsteMaand()
        {
            return MaandGegevens.Min(m => m.Temperatuur);
        }

        public double GeefTemperatuurWarmsteMaand()
        {
            return MaandGegevens.Max(m => m.Temperatuur);
        }
    }
}
