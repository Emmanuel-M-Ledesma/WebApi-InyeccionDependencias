using ApiPT.Models;
using ApiPT.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPT.Repository
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly DataContext _Context;

        public SucursalRepository(DataContext context)
        {
            _Context = context;
        }

        public async Task<List<Sucursal>> GetList()
        {
            return await _Context.Sucursales.ToListAsync();
        }
        public async Task<Sucursal> GetSucursalById(int id)
        {
            var sucursal = await _Context.Sucursales.Where(x => x.IdSucursal == id).FirstOrDefaultAsync();
            return sucursal;
        }

        public async Task<Sucursal> CreateSucursal(Sucursal sucursal)
        {
            _Context.Sucursales.Add(sucursal);
            await _Context.SaveChangesAsync();
            return sucursal;
        }

        public async Task<Sucursal> UpdateSucursal(Sucursal sucursal)
        {
            _Context.Sucursales.Update(sucursal);
            await _Context.SaveChangesAsync();
            return sucursal;
        }

        public async Task<Sucursal> DeleteSucursal(int id)
        {
            var sucursal = _Context.Sucursales.Find(id);
            if (sucursal == null)
            {
                return null;
            }

            _Context.Sucursales.Remove(sucursal);
            await _Context.SaveChangesAsync();
            return sucursal;
        }
    }
}
