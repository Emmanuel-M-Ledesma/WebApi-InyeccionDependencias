using ApiPT.Models;
using ApiPT.Repository.Interfaces;
using ApiPT.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ApiPT.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DataContext _Context;
        public PedidoRepository(DataContext context)
        {
            _Context = context;
        }

        public async Task<Pedido> Crear(Pedido pedido)
        {
            _Context.Pedidos.Add(pedido);
            await _Context.SaveChangesAsync();
            return pedido;
        }

        public async Task<List<Pedido>> ListaFinalizado(int Id)
        {
            return await _Context.Pedidos.Where(x => x.IdProveedor == Id && x.IdEstado == 2).ToListAsync();
        }

        public async Task<List<Pedido>> ListaFinalizadoDesde(DateTime FecDesde, int Id)
        {
            return await _Context.Pedidos.Where(x => x.IdProveedor == Id && x.Fecha >= FecDesde && x.IdEstado == 2).ToListAsync();
        }

        public async Task<List<Pedido>> ListaFinalizadoDesdeHasta(DateTime FecDesde, DateTime FecHasta, int Id)
        {
            return await _Context.Pedidos.Where(x => x.IdProveedor == Id && x.Fecha >= FecDesde && x.Fecha <= FecHasta && x.IdEstado == 2).ToListAsync();
        }

        public async Task<List<Pedido>> ListaFinalizadoHasta(DateTime FecHasta, int Id)
        {
            return await _Context.Pedidos.Where(x => x.IdProveedor == Id && x.Fecha >= FecHasta && x.IdEstado == 2).ToListAsync();
        }

        public async Task<List<Pedido>> ListaPendiente(int Id)
        {
            return await _Context.Pedidos.Where(x => x.IdProveedor == Id &&  x.IdEstado == 1).ToListAsync();
        }

        public async Task<List<Pedido>> ListaPendienteDesde(DateTime FecDesde, int Id)
        {
            return await _Context.Pedidos.Where(x => x.IdProveedor == Id && x.Fecha >= FecDesde && x.IdEstado == 1).ToListAsync();
        }

        public async Task<List<Pedido>> ListaPendienteDesdeHasta(DateTime FecDesde, DateTime FecHasta, int Id)
        {
            return await _Context.Pedidos.Where(x => x.IdProveedor == Id && x.Fecha >= FecDesde && x.Fecha <= FecHasta && x.IdEstado == 1).ToListAsync();
        }

        public async Task<List<Pedido>> ListaPendienteHasta(DateTime FecHasta, int Id)
        {
            return await _Context.Pedidos.Where(x => x.IdProveedor == Id && x.Fecha >= FecHasta && x.IdEstado == 1).ToListAsync();
        }
    }
}
