using ApiPT.Dtos;
using ApiPT.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPT.Services.Contracts
{
    public interface IPedidosService
    {
        Task<Pedido> Crear (PedidoCrearDto pedidoDto, string usrName);
        Task<List<Pedido>> ListaPendiente(DateTime? FecDesde, DateTime? FecHasta, string usrName);
        Task<PedidoConsultaDto> ListaFinalizado(DateTime? FecDesde, DateTime? FecHasta,string usrName);
    }
}
