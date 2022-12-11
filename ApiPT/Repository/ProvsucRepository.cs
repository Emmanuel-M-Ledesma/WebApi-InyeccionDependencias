using ApiPT.Dtos;
using ApiPT.Models;
using ApiPT.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPT.Repository
{
    public class ProvsucRepository : IProvsucRepository
    {
        private readonly DataContext _Context;
        public ProvsucRepository(DataContext context)
        {
            _Context = context; 
        }

        public async Task<ProvSuc> Create(ProvSuc provSuc)
        {
            _Context.ProvSucs.Add(provSuc);
            await _Context.SaveChangesAsync();
            return provSuc;
        }

        public async Task<List<ProvSuc>> GetAll()
        {
            var lista = await _Context.ProvSucs.ToListAsync();
            return lista;
        }

        public Task<List<ProvSuc>> GetByIdP(int IdProv)
        {
            var provSuc = _Context.ProvSucs.Where(x => x.IdProveedor == IdProv).ToListAsync();
            return provSuc;
        }

        public Task<List<ProvSuc>> GetByIdS(int IdSuc)
        {
            var provSuc = _Context.ProvSucs.Where(x => x.IdSucursal == IdSuc).ToListAsync();
            return provSuc;
        }
    }
}
