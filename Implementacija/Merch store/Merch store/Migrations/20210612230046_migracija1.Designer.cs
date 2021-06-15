﻿// <auto-generated />
using System;
using Merch_store.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Merch_store.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210612230046_migracija1")]
    partial class migracija1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Merch_store.Models.NarudzbaDizajnera", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Boja")
                        .HasColumnType("text");

                    b.Property<double>("Cijena")
                        .HasColumnType("double");

                    b.Property<DateTime>("DatumNarudzbe")
                        .HasColumnType("datetime");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("NazivGarderobe")
                        .HasColumnType("text");

                    b.Property<DateTime>("PreostaloVrijeme")
                        .HasColumnType("datetime");

                    b.Property<string>("Velicina")
                        .HasColumnType("text");

                    b.Property<int>("korisnikID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PrikazArtikala");
                });

            modelBuilder.Entity("Merch_store.Models.Store", b =>
                {
                    b.Property<string>("Kod")
                        .HasColumnType("varchar(767)");

                    b.Property<bool>("EmailNotifikacije")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("UredajNotifikacije")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Kod");

                    b.ToTable("Store");
                });
#pragma warning restore 612, 618
        }
    }
}
