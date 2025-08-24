using Aplicacao.Cadastros.Aulas;
using Aplicacao.Cadastros.Aulas.Dtos;
using AutoMapper;
using Dominio.Cadastros.Aulas;
using Microsoft.AspNetCore.Mvc;
using Mvc.Base;

namespace Mvc.Controllers.Cadastros.Aulas
{
    [ApiController]
    [Route("[controller]")]
    public class AulaController(IAplicAula aplicAula,IMapper mapper) : ControllerBase
    {
        private readonly IAplicAula _aplicAula = aplicAula;
        private readonly IMapper _mapper = mapper; 


        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            try
            {
                var aula = _aplicAula.RecuperarPorId(id);
                return Ok(aula);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação.")); 
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] InserirAulaDto aulaDto)
        {
            try
            {
                var aula = _mapper.Map<Aula>(aulaDto);
                _aplicAula.Inserir(aula);
                return Ok(aula);

            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] InserirAulaDto aulaDto)
        {
            try
            {
                var aula = _mapper.Map<Aula>(aulaDto);
                _aplicAula.Alterar(id, aula);
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
                _aplicAula.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

    }
}
