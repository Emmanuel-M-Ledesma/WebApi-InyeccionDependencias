using ApiPT.Dtos;
using ApiPT.Models;

namespace ApiPT.Services.Contracts
{
    public interface IProveedorService
    {
        Task<List<Proveedor>> GetAll();
        Task<string> Crear(ProveedorUserCrearDto proveedorUser);  

    }
}
