using Metafar.ATM.Challenge.Domain.Entities;
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
        }
    }
}
