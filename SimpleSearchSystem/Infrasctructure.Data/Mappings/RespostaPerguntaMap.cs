using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrasctructure.Data.Mappings
{
    public class RespostaPerguntaMap : IEntityTypeConfiguration<RESPOSTA_PERGUNTA>
    {
        public void Configure(EntityTypeBuilder<RESPOSTA_PERGUNTA> builder)
        {
            builder.ToTable("resposta_pergunta");

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id");

            builder.Property(e => e.RespostaFormularioId)
                  .HasColumnName("formulario_id");

            builder.Property(e => e.PerguntaId)
                  .HasColumnName("pergunta_id");

            builder.Property(e => e.OpcaoId)
                 .HasColumnName("opcao_id");

            builder.HasOne(r => r.RespostaFormularioNavigation)
                   .WithMany()
                   .HasForeignKey(r => r.RespostaFormularioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.PerguntaNavigation)
                   .WithMany()
                   .HasForeignKey(r => r.PerguntaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.OpcaoPerguntaNavigation)
                   .WithMany()
                   .HasForeignKey(r => r.OpcaoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
