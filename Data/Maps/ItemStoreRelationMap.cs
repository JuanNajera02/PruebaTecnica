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
    public class ItemStoreRelationMap : IEntityTypeConfiguration<ItemStoreRelation>
    {
        public void Configure(EntityTypeBuilder<ItemStoreRelation> builder)
        {
            builder.ToTable("ItemStoreRelation");

            builder.HasKey(i => i.RelationId);

            builder.HasOne(i => i.Item)
                .WithMany(i => i.ItemStoreRelations)
                .HasForeignKey(i => i.ItemId);

            builder.HasOne(i => i.Store)
                .WithMany(i => i.ItemStoreRelations)
                .HasForeignKey(i => i.StoreId);

            builder.Property(i => i.DateAdded)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
