using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public class AantalDrogeMaandenParameter : Parameter
    {
        public AantalDrogeMaandenParameter()
        {
            Benaming = "aantal droge maanden";
            Symbool = "D";
        }

        public override double GeefParameterWaarde(Klimatogram klimatogram)
        {
            return klimatogram.GeefAantalDrogeMaanden();
        }
    }
}
