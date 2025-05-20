using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FusionAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddALotOfNewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "InHour",
                table: "Reservations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PackageType",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Reservations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RecipientAddress",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientCity",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientName",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientPhone",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientPostalCode",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReservationStatus",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isFragile",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "InHour",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PackageType",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RecipientAddress",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RecipientCity",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RecipientName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RecipientPhone",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RecipientPostalCode",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationStatus",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "isFragile",
                table: "Reservations");
        }
    }
}
