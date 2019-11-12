using Microsoft.EntityFrameworkCore;
using Senai.Sas.Infra.Core.Persistence.Interfaces;
using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Senai.Sas.Infra.Core.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(SasContext context) : base(context)
        {
        }

        public Usuarios BuscarPorEmailESenha(string nif, string senha)
        {
            return _context.Usuarios.Include(x => x.Permissao).FirstOrDefault(x => x.Nif == nif && x.Senha == senha);
        }
    }
}
