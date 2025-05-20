using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FusionAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    DeliveryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CardOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardCvc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardExpiry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSavedForFutureUse = table.Column<bool>(type: "bit", nullable: false),
                    FacturationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacturationCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacturationPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacturationCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
