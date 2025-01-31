using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrasctructure.Data.Mappings
{
    public class FormularioMap : IEntityTypeConfiguration<FORMULARIO>
    {
        public void Configure(EntityTypeBuilder<FORMULARIO> builder)
        {
            builder.ToTable("formulario");

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id");

            builder.Property(e => e.IdUsuario)
                  .HasColumnName("id_usuario");

            builder.Property(e => e.Descricao)
                  .HasColumnName("descricao");

            builder.Property(u => u.DtCriacao)
                  .HasColumnName("criado")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.IcAtivo)
                 .HasColumnName("ativo");

            builder.HasOne(f => f.UsuarioNavigation)
              .WithMany(u => u.FormulariosNavigation)
              .HasForeignKey(f => f.IdUsuario)
              .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
