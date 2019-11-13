using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.Sas.Infra.Core.Services.Interfaces;
using Senai.Sas.Infra.Data.Domains;

namespace Senai.Sas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        public AgendamentosController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamentos>> GetAgendamentos(int id)
        {
            var agendamento = await _agendamentoService.BuscarPorId(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            return agendamento;

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamentos>>> GetAgendamentos()
        {
            return Ok(await _agendamentoService.ListarTodos());
        }

        [Authorize(Roles = "Administração")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamentos(int id, Agendamentos agendamentos)
        {

            try
            {
                agendamentos.AgendamentoId = id;
                _agendamentoService.Atualizar(agendamentos);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _agendamentoService.BuscarPorId(id) != null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        [Authorize(Roles = "Administração")]
        [HttpPost]
        public ActionResult<Agendamentos> PostAmbientes(Agendamentos agendamento)
        {
            try
            {
                _agendamentoService.Cadastrar(agendamento);
                return CreatedAtAction("GetAgendamentos", new { id = agendamento.AgendamentoId }, agendamento);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


    }
}