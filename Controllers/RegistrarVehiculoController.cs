using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Service.Logic;

namespace Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculosController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarVehiculo([FromBody] RegistrarVehiculoRequest model)
        {
            if (model == null)
                return BadRequest("El request no puede ser nulo.");

            var response = await _vehiculoService.RegistrarVehiculoAsync(model);
            return Ok(response);
        }
    }
}
