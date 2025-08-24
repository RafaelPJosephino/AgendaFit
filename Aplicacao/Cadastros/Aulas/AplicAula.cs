using Aplicacao.Agendamentos.Agendamentos;
using Aplicacao.Base;
using Dominio.Agendamentos;
using Dominio.Cadastros.Alunos;
using Dominio.Cadastros.Aulas;
using Repositorio.Agendamentos.Agendamentos;
using Repositorio.Cadastros.Alunos;
using Repositorio.Cadastros.Aulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Cadastros.Aulas
{
    public partial class AplicAula(IRepAula repAula,IRepAgendamento repAgendamento) : AplicBase<Aula>(repAula), IAplicAula
    {
        private readonly IRepAgendamento _repAgendamento = repAgendamento;
        
        public override void Inserir(Aula aula)
        {
            ValidarInserirAula(aula);
            base.Inserir(aula);
        }
        public override void Alterar(int id, Aula aulaNova)
        {
            ValidarAlterarAula(aulaNova);
            base.Alterar(id, aulaNova);
        }
        public override void Remover(int id)
        {
            DesmarcarAgendamentoAula(id);
            base.Remover(id);
        }

        private void DesmarcarAgendamentoAula(int idAula)
        {
            var listaAgendamento = _repAgendamento.Recuperar()
                                                  .Where(x => x.CodigoAula == idAula)
                                                  .ToList();

            _repAgendamento.RemoverLista(listaAgendamento);
        }

        

    }
}
