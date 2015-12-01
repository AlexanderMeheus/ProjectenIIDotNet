using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class KenmerkMapper : EntityTypeConfiguration<Kenmerk>
    {
        public KenmerkMapper()
        {
            this.HasKey(t => t.KenmerkID);

            //Properties
            this.Property(t => t.KlimaatKenmerk).IsRequired().HasMaxLength(200);
            this.Property(t => t.VegetatieKenmerk).IsRequired().HasMaxLength(200);
        }
    }
}