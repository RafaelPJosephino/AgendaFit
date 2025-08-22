using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto
{
    public class ContextoBanco(DbContextOptions<ContextoBanco> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql("teste");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoBanco).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
