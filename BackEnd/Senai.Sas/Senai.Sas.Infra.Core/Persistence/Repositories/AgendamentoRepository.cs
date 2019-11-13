using Microsoft.EntityFrameworkCore;
using Senai.Sas.Infra.Core.Persistence.Interfaces;
using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Sas.Infra.Core.Persistence.Repositories
{
    public class AgendamentoRepository : BaseRepository, IAgendamentoRepository
    {
        public AgendamentoRepository(SasContext context) : base(context)
        {
        }

        public void Atualizar(Agendamentos agendamento)
        {
            _context.Entry(agendamento).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public async Task<Agendamentos> BuscarPorId(int id)
        {
            Agendamentos agendamentoBuscado = await _context.Agendamentos.FindAsync(id);
            if (agendamentoBuscado == null)
                return null;
            return agendamentoBuscado;
        }

        public void Cadastrar(Agendamentos agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Agendamentos>> ListarTodos()
        {
            return await _context.Agendamentos.ToListAsync();
        }
    }
}
