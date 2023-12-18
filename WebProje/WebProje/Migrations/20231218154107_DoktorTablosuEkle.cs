using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    public partial class DoktorTablosuEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoktorlarTablosu",
                columns: table => new
                {
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uzmanlik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GunHafta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslamaSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    BitisSaati = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorlarTablosu", x => x.DoktorId);
                });

            migrationBuilder.CreateTable(
                name: "KlinikTurleri",
                columns: table => new
                {
                    KlinikTuruId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlinikTurleri", x => x.KlinikTuruId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoktorlarTablosu");

            migrationBuilder.DropTable(
                name: "KlinikTurleri");
        }
    }
}
