using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPT.Dtos
{
    public class PedidoCrearDto
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        [NotMapped]
        public int IdProveedor { get; set; }
        public int IdEstado { get; set; }
    }
}
