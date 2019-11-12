using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senai.Sas.Infra.Core.Services.Interfaces
{
    public interface IUsuarioService
    {
        Usuarios BuscarPorEmailESenha(string email, string senha);

    }
}
