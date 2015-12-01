using System;

namespace ProjectenIIDotNet.Models.Domein
{
    public class MaandGegevens
    {
        [Obsolete("Only needed for serialization and materialization", true)]
        public MaandGegevens() { }

        public MaandGegevens(double temperatuur, int neerslag, Maand maand)
        {
            Temperatuur = temperatuur;
            Neerslag = neerslag;
            Maand = maand;
        }
    
        public virtual double Temperatuur { get;set; }

        public virtual int Neerslag { get; set; }

        public virtual Maand Maand { get;set; }

        public virtual int MaandGegevensID { get;set; }
    }
}
