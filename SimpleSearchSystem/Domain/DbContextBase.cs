using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions<DbContextBase> options) : base(options) { }

        #region Modelos       
        //public DbSet<TB001_USUARIO> TB001_USUARIO { get; set; }
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
