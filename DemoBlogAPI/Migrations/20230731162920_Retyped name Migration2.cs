using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoBlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class RetypednameMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Commentd",
                table: "Comments",
                newName: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "Commentd");
        }
    }
}
