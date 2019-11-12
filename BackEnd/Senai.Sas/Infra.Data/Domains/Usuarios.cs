using System;
using System.Collections.Generic;

namespace Senai.Sas.Infra.Data.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Agendamentos = new HashSet<Agendamentos>();
        }

        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Nif { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? PermissaoId { get; set; }
        public bool StatusUsuario { get; set; }

        public virtual Permissoes Permissao { get; set; }
        public virtual ICollection<Agendamentos> Agendamentos { get; set; }
    }
}
