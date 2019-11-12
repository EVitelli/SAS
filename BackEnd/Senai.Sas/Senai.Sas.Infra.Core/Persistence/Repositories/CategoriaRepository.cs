using Microsoft.EntityFrameworkCore;
using Senai.Sas.Infra.Core.Persistence.Interfaces;
using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Sas.Infra.Core.Persistence.Repositories
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        public CategoriaRepository(SasContext context) : base(context)
        {
        }

        public void Atualizar(Categorias categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public async Task<Categorias> BuscarPorId(int id)
        {
            Categorias categoriaBuscada = await _context.Categorias.FindAsync(id);
            if (categoriaBuscada == null)
                return null;
            return categoriaBuscada;
        }

        public void Cadastrar(Categorias categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Categorias>> ListarTodos()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
