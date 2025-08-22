using Aplicacao.Base;
using Aplicacao.Cadastros.Alunos;
using Aplicacao.Cadastros.Aulas;
using Dominio.Agendamentos;
using Repositorio.Agendamentos.Agendamentos;
using Repositorio.Cadastros.Alunos;
using Repositorio.Cadastros.Aulas;

namespace Aplicacao.Agendamentos.Agendamentos
{
    public partial class AplicAgendamento(IRepAgendamento repAgendamento,
                                          IRepAluno repAluno,
                                          IRepAula repAula,
                                          IAplicAluno aplicAluno,
                                          IAplicAula aplicAula) : AplicBase<Agendamento>(repAgendamento), IAplicAgendamento
    {
        private readonly  IRepAluno _repAluno = repAluno;
        private readonly IRepAula _repAula = repAula;
        private readonly IAplicAluno _aplicAluno = aplicAluno;
        private readonly IAplicAula _aplicAula = aplicAula;

    }
}
