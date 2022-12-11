using ApiPT.Dtos;
using ApiPT.Models;
using ApiPT.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiPT.Controllers
{
    [ApiController]
    [Route("api/proveedores")]

    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _Service;
        private readonly IUserService _userService;

        public ProveedorController(IProveedorService service, IUserService userService)
        {
            _Service = service;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proveedor>>> GetAll()
        {
            var proveedor = await _Service.GetAll();
            return Ok(proveedor);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var user = await _userService.Buscar(id);
            if (user == null)
            {
                return NotFound("El usuario no existe");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(ProveedorUserCrearDto proveedorUserDto)
        {
            string respuesta = await _Service.Crear(proveedorUserDto);

            if (respuesta.Contains("Error"))
            {
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }
    }
}
