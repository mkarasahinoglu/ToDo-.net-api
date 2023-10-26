using Dapper;
using System.Data.SqlClient;
using System.Diagnostics;
using ToDo_API_SR.Data.ToDo;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.SubToDo;
using ToDo_API_SR.Model.ToDo;

namespace ToDo_API_SR.Data.SubToDo
{
	public interface ISwitchSubToDoIsDoneByIdDataRequest
	{
		Task<bool> SwitchSubToDoIsDoneById(SwitchSubToDoIsDoneDataModel model, int id);
	}
	public class SwitchSubToDoIsDoneByIdDataRequest: ISwitchSubToDoIsDoneByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		private readonly IUpdateToDoProgressDataRequest _updateToDoProgressDataRequest;
		private readonly InsertToDoItemDataModel _insertToDoItemDataModel;
		public SwitchSubToDoIsDoneByIdDataRequest(IDatabaseConnection databaseConnection, IUpdateToDoProgressDataRequest updateToDoProgressDataRequest)
		{
			_databaseConnection = databaseConnection;
			_updateToDoProgressDataRequest = updateToDoProgressDataRequest;
		}

		public async Task<bool> SwitchSubToDoIsDoneById(SwitchSubToDoIsDoneDataModel model,int id)
		{
			
			var query = $"update SubToDo set IsDone=@IsDone where Id={id}";
			var query_ef = $"Select EffectPercentage from SubToDo where Id={id}";
			var query_tdid= $"Select ToDoId from SubToDo where Id={id}";
			var control = $"Select IsDone from SubToDo where Id={id}";
			var conn= _databaseConnection.GetConnection();
			var _control = (bool)conn.ExecuteScalar(control);
			if (!(_control == model.IsDone))
			{
				var response = await conn.ExecuteAsync(query, model);
				var _effectPercentage = (int)conn.ExecuteScalar(query_ef);
				Debug.Print(model.IsDone.ToString());
				if (!model.IsDone) _effectPercentage = _effectPercentage * -1;
				var _ToDoId = (int)conn.ExecuteScalar(query_tdid);
				var response_updateProgress = await _updateToDoProgressDataRequest.UpdateToDoProgress(_effectPercentage, _ToDoId);

				return response > 0 && response_updateProgress;
			}
			else return false;
		}
	}
}
