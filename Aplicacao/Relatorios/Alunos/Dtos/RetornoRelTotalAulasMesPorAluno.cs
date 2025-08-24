using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Relatorios.Alunos.Dtos
{
    public class RetornoRelTotalAulasMesPorAluno
    {
        public List<RetornoRelTotalAulasMesPorAlunoAluno> Alunos { get; set; } = new List<RetornoRelTotalAulasMesPorAlunoAluno>();

    }

    public class RetornoRelTotalAulasMesPorAlunoAluno
    {
        public string Nome  { get; set; } = string.Empty;
        public List<RetornoRelTotalAulasMesPorAlunoAgendamento> Agendamentos { get; set; } = new List<RetornoRelTotalAulasMesPorAlunoAgendamento>();

    }
    public class RetornoRelTotalAulasMesPorAlunoAgendamento
    {
        public string DescricaoMes { get; set; } = string.Empty;
        public int TotalAulas { get; set; }

    }
}
