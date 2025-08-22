using Dominio.Cadastros.Alunos;
using Dominio.Cadastros.Aulas;
using Repositorio.Base;
using Repositorio.Cadastros.Alunos;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Cadastros.Aulas
{
    public class RepAula(ContextoBanco contextoBanco) : RepBase<Aula>(contextoBanco), IRepAula
    {
    }
}
