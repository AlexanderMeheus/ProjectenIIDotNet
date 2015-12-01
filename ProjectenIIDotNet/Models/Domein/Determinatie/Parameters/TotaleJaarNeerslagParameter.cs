using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public class TotaleJaarNeerslagParameter : Parameter
    {
        public TotaleJaarNeerslagParameter()
        {
            Benaming = "de totale jaarneerslag in mm";
            Symbool = "Nj";
        }

        public override double GeefParameterWaarde(Klimatogram klimatogram)
        {
            return klimatogram.GeefTotaleJaarNeerslag();
        }
    }
}
