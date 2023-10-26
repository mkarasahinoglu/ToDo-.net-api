
using Dapper;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.ToDo;

namespace ToDo_API_SR.Data.ToDo
{
	public interface IUpdateToDoProgressDataRequest
	{
		public Task<bool> UpdateToDoProgress(int effectPercentage,int id);
	}
	public class UpdateToDoProgressDataRequest: IUpdateToDoProgressDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		private readonly ISwitchToDoIsDoneDataRequest _isDoneDataRequest;

		public UpdateToDoProgressDataRequest(IDatabaseConnection databaseConnection, ISwitchToDoIsDoneDataRequest isDoneDataRequest)
		{
			_databaseConnection = databaseConnection;
			_isDoneDataRequest = isDoneDataRequest;
		}

		public async Task<bool> UpdateToDoProgress(int effectPercentage,int id)
		{
			var query = $"update ToDo set Progress=Progress+{effectPercentage} where Id={id}";
			var conn=_databaseConnection.GetConnection();
			var response = await conn.ExecuteAsync(query);
			var response_SwitchIsDone=await _isDoneDataRequest.SwitchToDoIsDone(id);
			return response>0;
		}
	}
}
