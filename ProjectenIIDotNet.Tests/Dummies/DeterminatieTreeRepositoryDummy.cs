using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectenIIDotNet.Models.Domein.Determinatie.Parameters;
using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;

namespace ProjectenIIDotNet.Tests.Dummies
{
    class DeterminatieTreeRepositoryDummy: IDeterminatieTreeRepository
    {

        private Node root;
        private DeterminatieTree current;

        public DeterminatieTreeRepositoryDummy()
        {
            /*
                 * Test determinatietabel maken
                 * 
                 * Rechts is ja
                 * Omlaag is nee
                 * 
                 * Tw <= 10
                 * 
                 */
            Parameter temperatuurWarmsteMaand = new TemperatuurWarmsteMaandParameter();
            Parameter constanteTien = new ConstanteWaardeParameter(10);
            Vergelijking kleinerDanOfGelijkAan = new KleinerDanOfGelijkAan();
            DeterminatieVraag determinatieVraag = new DeterminatieVraag();

            determinatieVraag.Parameter1 = temperatuurWarmsteMaand;
            determinatieVraag.Parameter2 = constanteTien;
            determinatieVraag.Vergelijking = kleinerDanOfGelijkAan;

            Kenmerk koudKenmerk = new Kenmerk();
            koudKenmerk.KlimaatKenmerk = "Heel koud klimaat";
            koudKenmerk.VegetatieKenmerk = "Ijsplanten";

            Kenmerk warmKenmerk = new Kenmerk();
            warmKenmerk.KlimaatKenmerk = "Warm klimaat";
            warmKenmerk.VegetatieKenmerk = "Bloemen";

            root = new VraagNode(determinatieVraag);
            root.VoegKindToeAanJaNode(new KenmerkNode(koudKenmerk));
            root.VoegKindToeAanNeeNode(new KenmerkNode(warmKenmerk));

            current = new DeterminatieTree(root, Graad.graad2);
        }

        public DeterminatieTree GetCurrent()
        {
            return current;
        }

        public DeterminatieTree FindBy(int ID)
        {
            return current;
        }

        public ICollection<DeterminatieTree> FindByGraad(Graad graad)
        {
            IList<DeterminatieTree> list = new List<DeterminatieTree>();
            current = new DeterminatieTree(root, graad);
            list.Add(current);
            return list;
        }

        public ICollection<DeterminatieTree> FindAll()
        {
            IList<DeterminatieTree> list = new List<DeterminatieTree>();
            list.Add(new DeterminatieTree(root, Graad.graad1));
            list.Add(new DeterminatieTree(root, Graad.graad2));
            list.Add(new DeterminatieTree(root, Graad.graad3));
            return list;
        }
    }
}
