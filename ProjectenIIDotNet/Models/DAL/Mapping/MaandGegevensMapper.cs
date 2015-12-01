using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class MaandGegevensMapper : EntityTypeConfiguration<MaandGegevens>
    {
        public MaandGegevensMapper()
        {
            //Key
            this.HasKey(t => t.MaandGegevensID);

            //Properties
            this.Property(t => t.MaandGegevensID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Maand).IsRequired();
            this.Property(t => t.Neerslag).IsRequired();
            this.Property(t => t.Temperatuur).IsRequired();
        }
    }
}