using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    public partial class RandevularTablosuEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    RandevuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaId = table.Column<int>(type: "int", nullable: false),
                    DoktorRandevuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuId);
                    table.ForeignKey(
                        name: "FK_Randevular_DoktorlarTablosu_DoktorRandevuId",
                        column: x => x.DoktorRandevuId,
                        principalTable: "DoktorlarTablosu",
                        principalColumn: "DoktorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorRandevuId",
                table: "Randevular",
                column: "DoktorRandevuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Randevular");
        }
    }
}
