using Dominio.Base;
using Dominio.Cadastros.Alunos;
using Dominio.Cadastros.Aulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Agendamentos
{
    public class Agendamento : Identificador
    { 
        public int CodigoAluno {  get; set; }
        public required virtual Aluno Aluno { get; set; }
        public int CodigoAula { get; set; }
        public required virtual Aula Aula { get; set; }


    }
}
