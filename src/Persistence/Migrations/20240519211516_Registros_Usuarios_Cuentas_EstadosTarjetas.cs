using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metafar.ATM.Challenge.Persistence.Migrations
{
    public partial class Registros_Usuarios_Cuentas_EstadosTarjetas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EstadosTarjetas",
                columns: new[] { "EstadoTarjetaId", "Descripcion" },
                values: new object[,]
                {
                    { (byte)1, "Activo" },
                    { (byte)2, "Bloqueado" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Harry" },
                    { 2, "Hermione" },
                    { 3, "Ron" }
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "CuentaId", "ActualizadoEn", "ActualizadoPor", "EstadoTarjetaId", "NumeroDeTarjeta", "Pin", "Saldo", "UsuarioId" },
                values: new object[] { 1, new DateTime(2024, 5, 19, 21, 15, 16, 678, DateTimeKind.Utc).AddTicks(71), 1, (byte)1, "1122334455667788", "1234", 1400500.25m, 1 });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "CuentaId", "ActualizadoEn", "ActualizadoPor", "EstadoTarjetaId", "NumeroDeTarjeta", "Pin", "Saldo", "UsuarioId" },
                values: new object[] { 2, new DateTime(2024, 5, 19, 21, 15, 16, 678, DateTimeKind.Utc).AddTicks(74), 2, (byte)1, "8877665544332211", "4321", 925040.50m, 2 });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "CuentaId", "ActualizadoEn", "ActualizadoPor", "EstadoTarjetaId", "NumeroDeTarjeta", "Pin", "Saldo", "UsuarioId" },
                values: new object[] { 3, new DateTime(2024, 5, 19, 21, 15, 16, 678, DateTimeKind.Utc).AddTicks(75), 3, (byte)1, "9955660044773311", "1111", 125475.25m, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EstadosTarjetas",
                keyColumn: "EstadoTarjetaId",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "EstadosTarjetas",
                keyColumn: "EstadoTarjetaId",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 3);
        }
    }
}
