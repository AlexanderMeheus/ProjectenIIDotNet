using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Microsoft.Ajax.Utilities;

namespace ProjectenIIDotNet.Models.Domein
{
    public class Locatie
    {
        private string _naam;
        private Klimatogram _klimatogram;
        private Land _land;

        [Obsolete("Only needed for serialization and materialization", true)]
        public Locatie() { }

        public Locatie(string naam)
        {
            this.Naam = naam;
            _klimatogram = null;
            _land = null;
        }

        public virtual string Naam
        {
            get { return _naam; }
            private set
            {
                if (value.IsNullOrWhiteSpace())
                {
                    throw new ArgumentException("Een locatie moet een _naam hebben.");
                }
                _naam = value;
            }
        }

        public virtual Klimatogram Klimatogram
        {
            get { return _klimatogram; }
            set
            {
                if (value == null) throw new ArgumentException("Klimatogram mag niet null zijn.");
                _klimatogram = value;
            }
        }

        public virtual Land Land
        {
            get { return _land; }
            set
            {
                if (value == null) throw new ArgumentException("Land mag niet null zijn.");
                _land = value;
            }
        }
    }
}
