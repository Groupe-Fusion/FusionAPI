using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FusionAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStartLocationAndOtherFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Dimension",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndLocation",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsNow",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StartLocation",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EndLocation",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsNow",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StartLocation",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Reservations");
        }
    }
}
