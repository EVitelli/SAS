using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Sas.Infra.Core.Persistence.Interfaces
{
    public interface IAmbienteRepository
    {
        Task<IEnumerable<Ambientes>> ListarTodos();

        void Cadastrar(Ambientes ambiente);

        void Atualizar(Ambientes ambiente);

        Task<Ambientes> BuscarPorId(int id);
    }
}
