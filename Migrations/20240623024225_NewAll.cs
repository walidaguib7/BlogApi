using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class NewAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_posts_CategoryId",
                table: "posts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_category_CategoryId",
                table: "posts",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_category_CategoryId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_CategoryId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "posts");
        }
    }
}
