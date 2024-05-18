using Metafar.ATM.Challenge.Domain.Entities;
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
        }
    }
}
