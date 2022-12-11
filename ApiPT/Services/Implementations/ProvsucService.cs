using ApiPT.Dtos;
using ApiPT.Models;
using ApiPT.Repository.Interfaces;
using ApiPT.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;

namespace ApiPT.Services.Implementations
{
    public class ProvsucService : IProvsucService
    {
        private readonly IProvsucRepository _repository;
        private readonly IMapper _mapper;
        public ProvsucService(IProvsucRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ProvSuc> Create(ProvSucsCrearDto provSucDto)
        {
            var provSuc= _mapper.Map<ProvSuc>(provSucDto);
            return _repository.Create(provSuc);
        }

        public async Task<List<ProvSuc>> GetAll()
        {
            var lista = await _repository.GetAll();
            return lista;
        }

        public async Task<List<ProvSuc>> GetById(int? IdProv, int? IdSuc)
        {
            if (IdProv != null)
            {
                return await _repository.GetByIdP((int)IdProv);
            }
            if (IdSuc!=null)
            {
                return await _repository.GetByIdP((int)IdSuc);
            }
            return null;
            
        }
    }
}
