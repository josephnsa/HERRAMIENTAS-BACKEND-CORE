using Data.Repository;
using Model.Request;
using Model.Response;

namespace Service.Logic
{
	public interface IPruebaService
	{
		Task<IEnumerable<SystemParameterGetByReferenceResponse>> GetPrueba();
		Task<IEnumerable<ObtenerSegurosClienteResponse>> ObtenerSegurosCliente(ObtenerSegurosClienteRequest model);
	}

	public class PruebaService : IPruebaService
	{
		private readonly IPruebaRepository _Repository;

		public PruebaService(IPruebaRepository repository)
		{
			_Repository = repository;
		}

		public async Task<IEnumerable<SystemParameterGetByReferenceResponse>> GetPrueba()
		{
			return await _Repository.GetPrueba();
		}
		public async Task<IEnumerable<ObtenerSegurosClienteResponse>> ObtenerSegurosCliente(ObtenerSegurosClienteRequest model)
		{
			return await _Repository.ObtenerSegurosClienteRepository(model);
		}
	}
}
