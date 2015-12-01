using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Tests.Dummies
{
    class ContinentRepositoryDummy : IContinentRepository
    {
        private ICollection<Continent> continenten;

        public ContinentRepositoryDummy()
        {
            this.InitializeObjects();
        }

        private void InitializeObjects()
        {
            /*
                 * ==================================================================
                 * Continenten aanmaken
                 * ==================================================================
                 */
            //Europa
            Continent europa = new Continent("Europa");

            //Afrika
            Continent afrika = new Continent("Afrika");

            //Azië
            Continent azie = new Continent("Azië");

            //Oceanië
            Continent oceanie = new Continent("Oceanië");

            //Noord Amerika
            Continent noordAmerika = new Continent("Noord-Amerika");

            //Zuid Amerika
            Continent zuidAmerika = new Continent("Zuid-Amerika");

            /*
             * ==================================================================
             * Landen aanmaken
             * ==================================================================
             */
            //België
            Land belgie = new Land("België");

            //Frankrijk
            Land frankrijk = new Land("Frankrijk");

            //Ivoorkust
            Land ivoorkust = new Land("Ivoorkust");

            //China
            Land china = new Land("China");

            //Nieuw Zeeland
            Land nieuwZeeland = new Land("Nieuw Zeeland");

            //Verenigde Staten
            Land verenigdeStaten = new Land("Verenigde Staten");

            //Peru
            Land peru = new Land("Peru");

            /*
             * ==================================================================
             * Locaties aanmaken
             * klimatogram aanmaken
             * Koppelen
             * ==================================================================
             */
            //Eerste 2 lijsten aanmaken voor de temperaturen en neerslagen
            IList<double> temperaturen;
            IList<int> neerslagen;
            Klimatogram klimatogram;

            //Ukkel
            Locatie ukkel = new Locatie("Ukkel");
            temperaturen = new[] { 2.5, 3.2, 5.7, 8.7, 12.7, 15.5, 17.2, 17, 14.4, 10.4, 6, 3.4 };
            neerslagen = new[] { 67, 54, 73, 57, 70, 78, 75, 63, 59, 71, 78, 76 };
            klimatogram = new Klimatogram(temperaturen, neerslagen, 50.802398, 4.340670, 1961, 1990);
            ukkel.Klimatogram = klimatogram;

            //Gent-Melle
            Locatie gentMelle = new Locatie("Gent-Melle");
            temperaturen = new[] { 2.4, 3, 5.2, 8.4, 12.1, 15.1, 16.8, 16.6, 14.3, 10.3, 6.2, 3.2 };
            neerslagen = new[] { 51, 42, 46, 50, 59, 65, 72, 74, 72, 72, 64, 59 };
            klimatogram = new Klimatogram(temperaturen, neerslagen, 51.003672, 3.800314, 1960, 1996);
            gentMelle.Klimatogram = klimatogram;

            //Abidjan
            Locatie abidjan = new Locatie("Abidjan");
            temperaturen = new[] { 26.8, 27.7, 27.9, 27.7, 26.9, 25.8, 24.7, 24.5, 25.6, 26.8, 27.4, 27 };
            neerslagen = new[] { 16, 49, 107, 141, 294, 562, 206, 37, 81, 138, 143, 75 };
            klimatogram = new Klimatogram(temperaturen, neerslagen, 5.316667, -4.033333, 1961, 1990);
            abidjan.Klimatogram = klimatogram;

            //Parijs
            Locatie parijs = new Locatie("Parijs");
            temperaturen = new[] { 3.5, 4.5, 6.8, 9.7, 13.3, 16.4, 18.4, 18.2, 15.7, 11.8, 6.9, 4.3 };
            neerslagen = new[] { 54, 46, 54, 47, 63, 58, 54, 52, 54, 56, 56, 56 };
            klimatogram = new Klimatogram(temperaturen, neerslagen, 48.856614, 2.352222, 1960, 1990);
            parijs.Klimatogram = klimatogram;

            //Peking
            Locatie peking = new Locatie("Peking");
            temperaturen = new[] { -4.3, -1.9, 5.1, 13.6, 20.0, 24.2, 25.9, 24.6, 19.6, 12.7, 4.3, -2.2 };
            neerslagen = new[] { 3, 6, 9, 26, 29, 71, 176, 182, 49, 19, 6, 2 };
            klimatogram = new Klimatogram(temperaturen, neerslagen, 39.904211, 116.407395, 1961, 1990);
            peking.Klimatogram = klimatogram;

            //Wellington
            Locatie wellington = new Locatie("Wellington");
            temperaturen = new[] { 17.8, 17.7, 16.6, 14.3, 11.9, 10.1, 9.2, 9.8, 11.2, 12.8, 14.5, 16.4 };
            neerslagen = new[] { 67, 48, 76, 87, 99, 113, 111, 106, 82, 81, 74, 74 };
            klimatogram = new Klimatogram(temperaturen, neerslagen, -41.286460, 174.776236, 1961, 1990);
            wellington.Klimatogram = klimatogram;

            //Oklahoma City
            Locatie oklahomaCity = new Locatie("Oklahoma City");
            temperaturen = new[] { 2.2, 4.9, 10.2, 15.8, 20.2, 24.8, 27.8, 27.3, 22.8, 16.7, 9.8, 4.1 };
            neerslagen = new[] { 29, 40, 69, 70, 133, 110, 66, 66, 98, 82, 50, 36 };
            klimatogram = new Klimatogram(temperaturen, neerslagen, 35.467560, -97.516428, 1961, 1990);
            oklahomaCity.Klimatogram = klimatogram;

            //
            Locatie lima = new Locatie("Lima");
            temperaturen = new[] { 22.7, 23.3, 22.9, 21.2, 19.2, 17.8, 17.1, 16.8, 17.0, 17.9, 19.3, 21.3 };
            neerslagen = new[] { 1, 0, 0, 0, 0, 1, 1, 2, 1, 0, 0, 0 };
            klimatogram = new Klimatogram(temperaturen, neerslagen, -12.046374, -77.042793, 1961, 1990);
            lima.Klimatogram = klimatogram;

            /*
                 * ==================================================================
                 * Locaties aan landen koppelen
                 * ==================================================================
                 */
            //Aan Belgie
            belgie.VoegLocatieToe(ukkel);
            belgie.VoegLocatieToe(gentMelle);

            //Aan Frankrijk
            frankrijk.VoegLocatieToe(parijs);

            //Aan Ivoorkust
            ivoorkust.VoegLocatieToe(abidjan);

            //Aan China
            china.VoegLocatieToe(peking);

            //Aan Nieuw Zeeland
            nieuwZeeland.VoegLocatieToe(wellington);

            //Aan Verenigde Staten
            verenigdeStaten.VoegLocatieToe(oklahomaCity);

            //Aan Peru
            peru.VoegLocatieToe(lima);

            /*
             * ==================================================================
             * Landen aan continenten koppelen
             * ==================================================================
             */
            //Aan Europa
            europa.VoegLandToe(belgie);
            europa.VoegLandToe(frankrijk);

            //Aan Afrika
            afrika.VoegLandToe(ivoorkust);

            //Aan Azië
            azie.VoegLandToe(china);

            //Aan Oceanië
            oceanie.VoegLandToe(nieuwZeeland);

            //Aan Noord-Amerika
            noordAmerika.VoegLandToe(verenigdeStaten);

            //Aan Zuid-Amerika
            zuidAmerika.VoegLandToe(peru);

            /*
             * ===================================================================
             * Kenmerken aanmaken
             * 
             * Moet in juiste volgorde gemaakt zijn zodat determinatietabel
             * klopt.
             * ===================================================================
             */

            /*
             * ==================================================================
             * Proberen opslaan zeker?
             * ==================================================================
             */
            continenten = (new Continent[] {europa, afrika}).ToList();
        }

        public ICollection<Continent> GeefAlleContinentenAlfabetisch(Graad graad)
        {
            ICollection<Continent> cList = new List<Continent>();
            if (graad == Graad.graad1) cList.Add(continenten.First(c => c.Naam == "Europa"));
            else cList = continenten;
            return cList.OrderBy(c => c.Naam).ToList();
        }

        public ICollection<Land> GeefAlleLandenAlfabetisch(string continentNaam)
        {
            return continenten.First(c => c.Naam == continentNaam).GeefLandenAlfabetisch();
        }

        public ICollection<Locatie> GeefAlleLocatiesAlfabetisch(string continentNaam, string landNaam)
        {
            return continenten.First(c => c.Naam == continentNaam).GeefLand(landNaam).GeefLocatiesAlfabetisch();
        }

        public Continent GeefContinent(string continentNaam)
        {
            return continenten.First(c => c.Naam == continentNaam);
        }

        public Land GeefLand(string continentNaam, string landNaam)
        {
            return continenten.First(c => c.Naam == continentNaam).GeefLand(landNaam);
        }

        public Locatie GeefLocatie(string continentNaam, string landNaam, string locatieNaam)
        {
            return continenten.First(c => c.Naam == continentNaam).GeefLand(landNaam).GeefLocatie(locatieNaam);
        }
    }
}
