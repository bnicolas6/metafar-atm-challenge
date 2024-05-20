using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metafar.ATM.Challenge.Persistence.Migrations
{
    public partial class NumeroDeCuenta_Registros_TipoOperaciones_Operaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumeroDeTarjeta",
                table: "Cuentas",
                type: "char(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddColumn<string>(
                name: "NumeroDeCuenta",
                table: "Cuentas",
                type: "char(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 1,
                columns: new[] { "ActualizadoEn", "NumeroDeCuenta", "Saldo" },
                values: new object[] { new DateTime(2024, 5, 20, 0, 56, 41, 191, DateTimeKind.Utc).AddTicks(1344), "1111111111", 3400000m });

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 2,
                columns: new[] { "ActualizadoEn", "NumeroDeCuenta" },
                values: new object[] { new DateTime(2024, 5, 20, 0, 56, 41, 191, DateTimeKind.Utc).AddTicks(1347), "2222222222" });

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 3,
                columns: new[] { "ActualizadoEn", "NumeroDeCuenta" },
                values: new object[] { new DateTime(2024, 5, 20, 0, 56, 41, 191, DateTimeKind.Utc).AddTicks(1349), "3333333333" });

            migrationBuilder.InsertData(
                table: "TiposOperaciones",
                columns: new[] { "TipoOperacionId", "Descripcion" },
                values: new object[,]
                {
                    { (byte)1, "Extraccion" },
                    { (byte)2, "Deposito" }
                });

            migrationBuilder.InsertData(
                table: "Operaciones",
                columns: new[] { "OperacionId", "ActualizadoEn", "ActualizadoPor", "CuentaId", "Fecha", "Monto", "TipoOperacionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 18, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3906), 1, 1, new DateTime(2024, 5, 18, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3902), 100000m, (byte)2 },
                    { 2, new DateTime(2024, 5, 19, 0, 56, 41, 191, DateTimeKind.Utc).AddTicks(3908), 1, 1, new DateTime(2024, 5, 19, 0, 56, 41, 191, DateTimeKind.Utc).AddTicks(3908), 100000m, (byte)2 },
                    { 3, new DateTime(2024, 5, 19, 1, 56, 41, 191, DateTimeKind.Utc).AddTicks(3910), 1, 1, new DateTime(2024, 5, 19, 1, 56, 41, 191, DateTimeKind.Utc).AddTicks(3909), 150000m, (byte)2 },
                    { 4, new DateTime(2024, 5, 19, 2, 56, 41, 191, DateTimeKind.Utc).AddTicks(3911), 1, 1, new DateTime(2024, 5, 19, 2, 56, 41, 191, DateTimeKind.Utc).AddTicks(3910), 200000m, (byte)2 },
                    { 5, new DateTime(2024, 5, 19, 3, 56, 41, 191, DateTimeKind.Utc).AddTicks(3912), 1, 1, new DateTime(2024, 5, 19, 3, 56, 41, 191, DateTimeKind.Utc).AddTicks(3912), 900000m, (byte)2 },
                    { 6, new DateTime(2024, 5, 19, 4, 56, 41, 191, DateTimeKind.Utc).AddTicks(3914), 1, 1, new DateTime(2024, 5, 19, 4, 56, 41, 191, DateTimeKind.Utc).AddTicks(3913), 700000m, (byte)2 },
                    { 7, new DateTime(2024, 5, 19, 5, 56, 41, 191, DateTimeKind.Utc).AddTicks(3915), 1, 1, new DateTime(2024, 5, 19, 5, 56, 41, 191, DateTimeKind.Utc).AddTicks(3915), 1400000m, (byte)2 },
                    { 8, new DateTime(2024, 5, 19, 6, 56, 41, 191, DateTimeKind.Utc).AddTicks(3916), 1, 1, new DateTime(2024, 5, 19, 6, 56, 41, 191, DateTimeKind.Utc).AddTicks(3916), 200000m, (byte)2 },
                    { 9, new DateTime(2024, 5, 19, 7, 56, 41, 191, DateTimeKind.Utc).AddTicks(3917), 1, 1, new DateTime(2024, 5, 19, 7, 56, 41, 191, DateTimeKind.Utc).AddTicks(3917), 100000m, (byte)2 },
                    { 10, new DateTime(2024, 5, 19, 8, 56, 41, 191, DateTimeKind.Utc).AddTicks(3919), 1, 1, new DateTime(2024, 5, 19, 8, 56, 41, 191, DateTimeKind.Utc).AddTicks(3918), 2000000m, (byte)2 },
                    { 11, new DateTime(2024, 5, 19, 9, 56, 41, 191, DateTimeKind.Utc).AddTicks(3920), 1, 1, new DateTime(2024, 5, 19, 9, 56, 41, 191, DateTimeKind.Utc).AddTicks(3919), 400000m, (byte)1 },
                    { 12, new DateTime(2024, 5, 19, 10, 56, 41, 191, DateTimeKind.Utc).AddTicks(3921), 1, 1, new DateTime(2024, 5, 19, 10, 56, 41, 191, DateTimeKind.Utc).AddTicks(3921), 175000m, (byte)1 },
                    { 13, new DateTime(2024, 5, 19, 11, 56, 41, 191, DateTimeKind.Utc).AddTicks(3922), 1, 1, new DateTime(2024, 5, 19, 11, 56, 41, 191, DateTimeKind.Utc).AddTicks(3922), 300000m, (byte)1 },
                    { 14, new DateTime(2024, 5, 19, 12, 56, 41, 191, DateTimeKind.Utc).AddTicks(3924), 1, 1, new DateTime(2024, 5, 19, 12, 56, 41, 191, DateTimeKind.Utc).AddTicks(3923), 920000m, (byte)1 },
                    { 15, new DateTime(2024, 5, 19, 13, 56, 41, 191, DateTimeKind.Utc).AddTicks(3925), 1, 1, new DateTime(2024, 5, 19, 13, 56, 41, 191, DateTimeKind.Utc).AddTicks(3924), 100000m, (byte)1 },
                    { 16, new DateTime(2024, 5, 19, 14, 56, 41, 191, DateTimeKind.Utc).AddTicks(3926), 1, 1, new DateTime(2024, 5, 19, 14, 56, 41, 191, DateTimeKind.Utc).AddTicks(3926), 75000m, (byte)1 },
                    { 17, new DateTime(2024, 5, 19, 15, 56, 41, 191, DateTimeKind.Utc).AddTicks(3927), 1, 1, new DateTime(2024, 5, 19, 15, 56, 41, 191, DateTimeKind.Utc).AddTicks(3927), 25000m, (byte)1 },
                    { 18, new DateTime(2024, 5, 19, 16, 56, 41, 191, DateTimeKind.Utc).AddTicks(3929), 1, 1, new DateTime(2024, 5, 19, 16, 56, 41, 191, DateTimeKind.Utc).AddTicks(3928), 650000m, (byte)1 },
                    { 19, new DateTime(2024, 5, 19, 17, 56, 41, 191, DateTimeKind.Utc).AddTicks(3930), 1, 1, new DateTime(2024, 5, 19, 17, 56, 41, 191, DateTimeKind.Utc).AddTicks(3929), 500000m, (byte)1 },
                    { 20, new DateTime(2024, 5, 19, 18, 56, 41, 191, DateTimeKind.Utc).AddTicks(3931), 1, 1, new DateTime(2024, 5, 19, 18, 56, 41, 191, DateTimeKind.Utc).AddTicks(3930), 10000m, (byte)1 },
                    { 21, new DateTime(2024, 5, 19, 19, 56, 41, 191, DateTimeKind.Utc).AddTicks(3932), 1, 1, new DateTime(2024, 5, 19, 19, 56, 41, 191, DateTimeKind.Utc).AddTicks(3932), 45000m, (byte)1 },
                    { 22, new DateTime(2024, 5, 19, 20, 56, 41, 191, DateTimeKind.Utc).AddTicks(3933), 1, 1, new DateTime(2024, 5, 19, 20, 56, 41, 191, DateTimeKind.Utc).AddTicks(3933), 80500m, (byte)1 },
                    { 23, new DateTime(2024, 5, 19, 21, 56, 41, 191, DateTimeKind.Utc).AddTicks(3935), 1, 1, new DateTime(2024, 5, 19, 21, 56, 41, 191, DateTimeKind.Utc).AddTicks(3934), 72500.25m, (byte)1 },
                    { 24, new DateTime(2024, 5, 19, 22, 56, 41, 191, DateTimeKind.Utc).AddTicks(3936), 1, 1, new DateTime(2024, 5, 19, 22, 56, 41, 191, DateTimeKind.Utc).AddTicks(3936), 15000.75m, (byte)1 },
                    { 25, new DateTime(2024, 5, 19, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3937), 1, 1, new DateTime(2024, 5, 19, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3937), 31999m, (byte)1 },
                    { 26, new DateTime(2024, 5, 19, 19, 56, 41, 191, DateTimeKind.Utc).AddTicks(3939), 2, 2, new DateTime(2024, 5, 19, 19, 56, 41, 191, DateTimeKind.Utc).AddTicks(3938), 300000m, (byte)2 },
                    { 27, new DateTime(2024, 5, 19, 20, 56, 41, 191, DateTimeKind.Utc).AddTicks(3940), 2, 2, new DateTime(2024, 5, 19, 20, 56, 41, 191, DateTimeKind.Utc).AddTicks(3939), 50000m, (byte)2 },
                    { 28, new DateTime(2024, 5, 19, 21, 56, 41, 191, DateTimeKind.Utc).AddTicks(3941), 2, 2, new DateTime(2024, 5, 19, 21, 56, 41, 191, DateTimeKind.Utc).AddTicks(3940), 100000m, (byte)2 },
                    { 29, new DateTime(2024, 5, 19, 22, 56, 41, 191, DateTimeKind.Utc).AddTicks(3942), 2, 2, new DateTime(2024, 5, 19, 22, 56, 41, 191, DateTimeKind.Utc).AddTicks(3942), 400000m, (byte)2 },
                    { 30, new DateTime(2024, 5, 19, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3943), 2, 2, new DateTime(2024, 5, 19, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3943), 150000m, (byte)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_NumeroDeCuenta",
                table: "Cuentas",
                column: "NumeroDeCuenta",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cuentas_NumeroDeCuenta",
                table: "Cuentas");

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "OperacionId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TiposOperaciones",
                keyColumn: "TipoOperacionId",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "TiposOperaciones",
                keyColumn: "TipoOperacionId",
                keyValue: (byte)2);

            migrationBuilder.DropColumn(
                name: "NumeroDeCuenta",
                table: "Cuentas");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDeTarjeta",
                table: "Cuentas",
                type: "varchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(16)",
                oldMaxLength: 16);

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 1,
                columns: new[] { "ActualizadoEn", "Saldo" },
                values: new object[] { new DateTime(2024, 5, 19, 22, 5, 50, 632, DateTimeKind.Utc).AddTicks(326), 1400500.25m });

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 2,
                column: "ActualizadoEn",
                value: new DateTime(2024, 5, 19, 22, 5, 50, 632, DateTimeKind.Utc).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 3,
                column: "ActualizadoEn",
                value: new DateTime(2024, 5, 19, 22, 5, 50, 632, DateTimeKind.Utc).AddTicks(329));
        }
    }
}
