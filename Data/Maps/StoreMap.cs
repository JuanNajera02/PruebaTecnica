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
    public class StoreMap: IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store");

            builder.HasKey(s => s.StoreId);


        }   
    }
}
