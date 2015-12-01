using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie.Parameters;

namespace ProjectenIIDotNet.Tests.Dummies
{
    class ParameterDummy : Parameter
    {
        public ParameterDummy()
        {
        }

        public override double GeefParameterWaarde(Klimatogram klimatogram)
        {
            return 1.0;
        }

        public override string Benaming
        {
            get { return "Temperatuur warmste maand"; }
        }

        public override string Symbool
        {
            get { return "Tw"; }
        }
    }
}
