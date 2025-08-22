using Dominio.Agendamentos;
using Dominio.Cadastros.Alunos;
using Dominio.Cadastros.Aulas;
using Dominio.Enums;

namespace Aplicacao.Agendamentos.Agendamentos
{
    public partial class AplicAgendamento
    {
        public void ValidaInserirAgendamento(Agendamento agendamento)
        {
            ValidaeLimitePaticipantesAula(agendamento);
            ValidarLimiteAulaAluno(agendamento);
        }
        private void ValidaeLimitePaticipantesAula(Agendamento agendamento)
        {
            Aula? aula = _repAula.RecuperarPorId(agendamento.CodigoAula);
            _aplicAula.ValidarAula(aula);
            int quantidadeDeAlunosAula = _repositorio.Recuperar()
                                                   .Where(x => x.CodigoAula == aula!.Id)
                                                   .Count();
            if (aula!.QuantidadeParticipante == quantidadeDeAlunosAula) throw new Exception($"O limite de participantes para esta aula foi atingido. (Máx: {aula.QuantidadeParticipante})");
        }
        private void ValidarLimiteAulaAluno(Agendamento agendamento)
        {
            Aluno? aluno = _repAluno.RecuperarPorId(agendamento.CodigoAluno);
            _aplicAluno.ValidarAluno(aluno);
            int quantidadeDeAulasMes = _repositorio.Recuperar()
                                                   .Where(x => x.CodigoAluno == aluno!.Id)
                                                   .Where(x => x.Aula.DataHora.Year == DateTime.Today.Year)
                                                   .Where(x => x.Aula.DataHora.Month == DateTime.Today.Month)
                                                   .Count();

            switch (aluno!.TipoPlano)
            {
                case EnumTipoPlano.Mensal:
                    ValidaMensal(quantidadeDeAulasMes);
                    break;
                case EnumTipoPlano.Trimestral:
                    ValidaTrimestral(quantidadeDeAulasMes);
                    break;
                case EnumTipoPlano.Anual:
                    ValidaAnual(quantidadeDeAulasMes);
                    break;
                default:
                    break;
            }
        }
        private static void ValidaMensal(int quantidadeDeAulasMes)
        {
            if (quantidadeDeAulasMes > 12) throw new Exception("O limite de aulas permitidas para este mês foi atingido. (12 aulas)");
        }
        private static void ValidaTrimestral(int quantidadeDeAulasMes)
        {
            if (quantidadeDeAulasMes > 20) throw new Exception("O limite de aulas permitidas para este mês foi atingido. (20 aulas)");
        }
        private static void ValidaAnual(int quantidadeDeAulasMes)
        {
            if (quantidadeDeAulasMes > 30) throw new Exception("O limite de aulas permitidas para este mês foi atingido. (30 aulas)");
        }
    }
}
