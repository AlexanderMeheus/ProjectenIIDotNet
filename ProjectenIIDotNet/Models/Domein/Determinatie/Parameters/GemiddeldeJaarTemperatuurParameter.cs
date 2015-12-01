using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public class GemiddeldeJaarTemperatuurParameter : Parameter
    {
        public GemiddeldeJaarTemperatuurParameter()
        {
            Benaming = "de gemiddelde jaartemperatuur in °C";
            Symbool = "Tj";
        }

        public override double GeefParameterWaarde(Klimatogram klimatogram)
        {
            return klimatogram.GeefGemiddeldeJaarTemperatuur();
        }
    }
}
