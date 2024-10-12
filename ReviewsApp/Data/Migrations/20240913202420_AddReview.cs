using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RATING = table.Column<int>(type: "int", nullable: false),
                    SUBJECT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATEDBYId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_CREATEDBYId",
                        column: x => x.CREATEDBYId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CREATEDBYId",
                table: "Reviews",
                column: "CREATEDBYId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
