using Merch_store.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TEST.Models;

namespace TEST.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Merch_store.Models.Store> Store { get; set; }
        public DbSet<Merch_store.Models.NarudzbaDizajnera> PrikazArtikala { get; set; }
        public DbSet<Merch_store.Models.Obavijest> Obavijest { get; set; }
        public DbSet<Merch_store.Models.Garderoba> Garderoba { get; set; }
        public DbSet<Boja>  Boja { get; set; }
        public DbSet<Velicina> Velicina { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<NarudzbaDizajnera>().ToTable("NarudzbaDizajnera");
            modelBuilder.Entity<Obavijest>().ToTable("Obavijest");
            modelBuilder.Entity<Garderoba>().ToTable("Garderoba");
            modelBuilder.Entity<Boja>().ToTable("Boja");
            modelBuilder.Entity<Velicina>().ToTable("Velicina");

            base.OnModelCreating(modelBuilder);
        }
    }
}
