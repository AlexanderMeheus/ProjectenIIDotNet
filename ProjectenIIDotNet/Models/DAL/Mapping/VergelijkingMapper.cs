using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein.Determinatie.Vergelijkingen;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class VergelijkingMapper : EntityTypeConfiguration<Vergelijking>
    {
        public VergelijkingMapper()
        {
            this.HasKey(t => t.VergelijkingID);

            //Properties
            this.Ignore(t => t.Symbool);
            this.Ignore(t => t.Benaming);
        }
    }
}