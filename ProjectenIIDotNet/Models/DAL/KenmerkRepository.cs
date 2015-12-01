using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectenIIDotNet.Models.DAL
{
    public class KenmerkRepository : IKenmerkRepository
    {
        private KlimatogramContext context;
        private DbSet<Kenmerk> Kenmerken;
        public KenmerkRepository(KlimatogramContext c)
        {
            this.context = c;
            this.Kenmerken = c.Kenmerken;
        }

        public Kenmerk FindBy(int id)
        {
            return Kenmerken.Find(id);
        }

        public ICollection<Kenmerk> FindAll()
        {
            return Kenmerken.ToList();
        }
    }
}