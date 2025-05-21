using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FusionAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPrestatire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrestataireId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PrestataireId",
                table: "Reservations",
                column: "PrestataireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_PrestataireId",
                table: "Reservations",
                column: "PrestataireId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_PrestataireId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PrestataireId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PrestataireId",
                table: "Reservations");
        }
    }
}
