﻿// <auto-generated />
using System;
using Metafar.ATM.Challenge.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Metafar.ATM.Challenge.Persistence.Migrations
{
    [DbContext(typeof(ATMDbContext))]
    partial class ATMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("NumeroDeCuenta")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("char(10)");

                    b.Property<string>("NumeroDeTarjeta")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("char(16)");

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

                    b.HasIndex("NumeroDeCuenta")
                        .IsUnique();

                    b.HasIndex("NumeroDeTarjeta")
                        .IsUnique();

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Cuentas", (string)null);

                    b.HasData(
                        new
                        {
                            CuentaId = 1,
                            ActualizadoEn = new DateTime(2024, 5, 20, 0, 56, 41, 191, DateTimeKind.Utc).AddTicks(1344),
                            ActualizadoPor = 1,
                            EstadoTarjetaId = (byte)1,
                            NumeroDeCuenta = "1111111111",
                            NumeroDeTarjeta = "1122334455667788",
                            Pin = "1234",
                            Saldo = 3400000m,
                            UsuarioId = 1
                        },
                        new
                        {
                            CuentaId = 2,
                            ActualizadoEn = new DateTime(2024, 5, 20, 0, 56, 41, 191, DateTimeKind.Utc).AddTicks(1347),
                            ActualizadoPor = 2,
                            EstadoTarjetaId = (byte)2,
                            NumeroDeCuenta = "2222222222",
                            NumeroDeTarjeta = "8877665544332211",
                            Pin = "4321",
                            Saldo = 925040.50m,
                            UsuarioId = 2
                        },
                        new
                        {
                            CuentaId = 3,
                            ActualizadoEn = new DateTime(2024, 5, 20, 0, 56, 41, 191, DateTimeKind.Utc).AddTicks(1349),
                            ActualizadoPor = 3,
                            EstadoTarjetaId = (byte)1,
                            NumeroDeCuenta = "3333333333",
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

                    b.HasData(
                        new
                        {
                            OperacionId = 1,
                            ActualizadoEn = new DateTime(2024, 5, 18, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3906),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 18, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3902),
                            Monto = 100000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 2,
                            ActualizadoEn = new DateTime(2024, 5, 19, 0, 56, 41, 191, DateTimeKind.Utc).AddTicks(3908),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 0, 56, 41, 191, DateTimeKind.Utc).AddTicks(3908),
                            Monto = 100000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 3,
                            ActualizadoEn = new DateTime(2024, 5, 19, 1, 56, 41, 191, DateTimeKind.Utc).AddTicks(3910),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 1, 56, 41, 191, DateTimeKind.Utc).AddTicks(3909),
                            Monto = 150000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 4,
                            ActualizadoEn = new DateTime(2024, 5, 19, 2, 56, 41, 191, DateTimeKind.Utc).AddTicks(3911),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 2, 56, 41, 191, DateTimeKind.Utc).AddTicks(3910),
                            Monto = 200000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 5,
                            ActualizadoEn = new DateTime(2024, 5, 19, 3, 56, 41, 191, DateTimeKind.Utc).AddTicks(3912),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 3, 56, 41, 191, DateTimeKind.Utc).AddTicks(3912),
                            Monto = 900000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 6,
                            ActualizadoEn = new DateTime(2024, 5, 19, 4, 56, 41, 191, DateTimeKind.Utc).AddTicks(3914),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 4, 56, 41, 191, DateTimeKind.Utc).AddTicks(3913),
                            Monto = 700000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 7,
                            ActualizadoEn = new DateTime(2024, 5, 19, 5, 56, 41, 191, DateTimeKind.Utc).AddTicks(3915),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 5, 56, 41, 191, DateTimeKind.Utc).AddTicks(3915),
                            Monto = 1400000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 8,
                            ActualizadoEn = new DateTime(2024, 5, 19, 6, 56, 41, 191, DateTimeKind.Utc).AddTicks(3916),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 6, 56, 41, 191, DateTimeKind.Utc).AddTicks(3916),
                            Monto = 200000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 9,
                            ActualizadoEn = new DateTime(2024, 5, 19, 7, 56, 41, 191, DateTimeKind.Utc).AddTicks(3917),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 7, 56, 41, 191, DateTimeKind.Utc).AddTicks(3917),
                            Monto = 100000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 10,
                            ActualizadoEn = new DateTime(2024, 5, 19, 8, 56, 41, 191, DateTimeKind.Utc).AddTicks(3919),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 8, 56, 41, 191, DateTimeKind.Utc).AddTicks(3918),
                            Monto = 2000000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 11,
                            ActualizadoEn = new DateTime(2024, 5, 19, 9, 56, 41, 191, DateTimeKind.Utc).AddTicks(3920),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 9, 56, 41, 191, DateTimeKind.Utc).AddTicks(3919),
                            Monto = 400000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 12,
                            ActualizadoEn = new DateTime(2024, 5, 19, 10, 56, 41, 191, DateTimeKind.Utc).AddTicks(3921),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 10, 56, 41, 191, DateTimeKind.Utc).AddTicks(3921),
                            Monto = 175000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 13,
                            ActualizadoEn = new DateTime(2024, 5, 19, 11, 56, 41, 191, DateTimeKind.Utc).AddTicks(3922),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 11, 56, 41, 191, DateTimeKind.Utc).AddTicks(3922),
                            Monto = 300000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 14,
                            ActualizadoEn = new DateTime(2024, 5, 19, 12, 56, 41, 191, DateTimeKind.Utc).AddTicks(3924),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 12, 56, 41, 191, DateTimeKind.Utc).AddTicks(3923),
                            Monto = 920000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 15,
                            ActualizadoEn = new DateTime(2024, 5, 19, 13, 56, 41, 191, DateTimeKind.Utc).AddTicks(3925),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 13, 56, 41, 191, DateTimeKind.Utc).AddTicks(3924),
                            Monto = 100000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 16,
                            ActualizadoEn = new DateTime(2024, 5, 19, 14, 56, 41, 191, DateTimeKind.Utc).AddTicks(3926),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 14, 56, 41, 191, DateTimeKind.Utc).AddTicks(3926),
                            Monto = 75000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 17,
                            ActualizadoEn = new DateTime(2024, 5, 19, 15, 56, 41, 191, DateTimeKind.Utc).AddTicks(3927),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 15, 56, 41, 191, DateTimeKind.Utc).AddTicks(3927),
                            Monto = 25000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 18,
                            ActualizadoEn = new DateTime(2024, 5, 19, 16, 56, 41, 191, DateTimeKind.Utc).AddTicks(3929),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 16, 56, 41, 191, DateTimeKind.Utc).AddTicks(3928),
                            Monto = 650000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 19,
                            ActualizadoEn = new DateTime(2024, 5, 19, 17, 56, 41, 191, DateTimeKind.Utc).AddTicks(3930),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 17, 56, 41, 191, DateTimeKind.Utc).AddTicks(3929),
                            Monto = 500000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 20,
                            ActualizadoEn = new DateTime(2024, 5, 19, 18, 56, 41, 191, DateTimeKind.Utc).AddTicks(3931),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 18, 56, 41, 191, DateTimeKind.Utc).AddTicks(3930),
                            Monto = 10000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 21,
                            ActualizadoEn = new DateTime(2024, 5, 19, 19, 56, 41, 191, DateTimeKind.Utc).AddTicks(3932),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 19, 56, 41, 191, DateTimeKind.Utc).AddTicks(3932),
                            Monto = 45000m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 22,
                            ActualizadoEn = new DateTime(2024, 5, 19, 20, 56, 41, 191, DateTimeKind.Utc).AddTicks(3933),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 20, 56, 41, 191, DateTimeKind.Utc).AddTicks(3933),
                            Monto = 80500m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 23,
                            ActualizadoEn = new DateTime(2024, 5, 19, 21, 56, 41, 191, DateTimeKind.Utc).AddTicks(3935),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 21, 56, 41, 191, DateTimeKind.Utc).AddTicks(3934),
                            Monto = 72500.25m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 24,
                            ActualizadoEn = new DateTime(2024, 5, 19, 22, 56, 41, 191, DateTimeKind.Utc).AddTicks(3936),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 22, 56, 41, 191, DateTimeKind.Utc).AddTicks(3936),
                            Monto = 15000.75m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 25,
                            ActualizadoEn = new DateTime(2024, 5, 19, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3937),
                            ActualizadoPor = 1,
                            CuentaId = 1,
                            Fecha = new DateTime(2024, 5, 19, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3937),
                            Monto = 31999m,
                            TipoOperacionId = (byte)1
                        },
                        new
                        {
                            OperacionId = 26,
                            ActualizadoEn = new DateTime(2024, 5, 19, 19, 56, 41, 191, DateTimeKind.Utc).AddTicks(3939),
                            ActualizadoPor = 2,
                            CuentaId = 2,
                            Fecha = new DateTime(2024, 5, 19, 19, 56, 41, 191, DateTimeKind.Utc).AddTicks(3938),
                            Monto = 300000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 27,
                            ActualizadoEn = new DateTime(2024, 5, 19, 20, 56, 41, 191, DateTimeKind.Utc).AddTicks(3940),
                            ActualizadoPor = 2,
                            CuentaId = 2,
                            Fecha = new DateTime(2024, 5, 19, 20, 56, 41, 191, DateTimeKind.Utc).AddTicks(3939),
                            Monto = 50000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 28,
                            ActualizadoEn = new DateTime(2024, 5, 19, 21, 56, 41, 191, DateTimeKind.Utc).AddTicks(3941),
                            ActualizadoPor = 2,
                            CuentaId = 2,
                            Fecha = new DateTime(2024, 5, 19, 21, 56, 41, 191, DateTimeKind.Utc).AddTicks(3940),
                            Monto = 100000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 29,
                            ActualizadoEn = new DateTime(2024, 5, 19, 22, 56, 41, 191, DateTimeKind.Utc).AddTicks(3942),
                            ActualizadoPor = 2,
                            CuentaId = 2,
                            Fecha = new DateTime(2024, 5, 19, 22, 56, 41, 191, DateTimeKind.Utc).AddTicks(3942),
                            Monto = 400000m,
                            TipoOperacionId = (byte)2
                        },
                        new
                        {
                            OperacionId = 30,
                            ActualizadoEn = new DateTime(2024, 5, 19, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3943),
                            ActualizadoPor = 2,
                            CuentaId = 2,
                            Fecha = new DateTime(2024, 5, 19, 23, 56, 41, 191, DateTimeKind.Utc).AddTicks(3943),
                            Monto = 150000m,
                            TipoOperacionId = (byte)2
                        });
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

                    b.HasData(
                        new
                        {
                            TipoOperacionId = (byte)1,
                            Descripcion = "Extraccion"
                        },
                        new
                        {
                            TipoOperacionId = (byte)2,
                            Descripcion = "Deposito"
                        });
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
