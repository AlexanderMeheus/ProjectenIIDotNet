using System;

namespace ProjectenIIDotNet.Models.Domein.Determinatie
{
    public class Kenmerk
    {
        public Kenmerk()
        {
            VegetatieKenmerk = "";
            KlimaatKenmerk = "";
        }

        public string VegetatieKenmerk { get; set; }

        public string KlimaatKenmerk { get; set; }

        public int KenmerkID { get; set; }
    }
}
