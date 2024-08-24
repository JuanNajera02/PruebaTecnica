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
    public class ItemsMap
    {
        public void Configure(EntityTypeBuilder<Items> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(i => i.ItemId);

        }
    }
}
