using Metafar.ATM.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metafar.ATM.Challenge.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.UsuarioId)
                .HasName("PK_Usuarios");

            builder.ToTable(Usuario.TABLE_NAME);

            builder.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
        }
    }
}
