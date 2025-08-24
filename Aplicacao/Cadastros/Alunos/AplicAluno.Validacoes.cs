using Dominio.Cadastros.Alunos;
using Dominio.Enums;

namespace Aplicacao.Cadastros.Alunos
{
    public partial class AplicAluno
    {

        private void ValidarRemoverAluno(int idAluno)
        {
            ValidarAulasPendentesAluno(idAluno);

        }
        private static void ValidarAlterarAluno(Aluno? aluno)
        {
            ValidarAluno(aluno);
            ValidarNomeAluno(aluno!);
            ValidarTipoPlanoAluno(aluno!);
        }
        private static void ValidarInserirAluno(Aluno? aluno)
        {
            ValidarAluno(aluno);
            ValidarNomeAluno(aluno!);
            ValidarTipoPlanoAluno(aluno!);
        }
        private static void ValidarAluno(Aluno? aluno)
        {
            if (aluno == null)
                throw new Exception("Aluno não encontrado");
        }
        private void ValidarAulasPendentesAluno(int idAluno)
        {
            var aulasPendentes = _repAgendamento.Recuperar()
                                                .Where(x => x.CodigoAluno == idAluno &&
                                                            x.Aula.DataHora >= DateTime.UtcNow)
                                                .Count();
            if (aulasPendentes > 0)
                throw new Exception($"O aluno possui {aulasPendentes} aulas pendentes. Para remover, desmarque essas aulas antes.");
        }
        private static void ValidarNomeAluno(Aluno aluno)
        {
            if (string.IsNullOrEmpty(aluno?.Nome))
                throw new Exception("Nome do aluno inválido");
        }
        private static void ValidarTipoPlanoAluno(Aluno aluno)
        {
            if (!Enum.IsDefined(typeof(EnumTipoPlano), aluno.TipoPlano))
                throw new Exception("Tipo de plano inválido");
        }
    }
}
