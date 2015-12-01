using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public abstract class AantalMaandenParameter : Parameter
    {

        public double Constante { get; protected set; }

        public virtual Vergelijking Vergelijking { get; protected set; }

        protected abstract string GeefBenaming();

        protected abstract string GeefSymbool();

        public override string Benaming
        {
            get { return GeefBenaming(); }
            protected set { }
        }

        public override string Symbool
        {
            get { return GeefSymbool(); }
            protected set { }
        }
    }
}
