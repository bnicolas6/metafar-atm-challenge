using Metafar.ATM.Challenge.Domain.Entities;
using Metafar.ATM.Challenge.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metafar.ATM.Challenge.Persistence.Configurations
{
    public class EstadoTarjetaConfiguration : IEntityTypeConfiguration<EstadoTarjeta>
    {
        public void Configure(EntityTypeBuilder<EstadoTarjeta> builder)
        {
            builder.HasKey(e => e.EstadoTarjetaId)
                .HasName("PK_EstadosTarjetas");

            builder.ToTable(EstadoTarjeta.TABLE_NAME);

            builder.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

            builder.HasData(
                new EstadoTarjeta 
                { 
                    EstadoTarjetaId = (byte)EEstadoTarjeta.Activo,
                    Descripcion = "Activo"
                }, 
                new EstadoTarjeta 
                {
                    EstadoTarjetaId = (byte)EEstadoTarjeta.Bloqueado,
                    Descripcion = "Bloqueado"
                });
        }
    }
}
