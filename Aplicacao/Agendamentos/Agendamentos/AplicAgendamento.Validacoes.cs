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
            var aluno = ValidarAlunoExistente(agendamento);
            var aula = ValidarAulaExistente(agendamento);
            ValidarInscricaoDoAluno(agendamento);
            ValidarLimitePaticipantesAula(aula);
            ValidarLimiteAulaAluno(aluno,aula);
        }

        private Aula ValidarAulaExistente(Agendamento agendamento)
        {
            var aula = _repAula.RecuperarPorIdObrigatorio(agendamento.CodigoAula);
            return aula!;

        }
        private Aluno ValidarAlunoExistente(Agendamento agendamento)
        {
            var aluno = _repAluno.RecuperarPorIdObrigatorio(agendamento.CodigoAluno);
            return aluno!;
        }
        
        private void ValidarInscricaoDoAluno(Agendamento agendamento)
        {
            var alunoInscricaoNaAula = _repositorio.Recuperar()
                        .Where(x => x.CodigoAula == agendamento.CodigoAula &&
                                    x.CodigoAluno == agendamento.CodigoAluno)
                        .Any();
            if(alunoInscricaoNaAula)
                throw new Exception($"O aluno já está agendado para esta aula.");
        }
        private void ValidarLimitePaticipantesAula(Aula aula)
        {
            int quantidadeDeAlunosAula = _repositorio.Recuperar()
                                                     .Where(x => x.CodigoAula == aula.Id)
                                                     .Count();


            if (aula!.QuantidadeParticipante == quantidadeDeAlunosAula)
                throw new Exception($"O limite de participantes para esta aula foi atingido. (Máx: {aula.QuantidadeParticipante})");
        }


        private void ValidarLimiteAulaAluno( Aluno aluno,Aula aula)
        {
            int quantidadeDeAulasMes = _repositorio.Recuperar().Where(x => x.CodigoAluno == aluno.Id &&
                                                               x.Aula.DataHora.Year == aula.DataHora.Year &&
                                                               x.Aula.DataHora.Month == aula.DataHora.Month)
                                                   .Count();

            switch (aluno.TipoPlano)
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
            }
        }
        private static void ValidaMensal(int quantidadeDeAulasMes)
        {
            if (quantidadeDeAulasMes >= 12) 
                throw new Exception("O limite de aulas permitidas para este mês foi atingido. (12 aulas)");
        }
        private static void ValidaTrimestral(int quantidadeDeAulasMes)
        {
            if (quantidadeDeAulasMes >= 20) 
                throw new Exception("O limite de aulas permitidas para este mês foi atingido. (20 aulas)");
        }
        private static void ValidaAnual(int quantidadeDeAulasMes)
        {
            if (quantidadeDeAulasMes >= 30)
                throw new Exception("O limite de aulas permitidas para este mês foi atingido. (30 aulas)");
        }
    }
}
