using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Merch_store.Models;

namespace Merch_store.Data
{
    public class DataContext : DbContext
    {

        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Merch_store.Models.Store> Store { get; set; }
        public DbSet<Merch_store.Models.NarudzbaDizajnera> PrikazArtikala { get; set; }
        public DbSet<Merch_store.Models.Obavijest> Obavijest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<NarudzbaDizajnera>().ToTable("NarudzbaDizajnera");
            modelBuilder.Entity<Obavijest>().ToTable("Obavijest");
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
