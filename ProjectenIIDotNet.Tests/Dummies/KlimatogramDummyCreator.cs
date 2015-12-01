using System;
using System.Collections.Generic;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Tests.Dummies
{
    class KlimatogramDummyCreator
    {
        private readonly int[] neerslagWaarden = { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110 };
        private readonly double[] temperatuurWaarden = { 0, 5, 10, 15, 20, 25, 30, 27, 22, 19, 7, -5 };
        private const double lengtegraad = 4.340670;
        private const double breedtegraad = 50.802398;
        private const int startWaarnemingen = 1996;
        private const int eindeWaarnemingen = 2007;
        private int totaleJaarNeerslag;
        private double gemiddeldeJaarTemperatuur;

        private IList<double> temperaturen;
        private IList<int> neerslagen; 

        public KlimatogramDummyCreator()
        {
            neerslagen = new List<int>();
            temperaturen = new List<double>();
            totaleJaarNeerslag = 0;
            gemiddeldeJaarTemperatuur = 0.0;

            foreach (int maand in Enum.GetValues(typeof(Maand)))
            {
                neerslagen.Add(neerslagWaarden[maand]);
                totaleJaarNeerslag += neerslagWaarden[maand];
                temperaturen.Add(temperatuurWaarden[maand]);
                gemiddeldeJaarTemperatuur += temperatuurWaarden[maand];
            }
            gemiddeldeJaarTemperatuur = Math.Round(gemiddeldeJaarTemperatuur/12.0, 1);
        }

        public int[] GeefNeerslagWaarden()
        {
            return neerslagWaarden;
        }

        public double[] GeefTemperatuurWaarden()
        {
            return temperatuurWaarden;
        }

        public int GeefTotaleJaarNeerslag()
        {
            return totaleJaarNeerslag;
        }

        public double GeefGemiddeldeJaarTemperatuur()
        {
            return gemiddeldeJaarTemperatuur;
        }

        public bool IsNoordelijkHalfrond()
        {
            return (breedtegraad >= 0);
        }

        public double GeefBreedtegraad()
        {
            return breedtegraad;
        }

        public double GeefLengtegraad()
        {
            return lengtegraad;
        }

        public string GeefCoordinaten()
        {
            return "50°48'8.6\" N 4°20'26.4\" O";
        }

        public int GeefStartWaarnemingen()
        {
            return startWaarnemingen;
        }

        public int GeefEindeWaarnemingen()
        {
            return eindeWaarnemingen;
        }

        public IList<double> GeefTemperaturen()
        {
            return temperaturen;
        } 

        public IList<int> GeefNeerslagen()
        {
            return neerslagen;
        }

        public double GeefTemperatuurVanMaand(Maand maand)
        {
            return temperaturen[(int)maand];
        }

        public int GeefNeerslagVanMaand(Maand maand)
        {
            return neerslagen[(int)maand];
        }

        public Klimatogram GeefNieuwKlimatogram()
        {
            return new Klimatogram(temperaturen, neerslagen, breedtegraad, lengtegraad, startWaarnemingen, eindeWaarnemingen);
        }

        public double GeefAantalDrogeMaanden()
        {
            double result = 0.0;
            for (int maand = 0; maand < this.temperatuurWaarden.Length; maand++) {
                if (this.temperatuurWaarden[maand] * 2 > this.neerslagWaarden[maand])
                {
                    result += 1;//ik neem aan dat je gwn +1 doet voor elke droge maand, heb wat verwarring door de double...
                }
            }
            return result;      
        }

        public Maand GeefDeKoudsteMaand()
        {
            Maand maand = Maand.Januari;//standaard, anders error omdat die eventueel null kan zijn..
            int indexMaand = 0;
            for (int m = 0; m < this.temperatuurWaarden.Length; m++)
            {
                if (this.temperatuurWaarden[m] < temperatuurWaarden[indexMaand])
                {
                    indexMaand = m;
                }
            }
            switch (indexMaand)
            {
                case 0:
                    maand = Maand.Januari;
                    break;

                case 1:
                    maand = Maand.Februari;
                    break;

                case 2:
                    maand = Maand.Maart;
                    break;

                case 3:
                    maand = Maand.April;
                    break;

                case 4:
                    maand = Maand.Mei;
                    break;

                case 5:
                    maand = Maand.Juni;
                    break;

                case 6:
                    maand = Maand.Juli;
                    break;

                case 7:
                    maand = Maand.Augustus;
                    break;

                case 8:
                    maand = Maand.September;
                    break;

                case 9:
                    maand = Maand.Oktober;
                    break;

                case 10:
                    maand = Maand.November;
                    break;

                case 11:
                    maand = Maand.December;
                    break;

            }
            return maand; 
        }

        public Maand GeefDeWarmsteMaand()
        {
            Maand maand = Maand.Januari;//standaard, anders error omdat die eventueel null kan zijn..
            int indexMaand = 0;
            for (int m = 0; m < this.temperatuurWaarden.Length; m++)
            {
                if (this.temperatuurWaarden[m] > temperatuurWaarden[indexMaand])
                {
                    indexMaand = m;
                }
            }
            switch (indexMaand)
            {
                case 0:
                    maand = Maand.Januari;
                    break;

                case 1:
                    maand = Maand.Februari;
                    break;

                case 2:
                    maand = Maand.Maart;
                    break;

                case 3:
                    maand = Maand.April;
                    break;

                case 4:
                    maand = Maand.Mei;
                    break;

                case 5:
                    maand = Maand.Juni;
                    break;

                case 6:
                    maand = Maand.Juli;
                    break;

                case 7:
                    maand = Maand.Augustus;
                    break;

                case 8:
                    maand = Maand.September;
                    break;

                case 9:
                    maand = Maand.Oktober;
                    break;

                case 10:
                    maand = Maand.November;
                    break;

                case 11:
                    maand = Maand.December;
                    break;

            }
            return maand; 
        }

        public double GeefNeerslagWinter()//onze dummy is: noordelijk halfrond
        {
            double result = 0.0;
            for (int maand = 3; maand <= 8; maand++) { 
                result += this.neerslagWaarden[maand];
            }
            result = this.totaleJaarNeerslag-result;
            return result;
        }

        public double GeefNeerslagZomer()
        {
            double result = 0.0;
            for (int maand = 3; maand <= 8; maand++)
            {
                result += this.neerslagWaarden[maand];
            }
            return result;
        }

        public double GeefTemperatuurKoudsteMaand()
        {
            double result;
            int indexMaand = 0;
            for (int m = 0; m < this.temperatuurWaarden.Length; m++)
            {
                if (this.temperatuurWaarden[m] < temperatuurWaarden[indexMaand])
                {
                    indexMaand = m;
                }
            }
            result = this.temperatuurWaarden[indexMaand];

            return result;
        }
        public double GeefTemperatuurWarmsteMaand()
        {
            double result;
            int indexMaand = 0;
            for (int m = 0; m < this.temperatuurWaarden.Length; m++)
            {
                if (this.temperatuurWaarden[m] > temperatuurWaarden[indexMaand])
                {
                    indexMaand = m;
                }
            }
            result = this.temperatuurWaarden[indexMaand];

            return result;
        }
    }
}
