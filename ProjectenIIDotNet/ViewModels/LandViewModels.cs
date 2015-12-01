using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.ViewModels
{
    public class LandViewModel
    {
        public LandViewModel(Land c)
        {
            this.Naam = c.Naam;
            this.Continent = c.Continent.Naam;
            this.LandCode = c.LandCode;
        }

        public string Naam { get; set; }
        public string Continent { get; set; }
        public string LandCode { get; set; }
    }
}