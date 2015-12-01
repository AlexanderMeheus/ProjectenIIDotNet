using ProjectenIIDotNet.Models.Domein.Determinatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectenIIDotNet.ViewModels
{
    public class DeterminatieVraagViewModel
    {

        public DeterminatieVraagViewModel(DeterminatieVraag d)
        {
            this.GeefVerkorteVraag = d.GeefVerkorteVraag();
            this.GeefVolledigeVraag = d.GeefVolledigeVraag();
        }

        public string GeefVerkorteVraag { get; set; }

        public string GeefVolledigeVraag { get; set; }
    }

}