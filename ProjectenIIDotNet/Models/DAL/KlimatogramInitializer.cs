using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;
using ProjectenIIDotNet.Models.Domein.Determinatie.Parameters;
using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;
using Parameter = ProjectenIIDotNet.Models.Domein.Determinatie.Parameters.Parameter;

namespace ProjectenIIDotNet.Models.DAL
{
    public class KlimatogramInitializer : DropCreateDatabaseAlways<KlimatogramContext>
    {

        protected override void Seed(KlimatogramContext context)
        {
            try
            {
                /*
                 * ==================================================================
                 * Continenten aanmaken
                 * ==================================================================
                 */
                //Europa
                Continent europa = new Continent("Europa", "150");

                //Afrika
                Continent afrika = new Continent("Afrika", "002");

                //Azië
                Continent azie = new Continent("Azië", "142");

                //Oceanië
                Continent oceanie = new Continent("Oceanië", "009");

                //Noord Amerika
                Continent noordAmerika = new Continent("Noord-Amerika", "021");

                //Zuid Amerika
                Continent zuidAmerika = new Continent("Zuid-Amerika", "005");

                /*
                 * ==================================================================
                 * Landen aanmaken
                 * ==================================================================
                 */
                //België
                Land belgie = new Land("België", "BE");

                //Frankrijk
                Land frankrijk = new Land("Frankrijk", "FR");

                //Ivoorkust
                Land ivoorkust = new Land("Ivoorkust", "CI");

                //China
                Land china = new Land("China", "CN");

                //Nieuw Zeeland
                Land nieuwZeeland = new Land("Nieuw Zeeland", "NZ");

                //Verenigde Staten
                Land verenigdeStaten = new Land("Verenigde Staten", "US");

                //Peru
                Land peru = new Land("Peru", "PE");

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
                temperaturen = new[] { -4.3, -1.9, 5.1, 13.6, 20.0, 24.2, 25.9, 24.6, 19.6, 12.7, 4.3, -2.2};
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
                IList<Kenmerk> kenmerkList = new List<Kenmerk>();
                string[] klimaten = (new string[] {"Koud klimaat zonder dooiseizoen", "Koud klimaat met dooiseizoen", "Koudgematigd klimaat met strenge winter", "Gematigd altijd droog klimaat", "Warm altijd droog klimaat", "Gematigd, droog klimaat", "Koudgematigd klimaat met strenge winter", "Koelgematigd klimaat met koude winter", "Koelgematigd klimaat met zachte winter", "Warmgematigd altijd nat klimaat", "Koelgematigd klimaat met natte winter", "Warmgematigd klimaat met natte winter", "Warmgematigd klimaat met natte zomer", "Warm klimaat met nat seizoen", "Warm altijd nat klimaat", "Koud zonder dooiseizoen", "Koud met dooiseizoen", "Koud gematigd", "Koel gematigd met strenge winter", "Koel gematigd met zachte winter", "Warm gematigd met natte winter" ,"Gematigd en droog", "Warm"});
                string[] vegetaties = (new string[] { "Ijswoestijn", "Toendra", "Taiga", "Woestijn van de middelbreedten", "Woestijn van de tropen", "Steppe", "Taiga", "Gemengd-woud", "Loofbos", "Subtropisch regenwoud", "Hardbladige-vegetatie van de centrale middelbreedten", "Hardbladige-vegetatie van subtropen", "Subtropische savanne", "Tropische savanne", "Tropisch regenwoud", "Koud", "Koud", "Gematigd", "Gematigd", "Gematigd", "Gematigd", "Droog", "Warm"});
                for (int i = 0; i < klimaten.Length; ++i)
                {
                    Kenmerk k = new Kenmerk();
                    k.KlimaatKenmerk = klimaten[i];
                    k.VegetatieKenmerk = vegetaties[i];
                    kenmerkList.Add(k);
                }

                /*
                 * ===================================================================
                 * Test determinatietabel maken
                 * 
                 * Rechts is ja
                 * Omlaag is nee
                 * 
                 * Zie Use case 3 determineertabel graad 2 & 3
                 * =================================================================== 
                 */

                //Factories maken, deze zorgen dat dezelfde waarden maar 1 keer in de db komen
                VergelijkingFactory vergelijkingFactory = new VergelijkingFactory();
                ParameterFactory parameterFactory = new ParameterFactory();

                //De vragen aanmaken
                //TW <= 10
                DeterminatieVraag d1 = new DeterminatieVraag();
                d1.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurWarmsteMaand);
                d1.Parameter2 = parameterFactory.GeefConstanteParameter(10);
                d1.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //TW <= 0
                DeterminatieVraag d2 = new DeterminatieVraag();
                d2.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurWarmsteMaand);
                d2.Parameter2 = parameterFactory.GeefConstanteParameter(0);
                d2.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //TJ <= 0
                DeterminatieVraag d3 = new DeterminatieVraag();
                d3.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.GemiddeldeJaarTemperatuur);
                d3.Parameter2 = parameterFactory.GeefConstanteParameter(0);
                d3.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //NJ <= 200
                DeterminatieVraag d4 = new DeterminatieVraag();
                d4.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.TotaleJaarNeerslag);
                d4.Parameter2 = parameterFactory.GeefConstanteParameter(200);
                d4.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //TK <= 15
                DeterminatieVraag d5 = new DeterminatieVraag();
                d5.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurKoudsteMaand);
                d5.Parameter2 = parameterFactory.GeefConstanteParameter(15);
                d5.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //TK <= 18
                DeterminatieVraag d6 = new DeterminatieVraag();
                d6.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurKoudsteMaand);
                d6.Parameter2 = parameterFactory.GeefConstanteParameter(18);
                d6.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //NJ <= 400
                DeterminatieVraag d7 = new DeterminatieVraag();
                d7.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.TotaleJaarNeerslag);
                d7.Parameter2 = parameterFactory.GeefConstanteParameter(400);
                d7.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //Tk <= -10
                DeterminatieVraag d8 = new DeterminatieVraag();
                d8.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurKoudsteMaand);
                d8.Parameter2 = parameterFactory.GeefConstanteParameter(-10);
                d8.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //D <= 1
                DeterminatieVraag d9 = new DeterminatieVraag();
                d9.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.AantalDrogeMaanden);
                d9.Parameter2 = parameterFactory.GeefConstanteParameter(1);
                d9.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //Tk <= -3
                DeterminatieVraag d10 = new DeterminatieVraag();
                d10.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurKoudsteMaand);
                d10.Parameter2 = parameterFactory.GeefConstanteParameter(-3);
                d10.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //TW <= 22
                DeterminatieVraag d11 = new DeterminatieVraag();
                d11.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurWarmsteMaand);
                d11.Parameter2 = parameterFactory.GeefConstanteParameter(22);
                d11.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                //NZ <= NW
                DeterminatieVraag d12 = new DeterminatieVraag();
                d12.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.NeerslagZomer);
                d12.Parameter2 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.NeerslagWinter);
                d12.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDanOfGelijkAan);

                
                //Boom opmaken vanaf de leafs

                Node n14 = new VraagNode(d9);
                n14.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[14]));
                n14.VoegKindToeAanNeeNode(new KenmerkNode(kenmerkList[13]));

                Node n13 = new VraagNode(d11);
                n13.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[10]));
                n13.VoegKindToeAanNeeNode(new KenmerkNode(kenmerkList[11]));

                Node n12 = new VraagNode(d12);
                n12.VoegKindToeAanJaNode(n13);
                n12.VoegKindToeAanNeeNode(new KenmerkNode(kenmerkList[12]));

                Node n11 = new VraagNode(d11);
                n11.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[8]));
                n11.VoegKindToeAanNeeNode(new KenmerkNode(kenmerkList[9]));

                Node n10 = new VraagNode(d10);
                n10.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[7]));
                n10.VoegKindToeAanNeeNode(n11);

                Node n9 = new VraagNode(d9);
                n9.VoegKindToeAanJaNode(n10);
                n9.VoegKindToeAanNeeNode(n12);

                Node n8 = new VraagNode(d8);
                n8.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[6]));
                n8.VoegKindToeAanNeeNode(n9);

                Node n7 = new VraagNode(d7);
                n7.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[5]));
                n7.VoegKindToeAanNeeNode(n8);

                Node n6 = new VraagNode(d6);
                n6.VoegKindToeAanJaNode(n7);
                n6.VoegKindToeAanNeeNode(n14);

                Node n5 = new VraagNode(d5);
                n5.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[3]));
                n5.VoegKindToeAanNeeNode(new KenmerkNode(kenmerkList[4]));

                Node n4 = new VraagNode(d4);
                n4.VoegKindToeAanJaNode(n5);
                n4.VoegKindToeAanNeeNode(n6);

                Node n3 = new VraagNode(d3);
                n3.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[2]));
                n3.VoegKindToeAanNeeNode(n4);

                Node n2 = new VraagNode(d2);
                n2.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[0]));
                n2.VoegKindToeAanNeeNode(new KenmerkNode(kenmerkList[1]));

                Node root = new VraagNode(d1);
                root.VoegKindToeAanJaNode(n2);
                root.VoegKindToeAanNeeNode(n3);

                DeterminatieTree determinatieGraad2 = new DeterminatieTree(root, Graad.graad2);
                DeterminatieTree determinatieGraad3 = new DeterminatieTree(root, Graad.graad3);

                //Opstellen determinatietree eerste graad
                //TW < 10
                d1 = new DeterminatieVraag();
                d1.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurWarmsteMaand);
                d1.Parameter2 = parameterFactory.GeefConstanteParameter(10);
                d1.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDan);

                //TW < 0
                d2 = new DeterminatieVraag();
                d2.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurWarmsteMaand);
                d2.Parameter2 = parameterFactory.GeefConstanteParameter(0);
                d2.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDan);

                //(TM >= 10) < 4
                d3 = new DeterminatieVraag();
                d3.Parameter1 =
                    parameterFactory.GeefAantalMaandenParameter(AantalMaandenParameterEnum.aantalMaandenMetTemperatuur,
                        10, vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.GroterDanOfGelijkAan));
                d3.Parameter2 = parameterFactory.GeefConstanteParameter(4);
                d3.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDan);

                //TK < 18
                d4 = new DeterminatieVraag();
                d4.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurKoudsteMaand);
                d4.Parameter2 = parameterFactory.GeefConstanteParameter(18);
                d4.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDan);

                //NJ > 400
                d5 = new DeterminatieVraag();
                d5.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.TotaleJaarNeerslag);
                d5.Parameter2 = parameterFactory.GeefConstanteParameter(400);
                d5.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.GroterDan);

                //TK < -3
                d6 = new DeterminatieVraag();
                d6.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurKoudsteMaand);
                d6.Parameter2 = parameterFactory.GeefConstanteParameter(-3);
                d6.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDan);

                //TW < 22
                d7 = new DeterminatieVraag();
                d7.Parameter1 = parameterFactory.GeefSimpeleParameter(SimpeleParameterEnum.temperatuurWarmsteMaand);
                d7.Parameter2 = parameterFactory.GeefConstanteParameter(22);
                d7.Vergelijking = vergelijkingFactory.GeefVergelijking(VergelijkingenEnum.KleinerDan);

                //Tree opstellen eerste graad
                n7 = new VraagNode(d7);
                n7.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[19]));
                n7.VoegKindToeAanNeeNode(new KenmerkNode(kenmerkList[20]));

                n6 = new VraagNode(d6);
                n6.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[18]));
                n6.VoegKindToeAanNeeNode(n7);
                
                n5 = new VraagNode(d5);
                n5.VoegKindToeAanJaNode(n6);
                n5.VoegKindToeAanNeeNode(new KenmerkNode(kenmerkList[21]));
                
                n4 = new VraagNode(d4);
                n4.VoegKindToeAanJaNode(n5);
                n4.VoegKindToeAanNeeNode(new KenmerkNode(kenmerkList[22]));
                
                n3 = new VraagNode(d3);
                n3.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[17]));
                n3.VoegKindToeAanNeeNode(n4);
                
                n2 = new VraagNode(d2);
                n2.VoegKindToeAanJaNode(new KenmerkNode(kenmerkList[15]));
                n2.VoegKindToeAanNeeNode(new KenmerkNode(kenmerkList[16]));
                
                root = new VraagNode(d1);
                root.VoegKindToeAanJaNode(n2);
                root.VoegKindToeAanNeeNode(n3);

                DeterminatieTree determinatieGraad1 = new DeterminatieTree(root, Graad.graad1);
                

                /*
                 * ==================================================================
                 * Proberen opslaan zeker?
                 * ==================================================================
                 */
                Continent[] continenten = (new Continent[] { europa, afrika, azie, oceanie, noordAmerika, zuidAmerika });
                DeterminatieTree[] trees = (new DeterminatieTree[] {determinatieGraad1, determinatieGraad2, determinatieGraad3});
                context.Continenten.AddRange(continenten);
                context.DeterminatieTrees.AddRange(trees);
                context.Kenmerken.AddRange(kenmerkList.ToArray());
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string s = "Fout creatie databank ";
                foreach (var eve in e.EntityValidationErrors)
                {
                    s += String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.GetValidationResult());
                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += String.Format("- IsActief: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(s);
            }
        }
    }
}