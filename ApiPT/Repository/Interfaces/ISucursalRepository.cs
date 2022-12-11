using ApiPT.Models;

namespace ApiPT.Repository.Interfaces
{
    public interface ISucursalRepository
    {
        Task<Sucursal> CreateSucursal(Sucursal sucursal);
        Task<Sucursal> DeleteSucursal(int id);
        Task<List<Sucursal>> GetList();
        Task<Sucursal> GetSucursalById(int id);
        Task<Sucursal> UpdateSucursal(Sucursal sucursal);
    }
}
