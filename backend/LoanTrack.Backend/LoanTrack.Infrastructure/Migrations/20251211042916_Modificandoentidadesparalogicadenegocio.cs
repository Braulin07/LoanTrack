using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modificandoentidadesparalogicadenegocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaVencimiento",
                table: "Prestamos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicio",
                table: "Prestamos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaUltimoPago",
                table: "Prestamos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "InteresesPagados",
                table: "Prestamos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPago",
                table: "Pagos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<decimal>(
                name: "MontoCapital",
                table: "Pagos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoInteres",
                table: "Pagos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaUltimoPago",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "InteresesPagados",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "MontoCapital",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "MontoInteres",
                table: "Pagos");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaVencimiento",
                table: "Prestamos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaInicio",
                table: "Prestamos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaPago",
                table: "Pagos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
