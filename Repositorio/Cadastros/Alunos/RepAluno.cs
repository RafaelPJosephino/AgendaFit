using Dominio.Cadastros.Alunos;
using Repositorio.Base;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Cadastros.Alunos
{
    public class RepAluno(ContextoBanco contextoBanco )  :RepBase<Aluno>(contextoBanco), IRepAluno
    {
    }
}
