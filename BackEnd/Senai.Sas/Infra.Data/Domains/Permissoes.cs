using System;
using System.Collections.Generic;

namespace Senai.Sas.Infra.Data.Domains
{
    public partial class Permissoes
    {
        public Permissoes()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int PermissaoId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
