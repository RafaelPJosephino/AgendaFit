using Aplicacao.Cadastros.Alunos;
using Aplicacao.Cadastros.Alunos.Dtos;
using AutoMapper;
using Dominio.Cadastros.Alunos;
using Dominio.Cadastros.Aulas;
using Microsoft.AspNetCore.Mvc;
using Mvc.Base;

namespace Mvc.Controllers.Cadastros.Alunos
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController(IAplicAluno aplicAluno, IMapper mapper) : ControllerBase
    {
        private readonly IAplicAluno _aplicAluno = aplicAluno;
        private readonly IMapper _mapper  = mapper;

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            try
            {
                var aluno = _aplicAluno.RecuperarPorId(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] InserirAlunoDto alunoDto)
        {
            try
            {
                var aluno = _mapper.Map<Aluno>(alunoDto);
                _aplicAluno.Inserir(aluno);
                return Ok(aluno);

            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] EditarAlunoDto alunoDto)
        {
            try
            {
                var aluno = _mapper.Map<Aluno>(alunoDto);
                _aplicAluno.Alterar(id, aluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                _aplicAluno.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

    }
}
