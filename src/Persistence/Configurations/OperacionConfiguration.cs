using Metafar.ATM.Challenge.Domain.Entities;
using Metafar.ATM.Challenge.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metafar.ATM.Challenge.Persistence.Configurations
{
    public class OperacionConfiguration : IEntityTypeConfiguration<Operacion>
    {
        public void Configure(EntityTypeBuilder<Operacion> builder)
        {
            builder.HasKey(e => e.OperacionId)
                .HasName("PK_Operaciones");

            builder.ToTable(Operacion.TABLE_NAME);

            builder.Property(e => e.Fecha)
                .HasColumnType("datetime");

            builder.Property(e => e.Monto)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ActualizadoEn)
                .HasColumnType("datetime");

            builder.HasOne(d => d.CuentaNavigation)
                .WithMany(p => p.OperacionesNavigation)
                .HasForeignKey(d => d.CuentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Operaciones_CuentaId_Cuentas");

            builder.HasOne(x => x.TipoOperacionNavigation)
                .WithMany(y => y.OperacionesNavigation)
                .HasForeignKey(x => x.TipoOperacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Operaciones_TipoOperacionId_TiposOperaciones");

            builder.HasOne(x => x.ActualizadoPorNavigation)
                .WithMany(y => y.OperacionesActualizadasNavigation)
                .HasForeignKey(x => x.ActualizadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Operaciones_ActualizadaPor_Usuarios");

            

            builder.HasData(
                new Operacion 
                { 
                    OperacionId = 1,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-25),
                    Monto = 100000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-25)
                }, //Harry - Depositos
                new Operacion
                {
                    OperacionId = 2,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-24),
                    Monto = 100000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-24)
                },
                new Operacion
                {
                    OperacionId = 3,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-23),
                    Monto = 150000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-23)
                },
                new Operacion
                {
                    OperacionId = 4,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-22),
                    Monto = 200000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-22)
                },
                new Operacion
                {
                    OperacionId = 5,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-21),
                    Monto = 900000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-21)
                },
                new Operacion
                {
                    OperacionId = 6,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-20),
                    Monto = 700000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-20)
                },
                new Operacion
                {
                    OperacionId = 7,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-19),
                    Monto = 1400000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-19)
                },
                new Operacion
                {
                    OperacionId = 8,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-18),
                    Monto = 200000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-18)
                },
                new Operacion
                {
                    OperacionId = 9,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-17),
                    Monto = 100000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-17)
                },
                new Operacion
                {
                    OperacionId = 10,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-16),
                    Monto = 2000000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-16)
                },
                new Operacion
                {
                    OperacionId = 11,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-15),
                    Monto = 400000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-15)
                }, //Harry - Extracciones
                new Operacion
                {
                    OperacionId = 12,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-14),
                    Monto = 175000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-14)
                },
                new Operacion
                {
                    OperacionId = 13,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-13),
                    Monto = 300000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-13)
                },
                new Operacion
                {
                    OperacionId = 14,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-12),
                    Monto = 920000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-12)
                },
                new Operacion
                {
                    OperacionId = 15,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-11),
                    Monto = 100000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-11)
                },
                new Operacion
                {
                    OperacionId = 16,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-10),
                    Monto = 75000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-10)
                },
                new Operacion
                {
                    OperacionId = 17,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-9),
                    Monto = 25000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-9)
                },
                new Operacion
                {
                    OperacionId = 18,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-8),
                    Monto = 650000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-8)
                },
                new Operacion
                {
                    OperacionId = 19,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-7),
                    Monto = 500000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-7)
                },
                new Operacion
                {
                    OperacionId = 20,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-6),
                    Monto = 10000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-6)
                },
                new Operacion
                {
                    OperacionId = 21,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-5),
                    Monto = 45000,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-5)
                },
                new Operacion
                {
                    OperacionId = 22,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-4),
                    Monto = 80500,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-4)
                },
                new Operacion
                {
                    OperacionId = 23,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-3),
                    Monto = 72500.25M,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-3)
                },
                new Operacion
                {
                    OperacionId = 24,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-2),
                    Monto = 15000.75M,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-2)
                },
                new Operacion
                {
                    OperacionId = 25,
                    CuentaId = 1,
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Fecha = DateTime.UtcNow.AddHours(-1),
                    Monto = 31999,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-1)
                },
                new Operacion
                {
                    OperacionId = 26,
                    CuentaId = 2,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-5),
                    Monto = 300000,
                    ActualizadoPor = 2,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-5)
                }, //Hermione - Depositos
                new Operacion
                {
                    OperacionId = 27,
                    CuentaId = 2,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-4),
                    Monto = 50000,
                    ActualizadoPor = 2,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-4)
                },
                new Operacion
                {
                    OperacionId = 28,
                    CuentaId = 2,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-3),
                    Monto = 100000,
                    ActualizadoPor = 2,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-3)
                },
                new Operacion
                {
                    OperacionId = 29,
                    CuentaId = 2,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-2),
                    Monto = 400000,
                    ActualizadoPor = 2,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-2)
                },
                new Operacion
                {
                    OperacionId = 30,
                    CuentaId = 2,
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Fecha = DateTime.UtcNow.AddHours(-1),
                    Monto = 150000,
                    ActualizadoPor = 2,
                    ActualizadoEn = DateTime.UtcNow.AddHours(-1)
                });
        }
    }
}