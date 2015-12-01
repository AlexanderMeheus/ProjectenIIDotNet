using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein.Determinatie.Parameters;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class AantalMaandenParameterMapper : EntityTypeConfiguration<AantalMaandenParameter>
    {
        public AantalMaandenParameterMapper()
        {
            //Associaties
            this.HasRequired(t => t.Vergelijking).WithMany().WillCascadeOnDelete(false);
        }
    }
}