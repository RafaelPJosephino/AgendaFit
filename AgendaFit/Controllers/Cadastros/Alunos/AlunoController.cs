using Aplicacao.Cadastros.Alunos;
using Dominio.Cadastros.Alunos;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers.Cadastros.Alunos
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController(IAplicAluno aplicAluno) : ControllerBase
    {
        private readonly IAplicAluno _aplicAluno = aplicAluno;

        [HttpGet(Name = "Aluno")]
        public ActionResult Get([FromRoute] int id)
        {
            try
            {
                var aluno = _aplicAluno.RecuperarPorId(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost(Name = "Aluno")]
        public ActionResult Post([FromBody] Aluno aluno)
        {
            try
            {
                _aplicAluno.Inserir(aluno);
                return Ok(aluno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut(Name = "Aluno")]
        public ActionResult Put([FromRoute] int id, [FromBody] Aluno aluno)
        {
            try
            {
                _aplicAluno.Alterar(id, aluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete(Name = "Aluno")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                _aplicAluno.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
