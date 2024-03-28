using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Data_ClassLib.Migrations
{
    public partial class ahihi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HoaDon",
                table: "HoaDon");

            migrationBuilder.RenameTable(
                name: "HoaDon",
                newName: "Hoadons");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDon_UserId",
                table: "Hoadons",
                newName: "IX_Hoadons_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hoadons",
                table: "Hoadons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hoadons",
                table: "Hoadons");

            migrationBuilder.RenameTable(
                name: "Hoadons",
                newName: "HoaDon");

            migrationBuilder.RenameIndex(
                name: "IX_Hoadons_UserId",
                table: "HoaDon",
                newName: "IX_HoaDon_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoaDon",
                table: "HoaDon",
                column: "Id");
        }
    }
}
