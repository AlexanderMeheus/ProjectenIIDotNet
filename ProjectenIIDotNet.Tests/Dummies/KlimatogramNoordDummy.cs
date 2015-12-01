using System.Linq;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Tests.Dummies
{
    class KlimatogramNoordDummy : Klimatogram
    {
        private static readonly int[] neerslagWaarden = { 67, 54, 73, 57, 70, 30, 75, 25, 59, 71, 78, 76 };
        private static readonly double[] temperatuurWaarden = { 2.5, 3.2, 5.7, 8.7, 12.7, 15.5, 17.2, 17, 14.4, 10.4, 6, 3.4};

        public KlimatogramNoordDummy() : base(temperatuurWaarden.ToList(), neerslagWaarden.ToList(), 0, 0, 1961, 1990)
        {

        }

        public override int StartWaarnemingen
        {
            get { return 1961; } 
            set {}
        }

        public override int EindeWaarnemingen
        {
            get { return 1990; } 
            set {}
        }

        public override double Breedtegraad { get { return 1.0; } set {} }

        public override double Lengtegraad { get { return 0.0; } set {} }

        public override bool NoordelijkHalfrond
        {
            get { return true; }
        }

        public override double GeefGemiddeldeJaarTemperatuur()
        {
            return 9.7;
        }

        public override int GeefTotaleJaarNeerslag()
        {
            return 735;
        }

        public override double GeefGemiddeldeMaandTemperatuur(Maand maand)
        {
            return temperatuurWaarden[(int) maand];
        }

        public override int GeefTotaleMaandNeerslag(Maand maand)
        {
            return neerslagWaarden[(int) maand];
        }
    }
}
