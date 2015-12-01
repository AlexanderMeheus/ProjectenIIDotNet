using System;
using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;
using ProjectenIIDotNet.Models.Domein.Determinatie.Parameters;

namespace ProjectenIIDotNet.Models.Domein.Determinatie
{
    public class DeterminatieVraag
    {

        public virtual Parameter Parameter1 { get; set; }

        public virtual Parameter Parameter2 { get; set; }

        public virtual Vergelijking Vergelijking { get; set; }

        public int DeterminatieVraagID { get; set;}

        public virtual bool LosOp(Klimatogram klimatogram)
        {
            if (Parameter1 == null) throw new ArgumentException("Parameter1 is null.");
            if (Parameter2 == null) throw new ArgumentException("Parameter2 is null.");
            if (Vergelijking == null) throw new ArgumentException("Vergelijk is null.");
            if (klimatogram == null) throw new ArgumentException("Klimatogram is null.");
            double param1 = Parameter1.GeefParameterWaarde(klimatogram);
            double param2 = Parameter2.GeefParameterWaarde(klimatogram);
            return Vergelijking.Vergelijk(param1, param2);
        }

        /*
         * Verkorte antwoord = symbool parameter1 + " " + symbool vergelijkingType + " " + symbool parameter2
         */
        public virtual string GeefVerkorteVraag()
        {
            if (Parameter1 == null) throw new ArgumentException("Parameter1 is null.");
            if (Parameter2 == null) throw new ArgumentException("Parameter2 is null.");
            if (Vergelijking == null) throw new ArgumentException("Vergelijk is null.");
            return Parameter1.Symbool + " " + Vergelijking.Symbool + " " + Parameter2.Symbool;
        }

        /*
         * Volledige antwoord = benaming parameter1 + " " + benaming vergelijkingType + " " + benaming paramter2
         */
        public virtual string GeefVolledigeVraag()
        {
            if (Parameter1 == null) throw new ArgumentException("Parameter1 is null.");
            if (Parameter2 == null) throw new ArgumentException("Parameter2 is null.");
            if (Vergelijking == null) throw new ArgumentException("Vergelijk is null.");
            return Parameter1.Benaming + " " + Vergelijking.Benaming + " " + Parameter2.Benaming;
        }
    }
}
