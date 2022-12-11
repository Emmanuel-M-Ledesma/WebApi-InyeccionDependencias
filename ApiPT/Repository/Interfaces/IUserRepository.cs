using ApiPT.Models;

namespace ApiPT.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<string> Crear(Usuario usuario);
        Task<string> Eliminar(Usuario usuario);
        Task<Usuario> Buscar(int Id);
    }
}
