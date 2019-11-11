using System;
using System.Collections.Generic;

namespace Senai.Sas.Infra.Data.Domains
{
    public partial class Agendamentos
    {
        public Agendamentos()
        {
            AgendamentosParticipantes = new HashSet<AgendamentosParticipantes>();
        }

        public int AgendamentoId { get; set; }
        public DateTime InicioReserva { get; set; }
        public DateTime TerminoReserva { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string StatusAgenda { get; set; }
        public int? CategoriaId { get; set; }
        public int? Criador { get; set; }
        public int? AmbienteId { get; set; }

        public virtual Ambientes Ambiente { get; set; }
        public virtual Categorias Categoria { get; set; }
        public virtual Usuarios CriadorNavigation { get; set; }
        public virtual ICollection<AgendamentosParticipantes> AgendamentosParticipantes { get; set; }
    }
}
