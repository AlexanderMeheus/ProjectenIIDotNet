using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;

namespace ProjectenIIDotNet.Tests.Dummies
{
    class VergelijkingOnwaarDummy : Vergelijking
    {
        public override string Benaming
        {
            get { return "gelijk aan"; }
        }

        public override string Symbool
        {
            get { return "="; }
        }

        public override bool Vergelijk(double parameter1, double parameter2)
        {
            return false;
        }

    }
}
