using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoInteres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tinteres",
                table: "Prestamos",
                newName: "TipoInteres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoInteres",
                table: "Prestamos",
                newName: "Tinteres");
        }
    }
}
