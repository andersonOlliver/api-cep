using ConsultaCep.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ConsultaCep.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly ICepService _service;

        public ConsultaController(ICepService service)
        {
            _service = service;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> ConsultarAsync(string cep)
        {
            try
            {
                var result = await _service.FindAsync(cep);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}