using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sas.Infra.Core.Services;
using Senai.Sas.Infra.Core.Services.Interfaces;
using Senai.Sas.Infra.Core.ViewModels;
using Senai.Sas.Infra.Data.Domains;
using Senai.Sas.WebApi.Utils;

namespace Senai.Sas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Logar(UsuarioViewModel login)
        {
            try
            {
                Usuarios usuarioBuscado = _usuarioService.BuscarPorEmailESenha(login.Nif, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Email ou senha inválidos."
                    });
                }

                //Retorna Ok com o Token
                return Ok(new
                {
                    token = Jwt.GerarToken(usuarioBuscado)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro, contate o administrador.", erro = ex.Message });
            }
        }
    }
}