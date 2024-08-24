using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Data.Maps
{
    public class ClientItemRelationMap
    {
        public void Configure(EntityTypeBuilder<ClientItemRelation> builder)
        {
            builder.ToTable("ClientItemRelation");

            builder.HasKey(cir => cir.RelationId);

            builder.HasOne(cir => cir.Client)
                .WithMany(c => c.ClientItemRelations)
                .HasForeignKey(cir => cir.ClientId);

            builder.HasOne(cir => cir.Item)
                .WithMany(i => i.ClientItemRelations)
                .HasForeignKey(cir => cir.ItemId);

            builder.Property(i => i.DateAdded)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
