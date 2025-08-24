using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Relatorios.Alunos.Dtos
{
    public class RetornoRelTiposAulaPorAluno
    {
        public List<RetornoRelTiposAulaPorAlunoAluno> Alunos { get; set; } = new List<RetornoRelTiposAulaPorAlunoAluno>();
    }
    public class RetornoRelTiposAulaPorAlunoAluno
    {
        public string Nome  { get; set; } = string.Empty;
        public List<RetornoRelTiposAulaPorAlunoAulas> Aulas { get; set; } = new List<RetornoRelTiposAulaPorAlunoAulas>();
    }

    public class RetornoRelTiposAulaPorAlunoAulas 
    {
        public EnumTipoAula TipoAula { get; set; }
        public string DescricaoTipoAula { get; set; } = string.Empty;
        public int TotalAulas { get; set; }
    }
}
