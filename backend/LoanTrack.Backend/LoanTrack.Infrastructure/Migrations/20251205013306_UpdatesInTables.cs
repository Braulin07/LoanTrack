using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoPagado",
                table: "Prestamos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Plazo",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoPagado",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "Plazo",
                table: "Prestamos");
        }
    }
}
