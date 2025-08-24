using Aplicacao.Relatorios.Alunos.Dtos;
using Repositorio.Agendamentos.Agendamentos;
using Repositorio.Cadastros.Alunos;

namespace Aplicacao.Relatorios.Alunos
{
    public class AplicRelAluno(IRepAluno repAluno,
                                 IRepAgendamento repAgendamento) : IAplicRelAluno
    {
        private readonly IRepAluno _repAluno = repAluno;
        private readonly IRepAgendamento _repAgendamento = repAgendamento;


        public RetornoRelTotalAulasMesPorAluno EmitirRelTotalAulasMesPorAluno()
        {
            var agendamentos = _repAgendamento.Recuperar();
            var retorno = new RetornoRelTotalAulasMesPorAluno();
            var alunos = _repAluno.Recuperar().ToList();

            foreach (var aluno in alunos)
            {
                var agendamentosAluno = agendamentos
                    .Where(a => a.CodigoAluno == aluno.Id)
                    .Select(a => new { a.Aula.DataHora })
                    .GroupBy(a => new { a.DataHora.Year, a.DataHora.Month })
                    .Select(g => new { Mes = g.Key.Month, Ano = g.Key.Year, TotalAulas = g.Count() })
                    .OrderBy(m => m.Mes)
                    .ToList()
                    .Select(x => new RetornoRelTotalAulasMesPorAlunoAgendamento
                    {
                        DescricaoMes = x.Mes.ToString("D2") + "/" + x.Ano,
                        TotalAulas = x.TotalAulas
                    })
                    .ToList();

                retorno.Alunos.Add(new RetornoRelTotalAulasMesPorAlunoAluno
                {
                    Nome = aluno.Nome,
                    Agendamentos = agendamentosAluno
                });
            }

            return retorno;
        }
        public RetornoRelTotalAulasMesPorAluno EmitirRelTotalAulasMesPorAluno(int id)
        {
            var aluno = _repAluno.RecuperarPorIdObrigatorio(id);
            var agendamentos = _repAgendamento.Recuperar();
            var retorno = new RetornoRelTotalAulasMesPorAluno();

            retorno.Alunos.Add(new RetornoRelTotalAulasMesPorAlunoAluno
            {
                Nome = aluno.Nome,
                Agendamentos = agendamentos
                        .Where(a => a.CodigoAluno == aluno.Id)
                        .GroupBy(a => new { a.Aula.DataHora.Year, a.Aula.DataHora.Month })
                        .Select(g => new { Mes = g.Key.Month, Ano = g.Key.Year, TotalAulas = g.Count() })
                        .OrderBy(m => m.Mes)
                        .ToList()
                        .Select(x => new RetornoRelTotalAulasMesPorAlunoAgendamento
                        {
                            DescricaoMes = x.Mes.ToString("D2") + "/" + x.Ano,
                            TotalAulas = x.TotalAulas
                        })
                        .ToList()
            });

            return retorno;
        }


        public RetornoRelTiposAulaPorAluno EmitirRelTiposAulaPorAluno()
        {

            var agendamentos = _repAgendamento.Recuperar();
            var retorno = new RetornoRelTiposAulaPorAluno();
            var resultado = _repAluno.Recuperar()
                .Select(aluno => new RetornoRelTiposAulaPorAlunoAluno
                {
                    Nome = aluno.Nome,
                    Aulas = agendamentos
                        .Where(a => a.CodigoAluno == aluno.Id)
                        .GroupBy(a =>  a.Aula.TipoAula )
                        .Select(g => new RetornoRelTiposAulaPorAlunoAulas
                        {
                            TipoAula = g.Key,
                            DescricaoTipoAula = g.Key.ToString(),
                            TotalAulas = g.Count()
                        })
                        .OrderByDescending(t => t.TotalAulas)
                        .ToList()
                })
                .ToList();
            retorno.Alunos.AddRange(resultado);
            return retorno;
        }

        public RetornoRelTiposAulaPorAluno EmitirRelTiposAulaPorAluno(int id)
        {
            var aluno = _repAluno.RecuperarPorIdObrigatorio(id);
            var agendamentos = _repAgendamento.Recuperar(); 
            var retorno = new RetornoRelTiposAulaPorAluno();

            var resultado = new RetornoRelTiposAulaPorAlunoAluno
            {
                Nome = aluno.Nome,
                Aulas = agendamentos
                    .Where(a => a.CodigoAluno == aluno.Id)
                    .GroupBy(a => a.Aula.TipoAula) 
                    .Select(g => new RetornoRelTiposAulaPorAlunoAulas
                    {
                        TipoAula = g.Key,
                        DescricaoTipoAula = g.Key.ToString(),
                        TotalAulas = g.Count()
                    })
                    .OrderByDescending(t => t.TotalAulas)
                    .ToList()
            };

            retorno.Alunos.Add(resultado);

            return retorno;
        }
    }
}
