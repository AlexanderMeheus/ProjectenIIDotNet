using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectenIIDotNet.Models.Domein;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Models.DAL
{
    public class KlimatogramContext : DbContext
    {
        public DbSet<Continent> Continenten { get; set; }

        public DbSet<DeterminatieTree> DeterminatieTrees { get; set; }

        public DbSet<Kenmerk> Kenmerken { get; set; }

        public KlimatogramContext() : base("Klimatogrammen") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Ignore<Leerling>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}