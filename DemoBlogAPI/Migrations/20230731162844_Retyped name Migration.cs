using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoBlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class RetypednameMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommnetId",
                table: "Comments",
                newName: "Commentd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Commentd",
                table: "Comments",
                newName: "CommnetId");
        }
    }
}
