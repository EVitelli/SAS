using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.Sas.Infra.Core.Services.Interfaces;
using Senai.Sas.Infra.Data.Domains;

namespace Senai.Sas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbientesController : ControllerBase
    {

        private readonly IAmbienteService _ambienteService;

        public AmbientesController(IAmbienteService ambienteService)
        {
            _ambienteService = ambienteService;
        }

        // TODO: colocar comentários no código
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ambientes>>> GetAmbientes()
        {
            return Ok(await _ambienteService.ListarTodos());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Ambientes>> GetAmbientes(int id)
        {
            var ambientes = await _ambienteService.BuscarPorId(id);

            if (ambientes == null)
            {
                return NotFound();
            }

            return ambientes;
        }

        [Authorize(Roles = "Administração")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmbientes(int id, Ambientes ambientes)
        {
            
            try
            {
                ambientes.AmbienteId = id;
                _ambienteService.Atualizar(ambientes);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _ambienteService.BuscarPorId(id) != null)
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
        public ActionResult<Ambientes> PostAmbientes(Ambientes ambientes)
        {
            try
            {
                _ambienteService.Cadastrar(ambientes);
                return CreatedAtAction("GetAmbientes", new { id = ambientes.AmbienteId }, ambientes);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
