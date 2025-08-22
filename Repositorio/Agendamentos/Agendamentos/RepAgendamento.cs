using Dominio.Agendamentos;
using Dominio.Cadastros.Alunos;
using Repositorio.Base;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Agendamentos.Agendamentos
{
    public class RepAgendamento(ContextoBanco contextoBanco) : RepBase<Agendamento>(contextoBanco),IRepAgendamento
    {

    }
}
