using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NombreQueQuieras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tinteres",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tinteres",
                table: "Prestamos");
        }
    }
}
