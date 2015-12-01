using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public class NeerslagWinterParameter : Parameter
    {
        public NeerslagWinterParameter()
        {
            Benaming = "hoeveelheid neerslag in de winter";
            Symbool = "NW";
        }

        public override double GeefParameterWaarde(Klimatogram klimatogram)
        {
            return klimatogram.GeefNeerslagWinter();
        }
    }
}
