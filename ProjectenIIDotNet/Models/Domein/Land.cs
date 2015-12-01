using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;

namespace ProjectenIIDotNet.Models.Domein
{
    public class Land
    {
        private String _naam;

        [Obsolete("Only needed for serialization and materialization", true)]
        public Land() { }

        public Land(string naam, string landCode)
        {
            this.Naam = naam;
            this.LandCode = landCode;
            this.Locaties = new List<Locatie>();
        }

        public String Naam
        {
            get { return _naam; }
            private set
            {
                if (value.IsNullOrWhiteSpace())
                {
                    throw new ArgumentException("Een land moet een _naam hebben.");
                }
                _naam = value;
            }
        }

        public virtual ICollection<Locatie> Locaties { get; private set; }

        public virtual Continent Continent { get; set; }
        public String LandCode { get; private set; }

        public ICollection<Locatie> GeefLocatiesAlfabetisch()
        {
            return Locaties.OrderBy(locatie => locatie.Naam).ToList();
        }

        public Locatie GeefLocatie(string naamLocatie)
        {
            return Locaties.First(l => l.Naam == naamLocatie);
        }

        public void VoegLocatieToe(Locatie locatie)
        {
            if (Locaties.Contains(locatie))
                throw new ArgumentException("Locatie behoort reeds tot dit land");
            Locaties.Add(locatie);
            locatie.Land = this;
        }
    }
}
