using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.ViewModels
{
    public class DeterminatieTreeViewModel
    {

        public DeterminatieTreeViewModel(DeterminatieTree tree)
        {
            Breedte = 0;
            Hoogte = 0;
            Graad = tree.Graad;
            Root = InitStack(tree.Root, 0, tree.GeefHuidigeNode());
        }

        public Graad Graad { get; set; }


        private NodeViewModel InitStack(Node n, int b, Node huidigNode)
        {
            NodeViewModel model = new NodeViewModel(n);
            if (huidigNode == n)
            {
                model.IsHuidige = true;
            }
            if (n is VraagNode)
            {
                model.JaKind = InitStack(((VraagNode) n).JaKind, b + 1, huidigNode);
                model.NeeKind = InitStack(((VraagNode) n).NeeKind, b, huidigNode);
            }
            else
            {
                ++Hoogte;
            }
            if (b > Breedte) Breedte = b;
            return model;
        }

        public NodeViewModel Root { get; set; }

        public int Breedte { get; set; }

        public int Hoogte { get; set; }

    }

    public class NodeViewModel
    {
        public NodeViewModel(Node n)
        {
            IsVraag = (n is VraagNode);
            IsHuidige = false;
            if (IsVraag) Vraag = new DeterminatieVraagViewModel(((VraagNode)n).Vraag);
            else Kenmerk = new KenmerkViewModel(((KenmerkNode)n).Kenmerk);
        }

        public NodeViewModel JaKind { get; set; }

        public NodeViewModel NeeKind { get; set; }

        public bool IsVraag { get; set; }

        public bool IsHuidige { get; set; }
        
        public DeterminatieVraagViewModel Vraag { get; set; }

        public KenmerkViewModel Kenmerk { get; set; }


    }
}