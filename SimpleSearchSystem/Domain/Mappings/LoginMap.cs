using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Mappings
{
    public class LoginMap : IEntityTypeConfiguration<LOGIN>
    {
        public void Configure(EntityTypeBuilder<LOGIN> builder)
        {
            builder.ToTable("login");

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id");

            builder.Property(e => e.IdUsuario)
                  .HasColumnName("id_usuario");

            builder.Property(u => u.Senha)
                   .HasColumnName("senha")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasOne(f => f.UsuarioNavigation)
                   .WithOne(f => f.LoginNavigation)
                   .HasForeignKey<LOGIN>(f => f.IdUsuario);
        }
    }
}
