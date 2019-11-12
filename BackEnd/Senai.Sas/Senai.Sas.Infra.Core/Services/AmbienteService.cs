using Senai.Sas.Infra.Core.Persistence.Interfaces;
using Senai.Sas.Infra.Core.Services.Interfaces;
using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Sas.Infra.Core.Services
{
    public class AmbienteService : IAmbienteService
    {

        private readonly IAmbienteRepository _ambienteRepository;

        public AmbienteService(IAmbienteRepository ambienteRepository)
        {
            _ambienteRepository = ambienteRepository;
        }

        public void Atualizar(Ambientes ambiente)
        {
            _ambienteRepository.Atualizar(ambiente);
        }

        public async Task<Ambientes> BuscarPorId(int id)
        {
            Ambientes ambiente = await _ambienteRepository.BuscarPorId(id);
            if (ambiente != null)
                return ambiente;
            return null;
        }

        public void Cadastrar(Ambientes ambiente)
        {
            _ambienteRepository.Cadastrar(ambiente);
        }

        public async Task<IEnumerable<Ambientes>> ListarTodos()
        {
            return await _ambienteRepository.ListarTodos();
        }
    }
}
