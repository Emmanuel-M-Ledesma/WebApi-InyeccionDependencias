using ApiPT.Models;
using ApiPT.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPT.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly DataContext _Context;
        public ProveedorRepository(DataContext context)
        {
            _Context = context;
        }
        public async Task<List<Proveedor>> GetAll()
        {
            return await _Context.Proveedores.ToListAsync();
        }
        public async Task<string> Crear(Proveedor proveedor)
        {
            try
            {
                _Context.Proveedores.Add(proveedor);
                await _Context.SaveChangesAsync();
                return "OK";
            }
            catch (Exception)
            {
                return "";                
            }
            
        }

        public async Task<string> Eliminar(Proveedor proveedor)
        {
            try
            {
                _Context.Proveedores.Remove(proveedor);
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
