using Dominio.Base;
using Dominio.Enums;
using System.ComponentModel;
using System.Diagnostics.Tracing;

namespace Dominio.Cadastros.Alunos
{
    public class Aluno: Identificador
    {
        public string Nome { get; set; } = string.Empty;
        public EnumTipoPlano TipoPlano { get; set; }
    }
}
