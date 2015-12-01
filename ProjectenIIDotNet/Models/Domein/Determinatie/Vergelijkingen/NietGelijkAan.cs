using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using ProjectenIIDotNet;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen
{
    public class NietGelijkAan : Vergelijking
    {
        public NietGelijkAan()
        {
            Benaming = "is niet gelijk aan";
            Symbool = "!=";
        }

        public override bool Vergelijk(double parameter1, double parameter2)
        {
            bool isJuist = false;

            if (parameter1 != parameter2)
                isJuist = true;
            else
                isJuist = false;

            return isJuist;
        }
    }
}
