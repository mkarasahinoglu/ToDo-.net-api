using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ToDo_API_SR.Data.Utilities
{
	public interface IDatabaseConnection
	{
		IDbConnection GetConnection();
	}
	public class DatabaseConnection:IDatabaseConnection
	{
		private readonly string _connectionString;
		public DatabaseConnection(string connectionString)
		{
			_connectionString= connectionString;
		}

		public IDbConnection GetConnection()
		{
			return new SqlConnection(_connectionString);
		}
	}
}
