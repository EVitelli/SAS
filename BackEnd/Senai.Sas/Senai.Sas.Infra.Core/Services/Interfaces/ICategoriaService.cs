using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Sas.Infra.Core.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categorias>> ListarTodos();

        void Cadastrar(Categorias categoria);

        void Atualizar(Categorias categoria);

        Task<Categorias> BuscarPorId(int id);
    }
}
