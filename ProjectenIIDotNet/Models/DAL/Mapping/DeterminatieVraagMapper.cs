using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class DeterminatieVraagMapper : EntityTypeConfiguration<DeterminatieVraag>
    {
        public DeterminatieVraagMapper()
        {
            this.HasKey(t => t.DeterminatieVraagID);

            //Properties
            this.Property(t => t.DeterminatieVraagID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Associaties
            this.HasRequired(t => t.Vergelijking);
            this.HasRequired(t => t.Parameter1).WithMany().WillCascadeOnDelete(false);
            this.HasRequired(t => t.Parameter2).WithMany().WillCascadeOnDelete(false);
        }
    }
}