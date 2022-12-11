using System;
using System.Collections.Generic;

namespace ApiPT.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            ProvSucs = new HashSet<ProvSuc>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdProveedor { get; set; }
        public string? Nombre { get; set; }
        public int Comision { get; set; }

        public virtual ICollection<ProvSuc> ProvSucs { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
