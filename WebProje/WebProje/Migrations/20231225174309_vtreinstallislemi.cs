using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    public partial class vtreinstallislemi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "DoktorlarTablosu",
                columns: table => new
                {
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uzmanlik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KlinikId = table.Column<int>(type: "int", nullable: false),
                    GunHafta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslamaSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    BitisSaati = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorlarTablosu", x => x.DoktorId);
                    table.ForeignKey(
                        name: "FK_DoktorlarTablosu_KlinikTurleri_KlinikId",
                        column: x => x.KlinikId,
                        principalTable: "KlinikTurleri",
                        principalColumn: "KlinikTuruId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoktorlarTablosu_KlinikId",
                table: "DoktorlarTablosu",
                column: "KlinikId");
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
