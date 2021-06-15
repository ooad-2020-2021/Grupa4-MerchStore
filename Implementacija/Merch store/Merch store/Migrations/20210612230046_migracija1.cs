using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Merch_store.Migrations
{
    public partial class migracija1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrikazArtikala",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    korisnikID = table.Column<int>(nullable: false),
                    NazivGarderobe = table.Column<string>(nullable: true),
                    Boja = table.Column<string>(nullable: true),
                    Velicina = table.Column<string>(nullable: true),
                    Kolicina = table.Column<int>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    DatumNarudzbe = table.Column<DateTime>(nullable: false),
                    PreostaloVrijeme = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrikazArtikala", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Kod = table.Column<string>(nullable: false),
                    EmailNotifikacije = table.Column<bool>(nullable: false),
                    UredajNotifikacije = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Kod);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrikazArtikala");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
