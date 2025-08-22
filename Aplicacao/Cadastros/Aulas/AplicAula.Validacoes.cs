using Dominio.Cadastros.Alunos;
using Dominio.Cadastros.Aulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Cadastros.Aulas
{
    public partial class AplicAula
    {
        public void ValidarAula(Aula? aula)
        {
            if (aula != null) throw new Exception("Aula não encontrado");
        }
    }
}
