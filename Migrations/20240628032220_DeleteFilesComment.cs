using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFilesComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_file_FilesId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_FilesId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "FilesId",
                table: "comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilesId",
                table: "comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_FilesId",
                table: "comments",
                column: "FilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_file_FilesId",
                table: "comments",
                column: "FilesId",
                principalTable: "file",
                principalColumn: "id");
        }
    }
}
