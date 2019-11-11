using System;
using System.Collections.Generic;

namespace Senai.Sas.Infra.Data.Domains
{
    public partial class Ambientes
    {
        public Ambientes()
        {
            Agendamentos = new HashSet<Agendamentos>();
        }

        public int AmbienteId { get; set; }
        public string Nome { get; set; }
        public string DescricaoSoftwares { get; set; }
        public string DescricaoEquipamentos { get; set; }
        public int QtdEquipamentos { get; set; }
        public int QtdMaxPessoas { get; set; }
        public string Observacao { get; set; }
        public string StatusAmbiente { get; set; }

        public virtual ICollection<Agendamentos> Agendamentos { get; set; }
    }
}
