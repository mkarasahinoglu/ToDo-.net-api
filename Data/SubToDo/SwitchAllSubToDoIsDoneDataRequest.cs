using Dapper;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.SubToDo;

namespace ToDo_API_SR.Data.SubToDo
{
	public interface ISwitchAllSubToDoIsDoneDataRequest
	{
		public Task<bool> SwitchAllSubToDoIsDone(int isDone,int id);
	}
	public class SwitchAllSubToDoIsDoneDataRequest: ISwitchAllSubToDoIsDoneDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;

		public SwitchAllSubToDoIsDoneDataRequest(IDatabaseConnection databaseConnection) 
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<bool> SwitchAllSubToDoIsDone(int isDone,int id)
		{
			var query=$"Update SubToDo set IsDone={isDone} where ToDoId={id}";
			var conn = _databaseConnection.GetConnection();
			var response=await conn.ExecuteAsync(query);
			return response > 0;
		}

	}
}
