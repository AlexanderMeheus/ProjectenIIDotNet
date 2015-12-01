using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class NodeMapper : EntityTypeConfiguration<Node>
    {
        public NodeMapper()
        {
            this.HasKey(t => t.NodeID);
            this.ToTable("Node");

            //Associaties
            this.HasOptional(t => t.Ouder);

            //Overerving

        }
    }
}