using Aplicacao.Agendamentos.Agendamentos.Dtos;
using Aplicacao.Cadastros.Alunos.Dtos;
using Aplicacao.Cadastros.Aulas.Dtos;
using AutoMapper;
using Dominio.Agendamentos;
using Dominio.Cadastros.Alunos;
using Dominio.Cadastros.Aulas;

namespace Mvc.Servicos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Aluno
            CreateMap<InserirAlunoDto, Aluno>().ReverseMap();
            CreateMap<EditarAlunoDto, Aluno>().ReverseMap();
            // Aula
            CreateMap<InserirAulaDto, Aula>().ReverseMap();
            CreateMap<EditarAulaDto, Aula>().ReverseMap();
            // Agendamento
            CreateMap<InserirAgendamentoDto, Agendamento>().ReverseMap();
        }
    }
}
