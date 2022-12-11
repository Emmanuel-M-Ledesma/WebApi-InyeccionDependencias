using System;
using System.Collections.Generic;

namespace ApiPT.Models
{
    public partial class ProvSuc
    {
        public ProvSuc()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdProveedor { get; set; }
        public int IdSucursal { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
