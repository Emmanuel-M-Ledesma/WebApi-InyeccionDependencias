using ApiPT.Dtos;
using ApiPT.Models;
using AutoMapper;

namespace ApiPT.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProvSucsCrearDto, ProvSuc>();
            CreateMap<PedidoCrearDto, Pedido>();
            CreateMap<ProveedorUserCrearDto, Proveedor>();
            CreateMap<ProveedorUserCrearDto, Usuario>();
            CreateMap<SucursalCrearDto, Sucursal>();
        }
    }
}
