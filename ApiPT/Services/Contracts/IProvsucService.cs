using ApiPT.Dtos;
using ApiPT.Models;

namespace ApiPT.Services.Contracts
{
    public interface IProvsucService
    {
        Task<List<ProvSuc>> GetAll();

        Task<ProvSuc> Create(ProvSucsCrearDto provSucDto);

        Task<List<ProvSuc>> GetById(int? IdProv, int? IdSuc);

    }
}
