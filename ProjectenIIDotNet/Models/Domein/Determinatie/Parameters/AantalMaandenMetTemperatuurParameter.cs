using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public class AantalMaandenMetTemperatuurParameter : AantalMaandenParameter
    {
        [Obsolete("Only needed for serialization and materialization", true)]
        public AantalMaandenMetTemperatuurParameter() {}

        public AantalMaandenMetTemperatuurParameter(double constante, Vergelijking vergelijking)
        {
            Constante = constante;
            Vergelijking = vergelijking;
        }


        public override double GeefParameterWaarde(Klimatogram klimatogram)
        {
            return klimatogram.MaandGegevens.Count(m => Vergelijking.Vergelijk(m.Temperatuur, Constante));
        }


        protected override string GeefBenaming()
        {
            return "aantal maanden (met een gemiddelde temperatuur " + Vergelijking.Benaming + " " + Constante + ")";
        }

        protected override string GeefSymbool()
        {
            return "# maanden (met Tm " + Vergelijking.Symbool + " " + Constante + ")";
        }
    }
}
