using ApiPT.Dtos;
using ApiPT.Models;
using ApiPT.Repository;
using ApiPT.Repository.Interfaces;
using ApiPT.Services.Contracts;
using AutoMapper;

namespace ApiPT.Services.Implementations
{
    public class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository _repository;
        private readonly IMapper _mapper;
        public SucursalService(ISucursalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<Sucursal>> GetList()
        {
            return await _repository.GetList();
        }
        public async Task<Sucursal> GetSucursalById(int id)
        {
            var sucursal = await _repository.GetSucursalById(id);
            return sucursal;
        }

        public async Task<Sucursal> CreateSucursal(SucursalCrearDto sucursalCrearDto)
        {
            var sucursal = _mapper.Map<Sucursal>(sucursalCrearDto);
            return await _repository.CreateSucursal(sucursal);
        }

        public async Task<Sucursal> UpdateSucursal(int id, SucursalCrearDto sucursalCrearDto)
        {
            var existingSucursal = await _repository.GetSucursalById(id);
            if (existingSucursal == null)
            {
                return null;
            }
            //mapeando la sucursal el origen es el Dto y el destino el model de la sucursal (Se hace de este modo para el put )
            _mapper.Map(sucursalCrearDto, existingSucursal);
            return await _repository.UpdateSucursal(existingSucursal);
        }

        public async Task<Sucursal> DeleteSucursal(int id)
        {
            return await _repository.DeleteSucursal(id);

        }
    }
}
