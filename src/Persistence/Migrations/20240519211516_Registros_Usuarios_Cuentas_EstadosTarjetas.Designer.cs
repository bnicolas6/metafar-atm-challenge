﻿// <auto-generated />
using System;
using Metafar.ATM.Challenge.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Metafar.ATM.Challenge.Persistence.Migrations
{
    [DbContext(typeof(ATMDbContext))]
    [Migration("20240519211516_Registros_Usuarios_Cuentas_EstadosTarjetas")]
    partial class Registros_Usuarios_Cuentas_EstadosTarjetas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.Cuenta", b =>
                {
                    b.Property<int>("CuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuentaId"), 1L, 1);

                    b.Property<DateTime>("ActualizadoEn")
                        .HasColumnType("datetime");

                    b.Property<int>("ActualizadoPor")
                        .HasColumnType("int");

                    b.Property<byte>("EstadoTarjetaId")
                        .HasColumnType("tinyint");

                    b.Property<string>("NumeroDeTarjeta")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("char(4)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("CuentaId")
                        .HasName("PK_Cuentas");

                    b.HasIndex("ActualizadoPor");

                    b.HasIndex("EstadoTarjetaId");

                    b.HasIndex("NumeroDeTarjeta")
                        .IsUnique();

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Cuentas", (string)null);

                    b.HasData(
                        new
                        {
                            CuentaId = 1,
                            ActualizadoEn = new DateTime(2024, 5, 19, 21, 15, 16, 678, DateTimeKind.Utc).AddTicks(71),
                            ActualizadoPor = 1,
                            EstadoTarjetaId = (byte)1,
                            NumeroDeTarjeta = "1122334455667788",
                            Pin = "1234",
                            Saldo = 1400500.25m,
                            UsuarioId = 1
                        },
                        new
                        {
                            CuentaId = 2,
                            ActualizadoEn = new DateTime(2024, 5, 19, 21, 15, 16, 678, DateTimeKind.Utc).AddTicks(74),
                            ActualizadoPor = 2,
                            EstadoTarjetaId = (byte)1,
                            NumeroDeTarjeta = "8877665544332211",
                            Pin = "4321",
                            Saldo = 925040.50m,
                            UsuarioId = 2
                        },
                        new
                        {
                            CuentaId = 3,
                            ActualizadoEn = new DateTime(2024, 5, 19, 21, 15, 16, 678, DateTimeKind.Utc).AddTicks(75),
                            ActualizadoPor = 3,
                            EstadoTarjetaId = (byte)1,
                            NumeroDeTarjeta = "9955660044773311",
                            Pin = "1111",
                            Saldo = 125475.25m,
                            UsuarioId = 3
                        });
                });

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.EstadoTarjeta", b =>
                {
                    b.Property<byte>("EstadoTarjetaId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("EstadoTarjetaId")
                        .HasName("PK_EstadosTarjetas");

                    b.ToTable("EstadosTarjetas", (string)null);

                    b.HasData(
                        new
                        {
                            EstadoTarjetaId = (byte)1,
                            Descripcion = "Activo"
                        },
                        new
                        {
                            EstadoTarjetaId = (byte)2,
                            Descripcion = "Bloqueado"
                        });
                });

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.Operacion", b =>
                {
                    b.Property<int>("OperacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OperacionId"), 1L, 1);

                    b.Property<DateTime>("ActualizadoEn")
                        .HasColumnType("datetime");

                    b.Property<int>("ActualizadoPor")
                        .HasColumnType("int");

                    b.Property<int>("CuentaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(10,2)");

                    b.Property<byte>("TipoOperacionId")
                        .HasColumnType("tinyint");

                    b.HasKey("OperacionId")
                        .HasName("PK_Operaciones");

                    b.HasIndex("ActualizadoPor");

                    b.HasIndex("CuentaId");

                    b.HasIndex("TipoOperacionId");

                    b.ToTable("Operaciones", (string)null);
                });

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.TipoOperacion", b =>
                {
                    b.Property<byte>("TipoOperacionId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("TipoOperacionId")
                        .HasName("PK_TiposOperaciones");

                    b.ToTable("TiposOperaciones", (string)null);
                });

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("UsuarioId")
                        .HasName("PK_Usuarios");

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Nombre = "Harry"
                        },
                        new
                        {
                            UsuarioId = 2,
                            Nombre = "Hermione"
                        },
                        new
                        {
                            UsuarioId = 3,
                            Nombre = "Ron"
                        });
                });

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.Cuenta", b =>
                {
                    b.HasOne("Metafar.ATM.Challenge.Domain.Entities.Usuario", "ActualizadoPorNavigation")
                        .WithMany("CuentasActualizadasNavigation")
                        .HasForeignKey("ActualizadoPor")
                        .IsRequired()
                        .HasConstraintName("FK_Cuentas_ActualizadoPor_Usuarios");

                    b.HasOne("Metafar.ATM.Challenge.Domain.Entities.EstadoTarjeta", "EstadoTarjetaNavigation")
                        .WithMany("CuentasNavigation")
                        .HasForeignKey("EstadoTarjetaId")
                        .IsRequired()
                        .HasConstraintName("FK_Cuentas_EstadoTarjetaId_EstadosTarjetas");

                    b.HasOne("Metafar.ATM.Challenge.Domain.Entities.Usuario", "UsuarioNavigation")
                        .WithOne("CuentaPropietarioNavigation")
                        .HasForeignKey("Metafar.ATM.Challenge.Domain.Entities.Cuenta", "UsuarioId")
                        .IsRequired()
                        .HasConstraintName("FK_Cuentas_UsuarioId_Usuarios");

                    b.Navigation("ActualizadoPorNavigation");

                    b.Navigation("EstadoTarjetaNavigation");

                    b.Navigation("UsuarioNavigation");
                });

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.Operacion", b =>
                {
                    b.HasOne("Metafar.ATM.Challenge.Domain.Entities.Usuario", "ActualizadoPorNavigation")
                        .WithMany("OperacionesActualizadasNavigation")
                        .HasForeignKey("ActualizadoPor")
                        .IsRequired()
                        .HasConstraintName("FK_Operaciones_ActualizadaPor_Usuarios");

                    b.HasOne("Metafar.ATM.Challenge.Domain.Entities.Cuenta", "CuentaNavigation")
                        .WithMany("OperacionesNavigation")
                        .HasForeignKey("CuentaId")
                        .IsRequired()
                        .HasConstraintName("FK_Operaciones_CuentaId_Cuentas");

                    b.HasOne("Metafar.ATM.Challenge.Domain.Entities.TipoOperacion", "TipoOperacionNavigation")
                        .WithMany("OperacionesNavigation")
                        .HasForeignKey("TipoOperacionId")
                        .IsRequired()
                        .HasConstraintName("FK_Operaciones_TipoOperacionId_TiposOperaciones");

                    b.Navigation("ActualizadoPorNavigation");

                    b.Navigation("CuentaNavigation");

                    b.Navigation("TipoOperacionNavigation");
                });

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.Cuenta", b =>
                {
                    b.Navigation("OperacionesNavigation");
                });

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.EstadoTarjeta", b =>
                {
                    b.Navigation("CuentasNavigation");
                });

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.TipoOperacion", b =>
                {
                    b.Navigation("OperacionesNavigation");
                });

            modelBuilder.Entity("Metafar.ATM.Challenge.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("CuentaPropietarioNavigation");

                    b.Navigation("CuentasActualizadasNavigation");

                    b.Navigation("OperacionesActualizadasNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
