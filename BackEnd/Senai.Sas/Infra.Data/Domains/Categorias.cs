using System;
using System.Collections.Generic;

namespace Senai.Sas.Infra.Data.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Agendamentos = new HashSet<Agendamentos>();
        }

        public int CategoriaId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Agendamentos> Agendamentos { get; set; }
    }
}
