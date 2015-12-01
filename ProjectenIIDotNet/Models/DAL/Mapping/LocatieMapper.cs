using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class LocatieMapper : EntityTypeConfiguration<Locatie>
    {
        public LocatieMapper()
        {
            //Table
            this.ToTable("Locatie");

            //Primary key
            this.HasKey(t => t.Naam);

            //Properties

            //Associaties
            this.HasRequired(t => t.Land).WithMany(l => l.Locaties);
            this.HasRequired(t => t.Klimatogram).WithRequiredPrincipal();
        }
    }
}