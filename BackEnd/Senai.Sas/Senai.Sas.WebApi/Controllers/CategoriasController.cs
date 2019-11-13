using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.Sas.Infra.Core.Services.Interfaces;
using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Senai.Sas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetAmbientes()
        {
            return Ok(await _categoriaService.ListarTodos());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorias>> GetCategorias(int id)
        {
            var ambientes = await _categoriaService.BuscarPorId(id);

            if (ambientes == null)
            {
                return NotFound();
            }

            return ambientes;
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorias(int id, Categorias categorias)
        {

            try
            {
                categorias.CategoriaId = id;
                _categoriaService.Atualizar(categorias);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _categoriaService.BuscarPorId(id) != null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Categorias>> PostCategorias(Categorias categorias)
        {
            try
            {
                _categoriaService.Cadastrar(categorias);
                return CreatedAtAction("GetCategorias", new { id = categorias.CategoriaId }, categorias);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}