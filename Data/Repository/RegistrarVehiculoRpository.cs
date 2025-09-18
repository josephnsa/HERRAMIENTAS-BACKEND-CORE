using Dapper;
using Data.Base;
using Model.Request;
using Model.Response;
using System.Data;

namespace Data.Repository
{
    public interface IVehiculoRepository
    {
        Task<RegistrarVehiculoResponse> RegistrarVehiculoAsync(RegistrarVehiculoRequest model);
    }

    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly IConexion _conexion;

        public VehiculoRepository(IConexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<RegistrarVehiculoResponse> RegistrarVehiculoAsync(RegistrarVehiculoRequest model)
        {
            var query = "sp_RegistrarVehiculo";

            using var cn = await _conexion.CreateConnectionAsync();

            try
            {
                var vehiculoId = await cn.ExecuteScalarAsync<int>(
                    query,
                    new
                    {
                        model.SeguroId,
                        model.Placa,
                        model.Marca,
                        model.Modelo,
                        model.Anio,
                        model.NumeroSerie
                    },
                    commandType: CommandType.StoredProcedure
                );

                return new RegistrarVehiculoResponse
                {
                    VehiculoId = vehiculoId,
                    Mensaje = "Vehículo registrado correctamente"
                };
            }
            catch (Exception ex)
            {
                return new RegistrarVehiculoResponse
                {
                    VehiculoId = 0,
                    Mensaje = $"Error al registrar vehículo: {ex.Message}"
                };
            }
        }
    }
}
