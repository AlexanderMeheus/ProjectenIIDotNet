using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class ContinentMapper : EntityTypeConfiguration<Continent>
    {

        public ContinentMapper()
        {
            //Table
            this.ToTable("continent");

            //Primary key
            this.HasKey(t => t.Naam);

            //Properties => Columns
            this.Property(t => t.Naam).IsRequired();

            //Associations
        
        }
    }
}