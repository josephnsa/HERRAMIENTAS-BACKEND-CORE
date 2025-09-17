using Data.Repository;
using Model.Request;
using Model.Response;

namespace Service.Logic
{
    public interface IPruebaService
    {
        Task<IEnumerable<SystemParameterGetByReferenceResponse>> GetPrueba();
        Task<IEnumerable<SeguroClienteResponse>> ConsultarSegurosPorCliente(ObtenerSegurosClienteRequest model);
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

        public async Task<IEnumerable<SeguroClienteResponse>> ConsultarSegurosPorCliente(ObtenerSegurosClienteRequest model)
        {
            return await _Repository.ObtenerSegurosClienteRepository(model);
        }
    }
}
