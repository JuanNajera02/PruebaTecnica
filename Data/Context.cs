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
        }
        public virtual DbSet<Client> Client { get; set; }
    }
}
