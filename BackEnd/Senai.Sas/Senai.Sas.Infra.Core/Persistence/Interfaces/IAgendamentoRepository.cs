using Senai.Sas.Infra.Data.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Senai.Sas.Infra.Core.Persistence.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<IEnumerable<Agendamentos>> ListarTodos();

        void Cadastrar(Agendamentos agendamento);

        void Atualizar(Agendamentos agendamento);

        Task<Agendamentos> BuscarPorId(int id);
    }
}
