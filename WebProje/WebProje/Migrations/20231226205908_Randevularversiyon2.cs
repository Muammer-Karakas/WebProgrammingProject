using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    public partial class Randevularversiyon2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "BaslamaSaati",
                table: "Randevular",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BitisSaati",
                table: "Randevular",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "GunHafta",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaslamaSaati",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "BitisSaati",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "GunHafta",
                table: "Randevular");
        }
    }
}
