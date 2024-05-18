using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metafar.ATM.Challenge.Persistence.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosTarjetas",
                columns: table => new
                {
                    EstadoTarjetaId = table.Column<byte>(type: "tinyint", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosTarjetas", x => x.EstadoTarjetaId);
                });

            migrationBuilder.CreateTable(
                name: "TiposOperaciones",
                columns: table => new
                {
                    TipoOperacionId = table.Column<byte>(type: "tinyint", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposOperaciones", x => x.TipoOperacionId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    CuentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NumeroDeTarjeta = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Pin = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    EstadoTarjetaId = table.Column<byte>(type: "tinyint", nullable: false),
                    ActualizadoPor = table.Column<int>(type: "int", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.CuentaId);
                    table.ForeignKey(
                        name: "FK_Cuentas_ActualizadoPor_Usuarios",
                        column: x => x.ActualizadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Cuentas_EstadoTarjetaId_EstadosTarjetas",
                        column: x => x.EstadoTarjetaId,
                        principalTable: "EstadosTarjetas",
                        principalColumn: "EstadoTarjetaId");
                    table.ForeignKey(
                        name: "FK_Cuentas_UsuarioId_Usuarios",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    OperacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuentaId = table.Column<int>(type: "int", nullable: false),
                    TipoOperacionId = table.Column<byte>(type: "tinyint", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ActualizadoPor = table.Column<int>(type: "int", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.OperacionId);
                    table.ForeignKey(
                        name: "FK_Operaciones_ActualizadaPor_Usuarios",
                        column: x => x.ActualizadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Operaciones_CuentaId_Cuentas",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "CuentaId");
                    table.ForeignKey(
                        name: "FK_Operaciones_TipoOperacionId_TiposOperaciones",
                        column: x => x.TipoOperacionId,
                        principalTable: "TiposOperaciones",
                        principalColumn: "TipoOperacionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_ActualizadoPor",
                table: "Cuentas",
                column: "ActualizadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_EstadoTarjetaId",
                table: "Cuentas",
                column: "EstadoTarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_NumeroDeTarjeta",
                table: "Cuentas",
                column: "NumeroDeTarjeta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UsuarioId",
                table: "Cuentas",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_ActualizadoPor",
                table: "Operaciones",
                column: "ActualizadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_CuentaId",
                table: "Operaciones",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_TipoOperacionId",
                table: "Operaciones",
                column: "TipoOperacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "TiposOperaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "EstadosTarjetas");
        }
    }
}
