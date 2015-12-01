using System.Collections.Generic;

namespace ProjectenIIDotNet.Models.Domein.VragenEersteGraad
{
    public abstract class VraagEersteGraad
    {
        public string Vraag { get; protected set; }

        public Klimatogram Klimatogram { get; protected set; }

        public abstract double LosOp();

        public abstract IEnumerable<double> GeefMogelijkeAntwoorden();
    }
}
