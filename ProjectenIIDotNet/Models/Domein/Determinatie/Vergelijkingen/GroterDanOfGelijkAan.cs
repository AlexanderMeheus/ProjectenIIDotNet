﻿using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen
{
    public class GroterDanOfGelijkAan : Vergelijking
    {
        public GroterDanOfGelijkAan()
        {
            Benaming = "is groter dan of gelijk aan";
            Symbool = ">=";
        }

        public override bool Vergelijk(double parameter1, double parameter2)
        {
            bool isJuist = false;

            if (parameter1 >= parameter2)
                isJuist = true;
            else
                isJuist = false;

            return isJuist;
        }
    }
}
