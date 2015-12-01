using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.ViewModels
{
    public class ContinentViewModel
    {
        public ContinentViewModel(Continent c)
        {
            this.Naam = c.Naam;
            this.ContinentCode = c.ContinentCode;
        }

        public string Naam { get; set; }
        public string ContinentCode { get; set; }
    }
}