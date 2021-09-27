using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenerGarden.Data.Migrations
{
    public partial class SeasonModelSimplified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeasonEnd",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "SeasonStart",
                table: "Seasons");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Seasons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Seasons");

            migrationBuilder.AddColumn<DateTime>(
                name: "SeasonEnd",
                table: "Seasons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SeasonStart",
                table: "Seasons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
