using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingPropertieskey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Prestamos_PrestamoIdPrestamo",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Clientes_ClienteIdCliente",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_ClienteIdCliente",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "IdPrestamo",
                table: "Pagos");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Prestamos",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "IdPrestamo",
                table: "Prestamos",
                newName: "PrestamoId");

            migrationBuilder.RenameColumn(
                name: "PrestamoIdPrestamo",
                table: "Pagos",
                newName: "PrestamoId");

            migrationBuilder.RenameColumn(
                name: "IdPago",
                table: "Pagos",
                newName: "PagoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pagos_PrestamoIdPrestamo",
                table: "Pagos",
                newName: "IX_Pagos_PrestamoId");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Clientes",
                newName: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_ClienteId",
                table: "Prestamos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Prestamos_PrestamoId",
                table: "Pagos",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "PrestamoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Clientes_ClienteId",
                table: "Prestamos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Prestamos_PrestamoId",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Clientes_ClienteId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_ClienteId",
                table: "Prestamos");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Prestamos",
                newName: "IdCliente");

            migrationBuilder.RenameColumn(
                name: "PrestamoId",
                table: "Prestamos",
                newName: "IdPrestamo");

            migrationBuilder.RenameColumn(
                name: "PrestamoId",
                table: "Pagos",
                newName: "PrestamoIdPrestamo");

            migrationBuilder.RenameColumn(
                name: "PagoId",
                table: "Pagos",
                newName: "IdPago");

            migrationBuilder.RenameIndex(
                name: "IX_Pagos_PrestamoId",
                table: "Pagos",
                newName: "IX_Pagos_PrestamoIdPrestamo");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Clientes",
                newName: "IdCliente");

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPrestamo",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_ClienteIdCliente",
                table: "Prestamos",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Prestamos_PrestamoIdPrestamo",
                table: "Pagos",
                column: "PrestamoIdPrestamo",
                principalTable: "Prestamos",
                principalColumn: "IdPrestamo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Clientes_ClienteIdCliente",
                table: "Prestamos",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
