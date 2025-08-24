using Data.Repository;
using Model.Response;

namespace Service.Logic
{
	public interface IPruebaService
	{
		Task<IEnumerable<SystemParameterGetByReferenceResponse>> GetPrueba();
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
	}
}
