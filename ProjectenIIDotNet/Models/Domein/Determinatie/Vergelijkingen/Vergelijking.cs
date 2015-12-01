using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen
{
    public abstract class Vergelijking
    {

        public virtual string Symbool { get; protected  set; }

        public virtual string Benaming { get; protected set; }

        public int VergelijkingID { get; protected set; }

        public abstract bool Vergelijk(double parameter1, double parameter2);
    }
}
