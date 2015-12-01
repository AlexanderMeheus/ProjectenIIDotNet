using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class DeterminatieTreeMapper : EntityTypeConfiguration<DeterminatieTree>
    {
        public DeterminatieTreeMapper()
        {
            this.HasKey(t => t.DeterminatieTreeID);

            //Properties
            this.Property(t => t.DeterminatieTreeID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Graad).IsRequired();

            //Associaties
            this.HasRequired(t => t.Root);

            //Overbodig
            this.Ignore(t => t.Keuzes);
        }
    }
}