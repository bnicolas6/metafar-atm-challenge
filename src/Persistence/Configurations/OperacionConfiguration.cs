using Metafar.ATM.Challenge.Domain.Entities;
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
        }
    }
}
