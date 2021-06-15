using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Merch_store.Migrations
{
    public partial class migracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrikazArtikala",
                table: "PrikazArtikala");

            migrationBuilder.RenameTable(
                name: "PrikazArtikala",
                newName: "NarudzbaDizajnera");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NarudzbaDizajnera",
                table: "NarudzbaDizajnera",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    korisnikID = table.Column<int>(nullable: false),
                    sadrzaj = table.Column<string>(nullable: true),
                    tip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NarudzbaDizajnera",
                table: "NarudzbaDizajnera");

            migrationBuilder.RenameTable(
                name: "NarudzbaDizajnera",
                newName: "PrikazArtikala");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrikazArtikala",
                table: "PrikazArtikala",
                column: "ID");
        }
    }
}
