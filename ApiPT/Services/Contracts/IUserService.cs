using ApiPT.Models;

namespace ApiPT.Services.Contracts
{
    public interface IUserService
    {
        public bool IsUser(string User, string Pass);
        public Usuario Obtain(string User);

        Task<Usuario> Buscar(int Id);
    }
}
