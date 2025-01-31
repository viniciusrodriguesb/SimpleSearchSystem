using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions<DbContextBase> options) : base(options) { }

        #region Modelos       
        public DbSet<FORMULARIO> FORMULARIO { get; set; }
        public DbSet<LOGIN> LOGIN { get; set; }
        public DbSet<OPCAO_PERGUNTA> OPCAO_PERGUNTA { get; set; }
        public DbSet<PERGUNTA> PERGUNTA { get; set; }
        public DbSet<RESPOSTA_FORMULARIO> RESPOSTA_FORMULARIO { get; set; }
        public DbSet<RESPOSTA_PERGUNTA> RESPOSTA_PERGUNTA { get; set; }
        public DbSet<USUARIO> USUARIO { get; set; }
        #endregion

        #region Mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AI");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextBase).Assembly);
        }
        #endregion
    }
}
