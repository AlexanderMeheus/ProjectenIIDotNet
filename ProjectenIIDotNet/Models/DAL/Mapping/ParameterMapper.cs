using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein.Determinatie.Parameters;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class ParameterMapper : EntityTypeConfiguration<Parameter>
    {
        public ParameterMapper()
        {
            this.HasKey(t => t.ParameterID);
            this.ToTable("Parameter");

            //Properties
            this.Property(t => t.ParameterID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Ignore(t => t.Benaming);
            this.Ignore(t => t.Symbool);
        }
    }
}