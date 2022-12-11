using ApiPT.Dtos;
using ApiPT.Models;
using ApiPT.Repository.Interfaces;
using ApiPT.Services.Contracts;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace ApiPT.Services.Implementations
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ProveedorService(IProveedorRepository repository, IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<Proveedor>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<string> Crear(ProveedorUserCrearDto proveedorUser)
        {
            string respuesta;
            var proveedor = _mapper.Map<Proveedor>(proveedorUser);
            respuesta = await _repository.Crear(proveedor);
            if (respuesta == "OK")
            {
                var usuario = _mapper.Map<Usuario>(proveedorUser);
                usuario.IdProveedor = proveedor.IdProveedor;
                respuesta = await _userRepository.Crear(usuario);
                if (respuesta =="OK")
                {
                    return "Creado con exito \r\n" +
                        $"User: {usuario.User} \r\n" +
                        $"Pass: {usuario.Pass} \r\n" +
                        $"Nombre: {proveedor.Nombre} \r\n" +
                        $"Comision: {proveedor.Comision}";
                }
                else
                {
                    await _userRepository.Eliminar(usuario);
                    await _repository.Eliminar(proveedor);
                    return "Error: \r\n" +
                        "Usuario existente";
                }
            }
            else
            {
                return "Error al crear el proveedor";
            }
            
        }
    }
}
