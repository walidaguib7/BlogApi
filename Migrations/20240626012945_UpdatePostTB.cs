using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_file_FilesId",
                table: "posts");

            migrationBuilder.AlterColumn<int>(
                name: "FilesId",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_file_FilesId",
                table: "posts",
                column: "FilesId",
                principalTable: "file",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_file_FilesId",
                table: "posts");

            migrationBuilder.AlterColumn<int>(
                name: "FilesId",
                table: "posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_file_FilesId",
                table: "posts",
                column: "FilesId",
                principalTable: "file",
                principalColumn: "id");
        }
    }
}
