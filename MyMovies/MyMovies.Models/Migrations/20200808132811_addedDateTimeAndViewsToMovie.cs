using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Data.Migrations
{
    public partial class addedDateTimeAndViewsToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Movies",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Movies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Movies");
        }
    }
}
