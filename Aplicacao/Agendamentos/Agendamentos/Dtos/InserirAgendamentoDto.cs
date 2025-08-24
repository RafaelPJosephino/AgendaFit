using Dominio.Cadastros.Alunos;
using Dominio.Cadastros.Aulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Agendamentos.Agendamentos.Dtos
{
    public class InserirAgendamentoDto
    {
        public int CodigoAluno { get; set; }
        public int CodigoAula { get; set; }
    }
}
