using ApiPT.Models;

namespace ApiPT.Dtos
{
    public class PedidoConsultaDto
    {
        public List<Pedido> pedidos { get; set; }
        public decimal? SumaTotal { get; set; }
        public decimal? ComisionProveedor { get; set; }
    }
}
