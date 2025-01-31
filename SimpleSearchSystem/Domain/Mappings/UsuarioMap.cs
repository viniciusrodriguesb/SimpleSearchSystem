using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<USUARIO>
    {
        public void Configure(EntityTypeBuilder<USUARIO> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id");

            builder.Property(u => u.Email)
                   .HasColumnName("email")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(e => e.Idade)
                   .HasColumnName("idade");

            builder.Property(u => u.Genero)
                   .HasColumnName("genero")
                   .HasColumnType("char(1)");

            builder.Property(u => u.DtCriacao)
                   .HasColumnName("criado")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
