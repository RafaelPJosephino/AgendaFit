using Aplicacao.Agendamentos.Agendamentos;
using Aplicacao.Cadastros.Alunos;
using Aplicacao.Cadastros.Aulas;
using Aplicacao.Relatorios.Alunos;
using Microsoft.EntityFrameworkCore;
using Repositorio.Agendamentos.Agendamentos;
using Repositorio.Cadastros.Alunos;
using Repositorio.Cadastros.Aulas;
using Repositorio.Contexto;

namespace Mvc.Servicos
{
    public static class ConfigurarServicos
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {

            // Contexto
            var teste = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ContextoBanco>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });

            // Mapper
            services.AddAutoMapper(typeof(MappingProfile));
            // Aplic
            services.AddScoped<IAplicAluno, AplicAluno>();
            services.AddScoped<IAplicAula, AplicAula>();
            services.AddScoped<IAplicAgendamento, AplicAgendamento>();
            services.AddScoped<IAplicRelAluno, AplicRelAluno>();
            

            // Rep
            services.AddScoped<IRepAluno, RepAluno>();
            services.AddScoped<IRepAula, RepAula>();
            services.AddScoped<IRepAgendamento, RepAgendamento>();

        }
    }
}