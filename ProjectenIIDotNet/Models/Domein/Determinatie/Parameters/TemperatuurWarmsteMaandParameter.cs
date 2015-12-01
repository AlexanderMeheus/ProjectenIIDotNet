﻿using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public class TemperatuurWarmsteMaandParameter : Parameter
    {
        public TemperatuurWarmsteMaandParameter()
        {
            Benaming = "temperatuur warmste maand";
            Symbool = "Tw";
        }

        public override double GeefParameterWaarde(Klimatogram klimatogram)
        {
            return klimatogram.GeefTemperatuurWarmsteMaand();
        }
    }
}
