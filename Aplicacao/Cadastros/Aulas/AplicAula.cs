using Aplicacao.Base;
using Dominio.Cadastros.Alunos;
using Dominio.Cadastros.Aulas;
using Repositorio.Cadastros.Alunos;
using Repositorio.Cadastros.Aulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Cadastros.Aulas
{
    public partial class AplicAula(IRepAula repAula) : AplicBase<Aula>(repAula), IAplicAula
    {

    }
}
