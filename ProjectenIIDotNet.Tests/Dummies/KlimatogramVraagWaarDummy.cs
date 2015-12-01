using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Tests.Dummies
{
    class KlimatogramVraagWaarDummy : DeterminatieVraag
    {
        public override string GeefVerkorteVraag()
        {
            return "Tw < 10";
        }

        public override string GeefVolledigeVraag()
        {
            return "Temperatuur warmste maand kleiner dan 10";
        }

        public override bool LosOp(Klimatogram klimatogram)
        {
            return true;
        }
    }
}
