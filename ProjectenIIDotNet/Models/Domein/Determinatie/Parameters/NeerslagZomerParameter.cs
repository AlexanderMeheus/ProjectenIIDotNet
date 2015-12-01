using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public class NeerslagZomerParameter : Parameter
    {
        public NeerslagZomerParameter()
        {
            Benaming = "hoeveelheid neerslag in de zomer";
            Symbool = "NZ";
        }

        public override double GeefParameterWaarde(Klimatogram klimatogram)
        {
            return klimatogram.GeefNeerslagZomer();
        }
    }
}
