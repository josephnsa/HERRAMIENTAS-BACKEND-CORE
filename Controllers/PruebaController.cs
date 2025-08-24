using Microsoft.AspNetCore.Mvc;
using Service.Logic;

namespace Microservice.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PruebasController : ControllerBase
	{
		private readonly IPruebaService _PruebaService;

		public PruebasController(IPruebaService pruebaService)
		{
			_PruebaService = pruebaService;
		}

		[HttpGet]
		public async Task<IActionResult> ObtenerTodos()
		{
			var Pruebas = await _PruebaService.GetPrueba();
			return Ok(Pruebas);
		}
	}
}
