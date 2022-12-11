using ApiPT.Dtos;
using ApiPT.Models;
using ApiPT.Repository.Interfaces;
using ApiPT.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiPT.Services.Implementations
{
    public class PedidosService : IPedidosService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper; 

        public PedidosService(IPedidoRepository pedidoRepository, IUserService userService, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Pedido> Crear(PedidoCrearDto pedidoDto, string usrName)
        {
            Usuario usr = new Usuario();
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            bool flag = true;
            usr = _userService.Obtain(usrName);

            if (pedidoDto.Descripcion == "string")
            {
                pedido.Descripcion = "\r\n Debe colocar una descripcion del pedido";
                flag = false;
            }
            if (pedidoDto.IdEstado != 1 && pedidoDto.IdEstado != 2)
            {
                pedido.Descripcion += "\r\n Estado incorrecto. ";
                flag = false;
            }
            if (pedidoDto.Monto <= 0)
            {
                pedido.Descripcion += "\r\n El monto debe ser mayor a cero (0).";
                flag = false;
            }
            if (flag)
            {
                pedido.IdProveedor = usr.IdProveedor;
                return await _pedidoRepository.Crear(pedido);
            }
            return pedido;
        }
        public async Task<List<Pedido>> ListaPendiente(DateTime? FecDesde, DateTime? FecHasta, string usrName)
        {
            Usuario usr = new Usuario();
            usr = _userService.Obtain(usrName);
            int id = usr.IdProveedor;

            if (FecDesde != null && FecHasta == null)
            {
                return await _pedidoRepository.ListaPendienteDesde((DateTime)FecDesde, id);
            }
            if (FecDesde == null && FecHasta != null)
            {
                return await _pedidoRepository.ListaPendienteHasta((DateTime)FecHasta, id);
            }
            if (FecDesde == null && FecHasta == null)
            {
                return await _pedidoRepository.ListaPendiente(id);
            }
            if (FecDesde != null && FecHasta != null && FecDesde <= FecHasta)
            {
                return await _pedidoRepository.ListaPendienteDesdeHasta((DateTime)FecDesde, (DateTime)FecHasta, id);
            }
            return null;
        }

        public async Task<PedidoConsultaDto> ListaFinalizado(DateTime? FecDesde, DateTime? FecHasta, string usrName)
        {
            Usuario usr = new Usuario();
            PedidoConsultaDto Pedidos = new PedidoConsultaDto();
            usr = _userService.Obtain(usrName);
            int id = usr.IdProveedor;

            if (FecDesde != null && FecHasta == null)
            {
                Pedidos.pedidos = await _pedidoRepository.ListaFinalizadoDesde((DateTime)FecDesde, id);
            }
            if (FecDesde == null && FecHasta != null)
            {
                Pedidos.pedidos = await _pedidoRepository.ListaFinalizadoHasta((DateTime)FecHasta, id);
            }
            if (FecDesde == null && FecHasta == null)
            {
                Pedidos.pedidos = await _pedidoRepository.ListaFinalizado(id);
            }
            if (FecDesde != null && FecHasta != null && FecDesde <= FecHasta)
            {
                Pedidos.pedidos = await _pedidoRepository.ListaFinalizadoDesdeHasta((DateTime)FecDesde, (DateTime)FecHasta, id);
            }
            if (Pedidos.pedidos == null)
            {
                Pedidos.pedidos = null;
                return Pedidos;
            }
            if (Pedidos.pedidos.Count>0)
            {
                decimal? suma = 0;
                for (int i = 0; i < Pedidos.pedidos.Count; i++)
                {
                    suma += Pedidos.pedidos[i].Monto;
                }
                Pedidos.SumaTotal = suma;
                Pedidos.ComisionProveedor = suma * usr.IdProveedorNavigation.Comision / 100;
                return Pedidos;
            }
            else
            {
                return Pedidos;
            }



        }
    }
}
