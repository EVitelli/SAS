using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Senai.Sas.Infra.Core.Exceptions;
using Senai.Sas.Infra.Core.Persistence.Interfaces;
using Senai.Sas.Infra.Core.Services.Interfaces;
using Senai.Sas.Infra.Data.Domains;

namespace Senai.Sas.Infra.Core.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public void Atualizar(Agendamentos agendamento)
        {
            _agendamentoRepository.Atualizar(agendamento);
        }

        public async Task<Agendamentos> BuscarPorId(int id)
        {
            try
            {
                Agendamentos agendamento = await _agendamentoRepository.BuscarPorId(id);
                if (agendamento != null)
                    return agendamento;
                return null;
            }
            catch (System.Exception)
            {
                throw new Exception("Erro ao buscar agendamento.");   
            }
        }

        public void Cadastrar(Agendamentos agendamento)
        {

            _agendamentoRepository.Cadastrar(agendamento);

        }

        public Task<IEnumerable<Agendamentos>> ListarTodos()
        {
            return _agendamentoRepository.ListarTodos();
        }
    }
}
