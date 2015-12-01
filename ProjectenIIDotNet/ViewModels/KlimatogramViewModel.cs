using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.ViewModels
{
    public class KlimatogramViewModel
    {
        public KlimatogramViewModel(Locatie locatie)
        {
            Klimatogram k = locatie.Klimatogram;
            this.LocatieNaam = locatie.Naam;
            this.LandNaam = locatie.Land.Naam;
            this.ContinentNaam = locatie.Land.Continent.Naam;
            this.MaandGegevens = k.MaandGegevens.Select(mg => new MaandGegevensViewModel(mg));
            this.TotaalNeerslag = k.GeefTotaleJaarNeerslag();
            this.GemiddeldeJaarTemperatuur = k.GeefGemiddeldeJaarTemperatuur();
            this.StartWaarnemingen = k.StartWaarnemingen;
            this.EindeWaarnemingen = k.EindeWaarnemingen;
            this.Coordinaten = k.GeefCoordinaten();
        }

        public string ContinentNaam { get; set; }
        public string LandNaam { get; set; }
        public string LocatieNaam { get; set; }
        public string Coordinaten { get; set; }
        public IEnumerable<MaandGegevensViewModel> MaandGegevens { get; private set; }
        public int TotaalNeerslag { get; private set; }
        public double GemiddeldeJaarTemperatuur { get; private set; }
        public int StartWaarnemingen { get; private set; }
        public int EindeWaarnemingen { get; private set; }
    }

    public class MaandGegevensViewModel
    {
        public MaandGegevensViewModel(MaandGegevens mg)
        {
            this.Temperatuur = mg.Temperatuur;
            this.Neerslag = mg.Neerslag;
            this.Maand = mg.Maand.ToString();
            this.MaandNummer = (int) mg.Maand;
        }

        public double Temperatuur { get; private set; }

        public int Neerslag { get; private set; }

        public string Maand { get; private set; }

        public int MaandNummer { get; private set; }
    }
}