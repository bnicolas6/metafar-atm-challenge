using Metafar.ATM.Challenge.Domain.Entities;
using Metafar.ATM.Challenge.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metafar.ATM.Challenge.Persistence.Configurations
{
    public class TipoOperacionConfiguration : IEntityTypeConfiguration<TipoOperacion>
    {
        public void Configure(EntityTypeBuilder<TipoOperacion> builder)
        {
            builder.HasKey(e => e.TipoOperacionId)
                .HasName("PK_TiposOperaciones");

            builder.ToTable(TipoOperacion.TABLE_NAME);

            builder.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

            builder.HasData(
                new TipoOperacion
                {
                    TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                    Descripcion = "Extraccion"
                },
                new TipoOperacion
                {
                    TipoOperacionId = (byte)ETipoOperacion.Deposito,
                    Descripcion = "Deposito"
                });
        }
    }
}
