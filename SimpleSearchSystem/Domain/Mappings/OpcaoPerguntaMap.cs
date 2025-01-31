using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Mappings
{
    public class OpcaoPerguntaMap : IEntityTypeConfiguration<OPCAO_PERGUNTA>
    {
        public void Configure(EntityTypeBuilder<OPCAO_PERGUNTA> builder)
        {
            builder.ToTable("opcao_pergunta");

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id");

            builder.Property(e => e.PerguntaId)
                  .HasColumnName("pergunta_id");

            builder.Property(u => u.Texto)
                   .HasColumnName("texto")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(e => e.Ordem)
                   .HasColumnName("ordem");

            builder.HasOne(f => f.PerguntaNavigation)
                   .WithMany(f => f.OpcoesPerguntaNavigation)
                   .HasForeignKey(f => f.PerguntaId);
        }
    }
}
