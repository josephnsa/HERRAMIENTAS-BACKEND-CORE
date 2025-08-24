using Microsoft.Data.SqlClient;
using System.Data;

namespace Data.Base
{
	public interface IConexion
	{
		Task<IDbConnection> CreateConnectionAsync();
	}
	public class Conexion : IConexion
	{
		private readonly string _connectionString;

		public Conexion(string connectionString)
		{
			_connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
		}

		public async Task<IDbConnection> CreateConnectionAsync()
		{
			var sqlConnection = new SqlConnection(_connectionString);
			await sqlConnection.OpenAsync();
			return sqlConnection;
		}
	}
}
