using System.Collections.Generic;
using System.Threading.Tasks;
using Senai.Sas.Infra.Core.Persistence.Interfaces;
using Senai.Sas.Infra.Core.Services.Interfaces;
using Senai.Sas.Infra.Data.Domains;

namespace Senai.Sas.Infra.Core.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Atualizar(Categorias categoria)
        {
            _categoriaRepository.Atualizar(categoria);
        }

        public async Task<Categorias> BuscarPorId(int id)
        {
            Categorias categoria = await _categoriaRepository.BuscarPorId(id);
            if (categoria != null)
                return categoria;
            return null;
        }

        public void Cadastrar(Categorias categoria)
        {
            _categoriaRepository.Cadastrar(categoria);
        }

        public async Task<IEnumerable<Categorias>> ListarTodos()
        {
            return await _categoriaRepository.ListarTodos();
        }
    }
}
