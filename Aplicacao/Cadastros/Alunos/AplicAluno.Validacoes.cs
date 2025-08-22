using Dominio.Agendamentos;
using Dominio.Cadastros.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Cadastros.Alunos
{
    public partial class AplicAluno
    {
        public void ValidarAluno(Aluno? aluno)
        {
            if (aluno != null) throw new Exception("Aluno não encontrado");
        }
    }
}
