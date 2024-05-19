using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metafar.ATM.Challenge.Persistence.Migrations
{
    public partial class Bloquear_Cuenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 1,
                column: "ActualizadoEn",
                value: new DateTime(2024, 5, 19, 22, 5, 50, 632, DateTimeKind.Utc).AddTicks(326));

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 2,
                columns: new[] { "ActualizadoEn", "EstadoTarjetaId" },
                values: new object[] { new DateTime(2024, 5, 19, 22, 5, 50, 632, DateTimeKind.Utc).AddTicks(328), (byte)2 });

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 3,
                column: "ActualizadoEn",
                value: new DateTime(2024, 5, 19, 22, 5, 50, 632, DateTimeKind.Utc).AddTicks(329));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 1,
                column: "ActualizadoEn",
                value: new DateTime(2024, 5, 19, 21, 15, 16, 678, DateTimeKind.Utc).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 2,
                columns: new[] { "ActualizadoEn", "EstadoTarjetaId" },
                values: new object[] { new DateTime(2024, 5, 19, 21, 15, 16, 678, DateTimeKind.Utc).AddTicks(74), (byte)1 });

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 3,
                column: "ActualizadoEn",
                value: new DateTime(2024, 5, 19, 21, 15, 16, 678, DateTimeKind.Utc).AddTicks(75));
        }
    }
}
