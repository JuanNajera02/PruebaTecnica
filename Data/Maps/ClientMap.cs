using Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Maps
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // Specify the table name (optional if it matches the class name)
            builder.ToTable("Clients");

            // Configure the primary key
            builder.HasKey(c => c.Id);

            // Configure the properties with constraints
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Address)
                   .IsRequired()
                   .HasMaxLength(200);
        }
    }
}
