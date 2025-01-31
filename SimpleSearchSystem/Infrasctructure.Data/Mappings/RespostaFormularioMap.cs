using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrasctructure.Data.Mappings
{
    public class RespostaFormularioMap : IEntityTypeConfiguration<RESPOSTA_FORMULARIO>
    {
        public void Configure(EntityTypeBuilder<RESPOSTA_FORMULARIO> builder)
        {
            builder.ToTable("resposta_formulario");

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id");

            builder.Property(e => e.FormularioId)
                  .HasColumnName("formulario_id");

            builder.Property(e => e.UsuarioId)
                  .HasColumnName("usuario_id");

            builder.Property(u => u.DtResposta)
                   .HasColumnName("data_resposta")
                   .HasColumnType("timestamp");

            builder.HasOne(f => f.FormularioNavigation)
                   .WithMany(f => f.RespostasFormularioNavigation)
                   .HasForeignKey(f => f.FormularioId);

            builder.HasOne(f => f.UsuarioNavigation)
                   .WithMany(f => f.RespostasFormularioNavigation)
                   .HasForeignKey(f => f.UsuarioId);
        }
    }
}
