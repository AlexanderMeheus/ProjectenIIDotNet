using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public class TemperatuurKoudsteMaandParameter : Parameter
    {
        public TemperatuurKoudsteMaandParameter()
        {
            Benaming = "temperatuur koudste maand";
            Symbool = "Tk";
        }

        public override double GeefParameterWaarde(Klimatogram klimatogram)
        {
            return klimatogram.GeefTemperatuurKoudsteMaand();
        }
    }
}
