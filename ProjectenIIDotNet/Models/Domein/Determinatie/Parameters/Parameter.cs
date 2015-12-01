using System;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public abstract class Parameter
    {

        public virtual string Symbool { get; protected set; }

        public virtual string Benaming { get; protected set; }

        public int ParameterID { get; private set; }

        public abstract double GeefParameterWaarde(Models.Domein.Klimatogram klimatogram);
    }
}
