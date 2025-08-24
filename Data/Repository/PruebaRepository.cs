using Dapper;
using Data.Base;
using Model.Response;
using System.Data;

namespace Data.Repository
{
	public interface IPruebaRepository
	{
		Task<IEnumerable<SystemParameterGetByReferenceResponse>> GetPrueba();
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
	}
}
