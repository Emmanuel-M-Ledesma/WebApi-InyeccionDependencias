using ApiPT.Models;
using ApiPT.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPT.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _Context;
        public UserRepository(DataContext context)
        {
            _Context = context;
        }

        public async Task<Usuario> Buscar(int Id)
        {
            Usuario usuario = await _Context.Usuarios.Where(x => x.IdProveedor == Id).FirstOrDefaultAsync();
            return (usuario);
        }

        public async Task<string> Crear(Usuario usuario)
        {
            try
            {
                _Context.Usuarios.Add(usuario);
                await _Context.SaveChangesAsync();
                return "OK";
            }
            catch (Exception)
            {

                return "";
            }
        }

        public async Task<string> Eliminar(Usuario usuario)
        {
            try
            {
                _Context.Usuarios.Remove(usuario);
                await _Context.SaveChangesAsync();
                return "OK";
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
