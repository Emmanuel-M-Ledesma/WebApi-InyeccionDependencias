using ApiPT.Models;
using ApiPT.Repository.Interfaces;
using ApiPT.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ApiPT.Services.Implementations
{
    public class UserService : IUserService
    {
        private DataContext _Context;
        private readonly IUserRepository _repository;
        public UserService(DataContext context, IUserRepository repository)
        {
            _Context = context;
            _repository = repository;
        }

        public bool IsUser(string User, string Pass) =>
                _Context.Usuarios.Where(d => d.User == User && d.Pass == Pass).Count() > 0;

        public Usuario Obtain(string User)
        {
            Usuario usr = new Usuario();

            return _Context.Usuarios.Include(u => u.IdProveedorNavigation).Where(d => d.User == User).FirstOrDefault();
        }

        public async Task<Usuario> Buscar(int Id)
        {
            return await _repository.Buscar(Id);
        }
    }
}
