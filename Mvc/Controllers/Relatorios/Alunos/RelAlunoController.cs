using Aplicacao.Cadastros.Alunos;
using Aplicacao.Relatorios.Alunos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mvc.Base;
using Repositorio.Cadastros.Alunos;

namespace Mvc.Controllers.Relatorios.Alunos
{
    [ApiController]
    [Route("[controller]")]
    public class RelAlunoController(IAplicRelAluno aplicRelAluno, IMapper mapper) : ControllerBase
    {
        private readonly IAplicRelAluno _aplicRelAluno = aplicRelAluno;
        private readonly IMapper _mapper = mapper;

        [HttpGet("RelTotalAulasMesPorAluno/{id}")]
        public ActionResult EmitirRelTotalAulasMesPorAluno([FromRoute] int id)
        {
            try
            {
                var aluno = _aplicRelAluno.EmitirRelTotalAulasMesPorAluno(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

        [HttpGet("/RelTotalAulasMesPorAluno")]
        public ActionResult EmitirRelTotalAulasMesPorAluno()
        {
            try
            {
                var aluno = _aplicRelAluno.EmitirRelTotalAulasMesPorAluno();
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

        [HttpGet("RelTiposAulaPorAluno/{id}")]
        public ActionResult EmitirRelTiposAulaPorAluno([FromRoute] int id)
        {
            try
            {
                var aluno = _aplicRelAluno.EmitirRelTiposAulaPorAluno(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

        [HttpGet("/RelTiposAulaPorAluno")]
        public ActionResult EmitirRelTiposAulaPorAluno()
        {
            try
            {
                var aluno = _aplicRelAluno.EmitirRelTiposAulaPorAluno();
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

    }
}
