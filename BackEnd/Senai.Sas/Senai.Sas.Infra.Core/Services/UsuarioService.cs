using Senai.Sas.Infra.Core.Persistence.Interfaces;
using Senai.Sas.Infra.Core.Services.Interfaces;
using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senai.Sas.Infra.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            Usuarios usuario = _usuarioRepository.BuscarPorEmailESenha(email.ToLower(), senha);

            if (usuario == null)
                return null;

            return usuario;
        }
    }
}
