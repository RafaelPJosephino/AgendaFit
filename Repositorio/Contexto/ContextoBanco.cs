using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto
{
    public class ContextoBanco(DbContextOptions<ContextoBanco> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("agenda");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoBanco).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        

    }
}
