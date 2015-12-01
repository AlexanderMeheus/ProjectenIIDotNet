using ProjectenIIDotNet.Models.Domein.Determinatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectenIIDotNet.ViewModels
{
    public class KenmerkViewModel
    {
        public KenmerkViewModel(Kenmerk k)
        {
            this.VegetatieKenmerk = k.VegetatieKenmerk;
            this.KlimaatKenmerk = k.KlimaatKenmerk;
        }

        public string VegetatieKenmerk { get; set; }

        public string KlimaatKenmerk { get; set; }
    }
}