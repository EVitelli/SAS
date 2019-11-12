using Microsoft.EntityFrameworkCore;
using Senai.Sas.Infra.Core.Persistence.Interfaces;
using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Sas.Infra.Core.Persistence.Repositories
{
    public class AmbienteRepository : BaseRepository, IAmbienteRepository
    {
        public AmbienteRepository(SasContext context) : base(context)
        {
        }

        public void Atualizar(Ambientes ambiente)
        {            
            _context.Entry(ambiente).State = EntityState.Modified;
            _context.SaveChangesAsync();   
        }

        public async Task<Ambientes> BuscarPorId(int id)
        {
            Ambientes ambienteBuscado = await _context.Ambientes.FindAsync(id);
            if (ambienteBuscado == null)
                return null;
            return ambienteBuscado;
        }

        public void Cadastrar(Ambientes ambiente)
        {
            _context.Ambientes.Add(ambiente);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Ambientes>> ListarTodos()
        {
            return await _context.Ambientes.ToListAsync();
        }
    }
}
