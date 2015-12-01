using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class KlimatogramMapper : EntityTypeConfiguration<Klimatogram>
    {
        public KlimatogramMapper()
        {
            //Key
            this.HasKey(t => t.KlimatogramID);

            //Properties
            this.Property(t => t.KlimatogramID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Lengtegraad).IsRequired();
            this.Property(t => t.Breedtegraad).IsRequired();
            this.Property(t => t.StartWaarnemingen).IsRequired();
            this.Property(t => t.EindeWaarnemingen).IsRequired();

            //Associaties
            this.HasMany(t => t.MaandGegevens).WithOptional();
        }
    }
}