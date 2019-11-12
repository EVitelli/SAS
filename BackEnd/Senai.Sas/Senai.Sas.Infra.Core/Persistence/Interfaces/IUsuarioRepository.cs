using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senai.Sas.Infra.Core.Persistence.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailESenha(string nif, string senha);
    }
}
