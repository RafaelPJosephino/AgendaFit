using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Cadastros.Alunos.Dtos
{
    public class InserirAlunoDto
    {
        public string Nome { get; set; } = string.Empty;
        public EnumTipoPlano TipoPlano { get; set; }
    }
}
