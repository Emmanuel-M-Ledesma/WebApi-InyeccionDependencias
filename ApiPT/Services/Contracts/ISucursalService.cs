using ApiPT.Dtos;
using ApiPT.Models;

namespace ApiPT.Services.Contracts
{
    public interface ISucursalService
    {
        Task<Sucursal> CreateSucursal(SucursalCrearDto sucursalCrearDto);
        Task<Sucursal> DeleteSucursal(int id);
        Task<List<Sucursal>> GetList();
        Task<Sucursal> GetSucursalById(int id);
        Task<Sucursal> UpdateSucursal(int id, SucursalCrearDto sucursalCrearDto);
    }
}
