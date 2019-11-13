using Senai.Sas.Infra.Data.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Senai.Sas.Infra.Core.Services.Interfaces
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<Agendamentos>> ListarTodos();

        void Cadastrar(Agendamentos agendamento);

        void Atualizar(Agendamentos agendamento);

        Task<Agendamentos> BuscarPorId(int id);
    }
}
