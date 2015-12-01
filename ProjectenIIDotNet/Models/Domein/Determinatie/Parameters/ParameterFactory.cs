using System;
using System.Collections.Generic;
using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;

namespace ProjectenIIDotNet.Models.Domein.Determinatie.Parameters
{
    public class ParameterFactory
    {
        private Dictionary<SimpeleParameterEnum, Parameter> simpeleParameters;
        private Dictionary<double, Parameter> constanteParameters;
        private Dictionary<AantalMaandenParameterEnum, Dictionary<Vergelijking, Dictionary<double, Parameter>>> aantalMaandenParameters;

        public ParameterFactory()
        {
            simpeleParameters = new Dictionary<SimpeleParameterEnum, Parameter>();
            constanteParameters = new Dictionary<double, Parameter>();
            aantalMaandenParameters = new Dictionary<AantalMaandenParameterEnum, Dictionary<Vergelijking, Dictionary<double, Parameter>>>();

            /*
             * Init simpele, andere worden aangemaakt wanneer ze nodig zijn
             * en dan opgeslagen zodat in db dezelfde worden gebruikt.
             */
            simpeleParameters.Add(SimpeleParameterEnum.AantalDrogeMaanden, new AantalDrogeMaandenParameter());
            simpeleParameters.Add(SimpeleParameterEnum.GemiddeldeJaarTemperatuur, new GemiddeldeJaarTemperatuurParameter());
            simpeleParameters.Add(SimpeleParameterEnum.NeerslagWinter, new NeerslagWinterParameter());
            simpeleParameters.Add(SimpeleParameterEnum.NeerslagZomer, new NeerslagZomerParameter());
            simpeleParameters.Add(SimpeleParameterEnum.TotaleJaarNeerslag, new TotaleJaarNeerslagParameter());
            simpeleParameters.Add(SimpeleParameterEnum.temperatuurKoudsteMaand, new TemperatuurKoudsteMaandParameter());
            simpeleParameters.Add(SimpeleParameterEnum.temperatuurWarmsteMaand, new TemperatuurWarmsteMaandParameter());

            /*
             * Juist bij AantalMaanden zijn er nog 2 vaste parameterstypes en 6 vaste vergelijkingen types
             */
            foreach (AantalMaandenParameterEnum ame in Enum.GetValues(typeof(AantalMaandenParameterEnum)))
            {
                Dictionary<Vergelijking, Dictionary<double, Parameter>> value = new Dictionary<Vergelijking, Dictionary<double, Parameter>>();
                aantalMaandenParameters.Add(ame, value);
            }
        }

        public Parameter GeefSimpeleParameter(SimpeleParameterEnum type)
        {
            if (!simpeleParameters.ContainsKey(type)) throw new ArgumentException("Het opgegeven parameterType is niet gevonden.");
            return simpeleParameters[type];
        }

        public Parameter GeefConstanteParameter(double constante)
        {
            if (constanteParameters.ContainsKey(constante)) return constanteParameters[constante];
            Parameter c = new ConstanteWaardeParameter(constante);
            constanteParameters.Add(constante, c);
            return constanteParameters[constante];
        }

        public Parameter GeefAantalMaandenParameter(AantalMaandenParameterEnum type, double constante, Vergelijking vergelijking)
        {
            if (!aantalMaandenParameters.ContainsKey(type)) throw new ArgumentException("Het opgegeven parameterType is niet gevonden.");
            Dictionary<Vergelijking, Dictionary<double, Parameter>> paramTypeDictionary = aantalMaandenParameters[type];

            if (!paramTypeDictionary.ContainsKey(vergelijking)) paramTypeDictionary.Add(vergelijking, new Dictionary<double, Parameter>());
            Dictionary<double, Parameter> vergelijkingTypeDictionary = paramTypeDictionary[vergelijking];

            if (vergelijkingTypeDictionary.ContainsKey(constante)) return vergelijkingTypeDictionary[constante];
            Parameter c;
            if (type == AantalMaandenParameterEnum.aantalMaandenMetTemperatuur) c = new AantalMaandenMetTemperatuurParameter(constante, vergelijking);
            else c = new AantalMaandenMetNeerslagParameter(constante, vergelijking);
            vergelijkingTypeDictionary.Add(constante, c);
            return vergelijkingTypeDictionary[constante];
        }
    }
}
