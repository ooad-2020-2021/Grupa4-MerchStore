using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace TEST.Migrations
{
    public partial class migracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusNarudzbe",
                table: "NarudzbaDizajnera",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Boja",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garderoba",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    DostupneBoje = table.Column<string>(nullable: true),
                    DostupneVelicine = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garderoba", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Velicina",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Velicina", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boja");

            migrationBuilder.DropTable(
                name: "Garderoba");

            migrationBuilder.DropTable(
                name: "Velicina");

            migrationBuilder.DropColumn(
                name: "StatusNarudzbe",
                table: "NarudzbaDizajnera");
        }
    }
}
