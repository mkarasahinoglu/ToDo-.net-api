using Dapper;
using System.Diagnostics;
using ToDo_API_SR.Data.SubToDo;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.ToDo;

namespace ToDo_API_SR.Data.ToDo
{
	public interface ISwitchToDoIsDoneByIdDataRequest
	{
		public Task<bool> SwitchToDoIsDoneById(SwitchToDoIsDoneDataModel model,int id);
	}
	public class SwitchToDoIsDoneByIdDataRequest:ISwitchToDoIsDoneByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		private readonly ISwitchAllSubToDoIsDoneDataRequest _switchAllSubToDoIsDoneDataRequest;

		public SwitchToDoIsDoneByIdDataRequest(IDatabaseConnection databaseConnection,ISwitchAllSubToDoIsDoneDataRequest switchAllSubToDoIsDoneData)
		{
			_databaseConnection = databaseConnection;
			_switchAllSubToDoIsDoneDataRequest = switchAllSubToDoIsDoneData;
		}

		public async Task<bool> SwitchToDoIsDoneById(SwitchToDoIsDoneDataModel model,int id)
		{
			var control = $"select IsDone from ToDo where Id={id}";
			var conn = _databaseConnection.GetConnection();
			var _control=(bool)conn.ExecuteScalar(control);
			if (!(model.IsDone == _control))
			{
				var isDone = 0;
				if (model.IsDone == true) isDone = 1;
				else isDone = 0;
				var query = $"update ToDo set IsDone=@IsDone, Progress={isDone*100} where Id={id}";
				var response = await conn.ExecuteAsync(query, model);
				
				var response_SwitchAllSubToDoIsDone = await _switchAllSubToDoIsDoneDataRequest.SwitchAllSubToDoIsDone(isDone,id);
				return response > 0 && response_SwitchAllSubToDoIsDone;
			}
			else return false;
			
			
			
		}
	}
}
