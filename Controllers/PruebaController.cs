using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Service.Logic;

namespace Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PruebasController : ControllerBase
    {
        private readonly IPruebaService _pruebaService;

        public PruebasController(IPruebaService pruebaService)
        {
            _pruebaService = pruebaService;
        }

        [HttpGet("Obtener")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var pruebas = await _pruebaService.GetPrueba();
            return Ok(pruebas);
        }

        [HttpPost("ConsultarSegurosCliente")]
        public async Task<IActionResult> ConsultarSegurosCliente([FromBody] ObtenerSegurosClienteRequest model)
        {
            if (model == null)
                return BadRequest("El request no puede ser nulo.");

            var seguros = await _pruebaService.ConsultarSegurosPorCliente(model);
            return Ok(seguros);
        }
    }
}
