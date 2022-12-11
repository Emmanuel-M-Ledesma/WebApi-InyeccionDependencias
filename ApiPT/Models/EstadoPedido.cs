using System;
using System.Collections.Generic;

namespace ApiPT.Models
{
    public partial class EstadoPedido
    {
        public EstadoPedido()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdEstado { get; set; }
        public string TipoEstado { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
