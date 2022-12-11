using ApiPT.Dtos;
using ApiPT.Models;
using ApiPT.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ApiPT.Controllers
{
    [ApiController]
    [Route("api/provsuc")]
    public class ProvSucsController : Controller
    {
        private readonly IProvsucService _Service;

        public ProvSucsController(IProvsucService service)
        {
            _Service = service;
        }

        [HttpGet]

        public async Task<ActionResult<List<ProvSuc>>> GetList()
        {
            var Lista = await _Service.GetAll();
            if (Lista== null)
            {
                return NoContent();
            }
            return Ok(Lista);
        }
        [HttpGet]
        [Route("ById")]
        public async Task<ActionResult<List<ProvSuc>>> GetById(int? IdProv, int? IdSuc)
        {
            var Lista = await _Service.GetById(IdProv, IdSuc);
            if (Lista== null)
            {
                return NotFound();
            }
            return Ok(Lista);
        }

        [HttpPost]
        public async Task<ActionResult<ProvSuc>> Crear(ProvSucsCrearDto provSucsDto)
        {
            var provSuc = await _Service.Create(provSucsDto);
            if (provSuc != null)
            {
                return Ok(provSuc);
            }
            return BadRequest();
        }


    }
}
