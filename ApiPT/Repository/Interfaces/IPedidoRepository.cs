using ApiPT.Models;

namespace ApiPT.Repository.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido> Crear(Pedido pedido);
        Task<List<Pedido>> ListaPendienteDesdeHasta(DateTime FecDesde, DateTime FecHasta, int Id);
        Task<List<Pedido>> ListaPendienteDesde(DateTime FecDesde, int Id);
        Task<List<Pedido>> ListaPendienteHasta(DateTime FecHasta, int Id);
        Task<List<Pedido>> ListaPendiente(int Id);
        Task<List<Pedido>> ListaFinalizadoDesdeHasta(DateTime FecDesde, DateTime FecHasta, int Id);
        Task<List<Pedido>> ListaFinalizadoDesde(DateTime FecDesde, int Id);
        Task<List<Pedido>> ListaFinalizadoHasta(DateTime FecHasta, int Id);
        Task<List<Pedido>> ListaFinalizado(int Id);
    }
}
