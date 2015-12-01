using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using ProjectenIIDotNet.Models.Domein;
using WebGrease.Css.Extensions;

namespace ProjectenIIDotNet.Models.DAL
{
    public class ContinentRepository : IContinentRepository
    {
        private KlimatogramContext context;
        private DbSet<Continent> continenten;

        public ContinentRepository(KlimatogramContext context)
        {
            this.context = context;
            continenten = context.Continenten;
        }

        public ICollection<Continent> GeefAlleContinentenAlfabetisch(Graad graad)
        {
            ICollection<Continent> cList = new List<Continent>();
            if (graad == Graad.graad1) continenten.Find("Europa").IfNotNull(cList.Add);
            else continenten.ForEach(cList.Add);
            return cList.OrderBy(c => c.Naam).ToList();
        }

        public ICollection<Land> GeefAlleLandenAlfabetisch(string continentNaam)
        {
            return continenten.Find(continentNaam).GeefLandenAlfabetisch();
        }

        public ICollection<Locatie> GeefAlleLocatiesAlfabetisch(string continentNaam, string landNaam)
        {
            return continenten.Find(continentNaam).GeefLand(landNaam).GeefLocatiesAlfabetisch();
        }

        public Continent GeefContinent(string continentNaam)
        {
            return continenten.Find(continentNaam);
        }

        public Land GeefLand(string continentNaam, string landNaam)
        {
            return continenten.Find(continentNaam).GeefLand(landNaam);
        }

        public Locatie GeefLocatie(string continentNaam, string landNaam, string locatieNaam)
        {
            return continenten.Find(continentNaam).GeefLand(landNaam).GeefLocatie(locatieNaam);
        }
    }
}