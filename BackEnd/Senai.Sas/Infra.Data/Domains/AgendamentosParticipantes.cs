using System;
using System.Collections.Generic;

namespace Senai.Sas.Infra.Data.Domains
{
    public partial class AgendamentosParticipantes
    {
        public int AgendaParticipanteId { get; set; }
        public int? AgendamentoId { get; set; }
        public int? ParticipanteId { get; set; }
        public string StatusParticipante { get; set; }

        public virtual Agendamentos Agendamento { get; set; }
        public virtual Participantes Participante { get; set; }
    }
}
