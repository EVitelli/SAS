using System;
using System.Collections.Generic;

namespace Senai.Sas.Infra.Data.Domains
{
    public partial class Participantes
    {
        public Participantes()
        {
            AgendamentosParticipantes = new HashSet<AgendamentosParticipantes>();
        }

        public int ParticipanteId { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<AgendamentosParticipantes> AgendamentosParticipantes { get; set; }
    }
}
