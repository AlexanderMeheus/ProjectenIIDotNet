using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Models.DAL.Mapping
{
    public class VraagNodeMapper : EntityTypeConfiguration<VraagNode>
    {

        public VraagNodeMapper()
        {
            //this.HasKey(t => t.NodeID);
            this.ToTable("VraagNode");

            //Associaties
            this.HasRequired(t => t.JaKind);
            this.HasRequired(t => t.NeeKind);
            this.HasRequired(t => t.Vraag);
            //this.Ignore(t => t.Vraag);

        }
    }
}