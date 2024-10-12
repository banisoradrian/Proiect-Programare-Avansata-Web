using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewLitereMARI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "Reviews",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "RATING",
                table: "Reviews",
                newName: "RATING");

            migrationBuilder.RenameColumn(
                name: "CONTENT",
                table: "Reviews",
                newName: "CONTENT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "Reviews",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "RATING",
                table: "Reviews",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "CONTENT",
                table: "Reviews",
                newName: "CONTENT");
        }
    }
}
