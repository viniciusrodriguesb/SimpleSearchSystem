using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Mappings
{
    public class PerguntaMap : IEntityTypeConfiguration<PERGUNTA>
    {
        public void Configure(EntityTypeBuilder<PERGUNTA> builder)
        {
            builder.ToTable("pergunta");

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id");

            builder.Property(e => e.FormularioId)
                  .HasColumnName("formulario_id");

            builder.Property(u => u.TextoPergunta)
                   .HasColumnName("texto_pergunta")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(e => e.Ordem)
                   .HasColumnName("ordem");

            builder.HasOne(f => f.FormularioNavigation)
                   .WithMany(f => f.PerguntasNavigation)
                   .HasForeignKey(f => f.FormularioId);
        }
    }
}
