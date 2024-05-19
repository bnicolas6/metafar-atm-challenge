using Metafar.ATM.Challenge.Domain.Entities;
using Metafar.ATM.Challenge.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metafar.ATM.Challenge.Persistence.Configurations
{
    public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasKey(e => e.CuentaId)
                .HasName("PK_Cuentas");

            builder.ToTable(Cuenta.TABLE_NAME);

            builder.Property(e => e.Saldo)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.NumeroDeTarjeta)
                .IsRequired()
                .HasColumnType("varchar(16)")
                .HasMaxLength(16);

            builder.Property(e => e.Pin)
                .IsRequired()
                .HasColumnType("char(4)")
                .HasMaxLength(4);

            builder.Property(e => e.ActualizadoEn)
                .HasColumnType("datetime");

            builder.HasOne(x => x.EstadoTarjetaNavigation)
                .WithMany(y => y.CuentasNavigation)
                .HasForeignKey(x => x.EstadoTarjetaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuentas_EstadoTarjetaId_EstadosTarjetas");

            builder.HasOne(x => x.UsuarioNavigation)
                .WithOne(y => y.CuentaPropietarioNavigation)
                .HasForeignKey<Cuenta>(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuentas_UsuarioId_Usuarios");

            builder.HasOne(x => x.ActualizadoPorNavigation)
                .WithMany(y => y.CuentasActualizadasNavigation)
                .HasForeignKey(x => x.ActualizadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuentas_ActualizadoPor_Usuarios");

            builder.HasIndex(c => c.NumeroDeTarjeta)
                .IsUnique();

            builder.HasData(
                new Cuenta
                {
                    CuentaId = 1,
                    UsuarioId = 1,
                    Saldo = 1400500.25M,
                    NumeroDeTarjeta = "1122334455667788",
                    Pin = "1234",
                    EstadoTarjetaId = (byte)EEstadoTarjeta.Activo,
                    ActualizadoPor = 1,
                    ActualizadoEn = DateTime.UtcNow
                },
                new Cuenta
                {
                    CuentaId = 2,
                    UsuarioId = 2,
                    Saldo = 925040.50M,
                    NumeroDeTarjeta = "8877665544332211",
                    Pin = "4321",
                    EstadoTarjetaId = (byte)EEstadoTarjeta.Activo,
                    ActualizadoPor = 2,
                    ActualizadoEn = DateTime.UtcNow
                },
                new Cuenta
                {
                    CuentaId = 3,
                    UsuarioId = 3,
                    Saldo = 125475.25M,
                    NumeroDeTarjeta = "9955660044773311",
                    Pin = "1111",
                    EstadoTarjetaId = (byte)EEstadoTarjeta.Activo,
                    ActualizadoPor = 3,
                    ActualizadoEn = DateTime.UtcNow
                });
        }
    }
}