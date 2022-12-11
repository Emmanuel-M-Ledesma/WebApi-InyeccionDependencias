    using ApiPT.Dtos;
using ApiPT.Models;
using ApiPT.Services;
using ApiPT.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPT.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    [Authorize]
    public class PedidosController : Controller
    {
        private readonly IPedidosService _service;
        public PedidosController(IPedidosService pedidosService)
        {
            _service = pedidosService;
        }


        //Crear pedido en base al usuario logueado
        [HttpPost]
        [Route("crear")]
        public async Task<ActionResult<Pedido>> Post(PedidoCrearDto pedidoDto)
        {
            Pedido pedido = new();
            pedido= await _service.Crear(pedidoDto, User.Identity.Name);

            if (pedido.IdPedido != 0)
            {
                return Ok(pedido);
            }
            else
            {
                return BadRequest("No se pudo generar el pedido: "+ pedido.Descripcion);
            }
        }

        [HttpGet]
        [Route("pendiente")]
        public async Task<IActionResult> GetPen(DateTime? FechaDesde, DateTime? FechaHasta)
        {
            
            PedidoConsultaDto pedidoConsultaDto = new PedidoConsultaDto();
            var Lista = await _service.ListaPendiente(FechaDesde, FechaHasta, User.Identity.Name);
            if (Lista == null)
            {
                return BadRequest("Inconsistencia en las fechas");
            }
            pedidoConsultaDto.pedidos = Lista;
            if (pedidoConsultaDto.pedidos.Count > 0)
            {
                return Ok(pedidoConsultaDto);
            }            
            else
            {
                return BadRequest("La busqueda no arrojo ningun resultado");
            }
        }


        [HttpGet]
        [Route("finalizado")]
        public async Task<IActionResult> GetFin(DateTime? FechaDesde, DateTime? FechaHasta)
        {
            PedidoConsultaDto pedidoConsultaDto = await _service.ListaFinalizado(FechaDesde, FechaHasta, User.Identity.Name);

            if (pedidoConsultaDto.pedidos == null)
            {
                return BadRequest("Inconsistencia en las fechas");
            }
            if (pedidoConsultaDto.pedidos.Count > 0)
            {
                return Ok(pedidoConsultaDto);
            }
            else
            {
                return BadRequest("La busqueda no arrojo ningun resultado");
            }
        }
    }
}
