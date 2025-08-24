using Aplicacao.Relatorios.Alunos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Relatorios.Alunos
{
    public interface IAplicRelAluno
    {
        RetornoRelTiposAulaPorAluno EmitirRelTiposAulaPorAluno(int id);
        RetornoRelTiposAulaPorAluno EmitirRelTiposAulaPorAluno();
        RetornoRelTotalAulasMesPorAluno EmitirRelTotalAulasMesPorAluno();
        RetornoRelTotalAulasMesPorAluno EmitirRelTotalAulasMesPorAluno(int id);
    }
}
