using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;

namespace ProjectenIIDotNet.Models.Domein
{
    public class Continent
    {

        private String _naam;
        //Init Landen
        public Continent(String naam, String continentCode)
        {
            this.Naam = naam;
            this.ContinentCode = continentCode;
            this.Landen = new List<Land>();
        }

        [Obsolete("Only needed for serialization and materialization", true)]
        public Continent() { }

        public String Naam
        {
            get { return _naam; }
            private set
            {
                if (value.IsNullOrWhiteSpace())
                {
                    throw new ArgumentException("Een continent moet een _naam hebben.");
                }
                _naam = value;
            }
        }

        public virtual ICollection<Land> Landen { get; private set; }
        public String ContinentCode { get; private set; }

        public ICollection<Land> GeefLandenAlfabetisch()
        {
            return Landen.OrderBy(land => land.Naam).ToList();
        }

        public Land GeefLand(string landNaam)
        {
            return Landen.First(l => l.Naam == landNaam);
        }

        public void VoegLandToe(Land land)
        {
            if (Landen.Contains(land))
                throw new ArgumentException("Land behoort reeds tot dit continent");
            Landen.Add(land);
            land.Continent = this;
        }
    }
}
