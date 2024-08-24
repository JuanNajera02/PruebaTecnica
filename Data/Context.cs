using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Data.Maps;
using Entity.Entities;



namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            new ClientMap().Configure(modelBuilder.Entity<Client>());
            new StoreMap().Configure(modelBuilder.Entity<Store>());
            new ItemsMap().Configure(modelBuilder.Entity<Items>());
            new ItemStoreRelationMap().Configure(modelBuilder.Entity<ItemStoreRelation>());
            new ClientItemRelationMap().Configure(modelBuilder.Entity<ClientItemRelation>());
        }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<ItemStoreRelation> ItemStoreRelation { get; set; }
        public virtual DbSet<ClientItemRelation> ClientItemRelation { get; set; }

    }
}
