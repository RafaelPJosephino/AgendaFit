using Aplicacao.Agendamentos.Agendamentos;
using Aplicacao.Agendamentos.Agendamentos.Dtos;
using AutoMapper;
using Dominio.Agendamentos;
using Dominio.Cadastros.Alunos;
using Microsoft.AspNetCore.Mvc;
using Mvc.Base;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mvc.Controllers.Agendamentos.Agandamentos
{
    [ApiController]
    [Route("[controller]")]
    public class AgendamentoController(IAplicAgendamento aplicAgendamento, IMapper mapper) : ControllerBase
    {
        private readonly IAplicAgendamento _aplicAgendamento = aplicAgendamento;
        private readonly IMapper _mapper = mapper;


        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            try
            {
                var agendamento = _aplicAgendamento.RecuperarPorId(id);
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] InserirAgendamentoDto agendamentoDto)
        {    
            try
            {
                var agendamento = _mapper.Map<Agendamento>(agendamentoDto);
                _aplicAgendamento.Inserir(agendamento);
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
                _aplicAgendamento.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex, "Ocorreu um erro ao processar a solicitação."));
            }
        }

    }
}
