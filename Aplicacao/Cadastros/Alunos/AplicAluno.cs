using Aplicacao.Base;
using Dominio.Cadastros.Alunos;
using Repositorio.Agendamentos.Agendamentos;
using Repositorio.Cadastros.Alunos;

namespace Aplicacao.Cadastros.Alunos
{
    public partial class AplicAluno(IRepAluno repAluno,
                                    IRepAgendamento repAgendamento) : AplicBase<Aluno>(repAluno), IAplicAluno
    {
        private readonly IRepAgendamento _repAgendamento = repAgendamento;
        public override Aluno? RecuperarPorId(int id)
        {
            var aluno = base.RecuperarPorId(id);
            ValidarAluno(aluno);
            return aluno;
        }

        public override void Inserir(Aluno aluno)
        {
            ValidarInserirAluno(aluno);
            base.Inserir(aluno);
        }
        public override void Alterar(int id, Aluno aluno)
        {
            ValidarAlterarAluno(aluno);
            base.Alterar(id, aluno);
        }

        public override void Remover(int id)
        {
            ValidarRemoverAluno(id);
            base.Remover(id);
        }
    }
}