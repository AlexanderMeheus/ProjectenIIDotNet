using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class LandMapper : EntityTypeConfiguration<Land>
    {

        public LandMapper()
        {
            //Table
            this.ToTable("Land");

            //Primary key
            this.HasKey(t => t.Naam);

            //Properties => Columns
            this.Property(t => t.Naam).IsRequired();

            //Associations
            this.HasRequired(t => t.Continent).WithMany(c => c.Landen);

        }
    }
}