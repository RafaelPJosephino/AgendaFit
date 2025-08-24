using Dominio.Cadastros.Aulas;
using Dominio.Enums;
using Repositorio.Cadastros.Alunos;

namespace Aplicacao.Cadastros.Aulas
{
    public partial class AplicAula
    {
        private static void ValidarAula(Aula? aula)
        {
            if (aula == null) throw new Exception("Aula não encontrado");
        }
        private void ValidarAlterarAula(Aula? aula)
        {
            ValidarAula(aula);
            ValidarDataHoraAula(aula!);
            ValidarTipoAula(aula!);
            ValidarAlterarQuantidadeParticipanteAula(aula!);
        }
        private static void ValidarInserirAula(Aula? aula)
        {
            ValidarAula(aula);
            ValidarDataHoraAula(aula!);
            ValidarTipoAula(aula!);
            ValidarInserirQuantidadeParticipanteAula(aula!);
        }

        private static void ValidarDataHoraAula(Aula aula)
        {
            if (aula.DataHora <= DateTime.Now) 
                throw new Exception("A aula deve ser agendada para o futuro");
        }
        private static void ValidarTipoAula(Aula aula)
        {
            if (!Enum.IsDefined(typeof(EnumTipoAula), aula.TipoAula))
                throw new Exception("Tipo de aula inválida");
        }
        private static void ValidarInserirQuantidadeParticipanteAula(Aula aula)
        {
            if(aula.QuantidadeParticipante<0) 
                throw new Exception("A quantidade de participantes deve ser maior que 0");
        }
        private  void ValidarAlterarQuantidadeParticipanteAula(Aula aula)
        {
            if (aula.QuantidadeParticipante < 0) 
                throw new Exception("A quantidade de participantes deve ser maior que 0");


            int quantidadeDeAlunosAula = _repAgendamento.Recuperar()
                                                        .Where(x => x.CodigoAula == aula.Id)
                                                        .Count();

            if (aula.QuantidadeParticipante < quantidadeDeAlunosAula)
                throw new Exception("A quantidade máxima de participantes não pode ser menor que o número de alunos já agendados.");
        }
        
    }
}
