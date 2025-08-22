using Aplicacao.Cadastros.Alunos;
using Aplicacao.Cadastros.Aulas;
using Repositorio.Cadastros.Alunos;
using Repositorio.Cadastros.Aulas;
using Repositorio.Contexto;

namespace Mvc.Servicos
{
    public static class ConfigurarServicos
    {
        public static void Configure(IServiceCollection services)
        {
            // Contexto
            services.AddDbContext<ContextoBanco>();
            // Aplic
            services.AddScoped<IAplicAluno, AplicAluno>();
            services.AddScoped<IAplicAula, AplicAula>();

            // Rep
            services.AddScoped<IRepAluno, RepAluno>();
            services.AddScoped<IRepAula, RepAula>();
            
        }
    }
}