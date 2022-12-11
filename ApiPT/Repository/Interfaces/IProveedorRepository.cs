using ApiPT.Models;

namespace ApiPT.Repository.Interfaces
{
    public interface IProveedorRepository
    {
        Task<List<Proveedor>> GetAll();
        Task<string> Crear(Proveedor proveedor);
        Task<string> Eliminar(Proveedor proveedor);

    }
}
