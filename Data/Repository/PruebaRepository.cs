using Dapper;
using Data.Base;
using Model.Request;
using Model.Response;
using System.Data;

namespace Data.Repository
{
	public interface IPruebaRepository
	{
		Task<IEnumerable<SystemParameterGetByReferenceResponse>> GetPrueba();
		Task<IEnumerable<ObtenerSegurosClienteResponse>> ObtenerSegurosClienteRepository(ObtenerSegurosClienteRequest model);
	}
	public class PruebaRepository : IPruebaRepository
	{
		private readonly IConexion _conexion;

		public PruebaRepository(IConexion conexion)
		{
			_conexion = conexion;
		}

		public async Task<IEnumerable<SystemParameterGetByReferenceResponse>> GetPrueba()
		{
			var query = "[Common].[usp_SystemParameterGetbyReference]";

			using var cn = await _conexion.CreateConnectionAsync();

			try
			{
				var result = await cn.QueryAsync<SystemParameterGetByReferenceResponse>(
					query,
					new
					{
						v_GroupsId = "201",
						v_ReferenceId = "",
						v_Visibles = "1",
						v_Status = "1"
					},
					commandType: CommandType.StoredProcedure
				);
				return result;
			}
			catch (Exception ex)
			{
				return Enumerable.Empty<SystemParameterGetByReferenceResponse>();
			}
		}


        public async Task<IEnumerable<ObtenerSegurosClienteResponse>> ObtenerSegurosClienteRepository(ObtenerSegurosClienteRequest model)
        {
            var query = "sp_ConsultarSegurosPorCliente";

            using var cn = await _conexion.CreateConnectionAsync();

            try
            {
                var result = await cn.QueryAsync<ObtenerSegurosClienteResponse>(
                    query,
                    new
                    {
                        model.TipoDocumento,
                        model.NumeroDocumento,
                        model.FechaInicio,
                        model.FechaFin
                    },
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ObtenerSegurosClienteResponse>();
            }
        }
    }
}