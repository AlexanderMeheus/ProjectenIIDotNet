using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.ViewModels
{
    public class LocatieViewModel
    {
        public LocatieViewModel(Locatie l)
        {
            this.Continent = l.Land.Continent.Naam;
            this.Land = l.Land.Naam;
            this.Naam = l.Naam;
            this.Lengtegraad = l.Klimatogram.Lengtegraad;
            this.Breedtegraad = l.Klimatogram.Breedtegraad;
        }

        public string Continent { get; set; }
        public string Land { get; set; }
        public string Naam { get; set; }
        public double Lengtegraad { get; set; }
        public double Breedtegraad { get; set; }
    }
}