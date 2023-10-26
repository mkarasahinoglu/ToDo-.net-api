using Dapper;
using ToDo_API_SR.Data.Utilities;

namespace ToDo_API_SR.Data.ToDo
{
	public interface ISwitchToDoIsDoneDataRequest
	{
		public Task<bool> SwitchToDoIsDone(int id);
	}
	public class SwitchToDoIsDoneDataRequest:ISwitchToDoIsDoneDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public SwitchToDoIsDoneDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<bool> SwitchToDoIsDone(int id)
		{
			var percentage = $"select Progress from ToDo where Id={id}";
			var conn =_databaseConnection.GetConnection();
			var _percentage = (int)conn.ExecuteScalar(percentage);
			var percentage_value = 0;
			if (_percentage == 100) percentage_value = 1;
			else percentage_value = 0;

			var query = $"update ToDo set IsDone={percentage_value} where Id={id}";
			var response = await conn.ExecuteAsync(query);
			return response > 0;
		}
	}
}
