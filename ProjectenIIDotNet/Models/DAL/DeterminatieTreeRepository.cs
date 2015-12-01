using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Models.DAL
{
    public class DeterminatieTreeRepository : IDeterminatieTreeRepository
    {
        private KlimatogramContext context;
        private DbSet<DeterminatieTree> determinatieTrees;

        public DeterminatieTreeRepository(KlimatogramContext context)
        {
            this.context = context;
            determinatieTrees = context.DeterminatieTrees;
        }

        public DeterminatieTree FindBy(int ID)
        {
            return determinatieTrees.Find(ID);
        }

        public ICollection<DeterminatieTree> FindByGraad(Graad graad)
        {
            return determinatieTrees.Where(d => d.Graad == graad).ToList();
        }

        public ICollection<DeterminatieTree> FindAll()
        {
            return determinatieTrees.ToList();
        }
    }
}