using Aplicacao.Base;
using Dominio.Cadastros.Alunos;
using Repositorio.Cadastros.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Cadastros.Alunos
{
    public partial class AplicAluno(IRepAluno repAluno ): AplicBase<Aluno>(repAluno), IAplicAluno 
    {

    }
}
