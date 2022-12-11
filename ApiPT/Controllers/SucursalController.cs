using ApiPT.Dtos;
using ApiPT.Models;
using ApiPT.Services.Contracts;
using ApiPT.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ApiPT.Controllers
{
    [ApiController]
    [Route("api/sucursales")]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalService _service;
        public SucursalController(ISucursalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sucursal>>> GetList()
        {
            var lista = await _service.GetList();
            return Ok(lista);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSucursalById(int id)
        {
            var sucursal = await _service.GetSucursalById(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return Ok(sucursal);
        }


        [HttpPost]
        public async Task<ActionResult<Sucursal>> CreateSucursal(SucursalCrearDto sucursalCrearDto)
        {
            var createdSucursal = await _service.CreateSucursal(sucursalCrearDto);
            return createdSucursal;
        }

        //Solo edita los datos principales de la sucursal
        //Calle, numero, localidad y provincia
        [HttpPut("{id}")]
        public async Task<ActionResult<Sucursal>> UpdateSucursal(int id, SucursalCrearDto sucursalCrearDto)
        {
            var updatedSucursal = await _service.UpdateSucursal(id, sucursalCrearDto);
            if (updatedSucursal == null)
            {
                return NotFound();
            }
            return Ok(updatedSucursal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSucursal(int id)
        {
            var sucursal = await _service.DeleteSucursal(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return Ok("La sucursal fue eliminada");
        }

    }
}
