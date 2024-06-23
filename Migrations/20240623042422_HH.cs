using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class HH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "posts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedAt",
                table: "posts",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdatedAt",
                table: "posts",
                type: "date",
                nullable: true);
        }
    }
}
