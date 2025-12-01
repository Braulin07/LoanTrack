using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontoPrestado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaVencimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontoPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateOnly>(type: "date", nullable: false),
                    MetodoPago = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPrestamo = table.Column<int>(type: "int", nullable: false),
                    PrestamoIdPrestamo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Prestamos_PrestamoIdPrestamo",
                        column: x => x.PrestamoIdPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "IdPrestamo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_PrestamoIdPrestamo",
                table: "Pagos",
                column: "PrestamoIdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_ClienteIdCliente",
                table: "Prestamos",
                column: "ClienteIdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
