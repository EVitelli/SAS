using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Sas.Infra.Core.Services.Interfaces
{
    public interface IAmbienteService
    {
        Task<IEnumerable<Ambientes>> ListarTodos();

        void Cadastrar(Ambientes ambiente);

        void Atualizar(Ambientes ambiente);

        Task<Ambientes> BuscarPorId(int id);
    }
}
