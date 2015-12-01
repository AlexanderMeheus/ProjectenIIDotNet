using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class KenmerkNodeMapper : EntityTypeConfiguration<KenmerkNode>
    {
        public KenmerkNodeMapper()
        {
            //this.HasKey(t => t.NodeID);
            this.ToTable("KenmerkNode");

            //Properties

            //Associaties
            this.HasRequired(t => t.Kenmerk);
            //this.Ignore(t => t.Kenmerk);
        }
    }
}