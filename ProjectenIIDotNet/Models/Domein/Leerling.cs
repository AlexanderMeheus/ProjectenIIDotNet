using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein
{
    public class Leerling
    {

        public Leerling()
        {
            Graad = Graad.graad1;
            Jaar = Jaar.jaar1;
            IsActief = false;
            GekozenLocatie = null;
        }

        public Graad Graad { get; set; }

        public Jaar Jaar { get; set; }

        public bool IsActief { get;set; }

        public Locatie GekozenLocatie { get; set; }

        public Determinatie.DeterminatieTree DeterminatieTabel { get; set; }

        public int? AantalPogingenVragen { get; set; }
    }
}
