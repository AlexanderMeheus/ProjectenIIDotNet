using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public class ConstanteWaardeParameter : Parameter
    {

        [Obsolete("Only needed for serialization and materialization", true)]
        public ConstanteWaardeParameter() { }

        public ConstanteWaardeParameter(double constante)
        {
            this.Constante = constante;
            Benaming = constante.ToString();
            Symbool = constante.ToString();
        }

        public override string Benaming { get { return Constante.ToString(); } protected set {} }

        public override string Symbool { get { return Constante.ToString(); } protected set{} }

        public double Constante { get; protected set; }

        public override double GeefParameterWaarde(Klimatogram klimatogram)
        {
            return Constante;
        }
    }
}
