using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen
{
    public class KleinerDanOfGelijkAan : Vergelijking
    {
        public KleinerDanOfGelijkAan()
        {
            Benaming = "is kleiner dan of gelijk aan";
            Symbool = "<=";
        }

        public override bool Vergelijk(double parameter1, double parameter2)
        {
            return parameter1 <= parameter2;
        }
    }
}
