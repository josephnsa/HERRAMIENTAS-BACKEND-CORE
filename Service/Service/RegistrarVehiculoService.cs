using Data.Repository;
using Model.Request;
using Model.Response;

namespace Service.Logic
{
    public interface IVehiculoService
    {
        Task<RegistrarVehiculoResponse> RegistrarVehiculoAsync(RegistrarVehiculoRequest model);
    }

    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<RegistrarVehiculoResponse> RegistrarVehiculoAsync(RegistrarVehiculoRequest model)
        {
            return await _vehiculoRepository.RegistrarVehiculoAsync(model);
        }
    }
}
