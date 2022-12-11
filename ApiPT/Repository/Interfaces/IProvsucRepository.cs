using ApiPT.Dtos;
using ApiPT.Models;

namespace ApiPT.Repository.Interfaces
{
    public interface IProvsucRepository
    {
        Task<List<ProvSuc>> GetAll();
        Task<ProvSuc> Create(ProvSuc provSuc);

        Task<List<ProvSuc>> GetByIdP(int IdProv);
        Task<List<ProvSuc>> GetByIdS(int IdSuc);
    }
}
