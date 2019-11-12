using Senai.Sas.Infra.Data.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Senai.Sas.Infra.Core.Persistence.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categorias>> ListarTodos();

        void Cadastrar(Categorias categoria);

        void Atualizar(Categorias categoria);

        Task<Categorias> BuscarPorId(int id);
    }
}
