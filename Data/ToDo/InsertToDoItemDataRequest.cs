using Dapper;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.ToDo;

namespace ToDo_API_SR.Data.ToDo
{
	public interface IInsertToDoItemDataRequest
	{
		Task<bool> InsertToDoItem(InsertToDoItemDataModel model);
	}
	public class InsertToDoItemDataRequest: IInsertToDoItemDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public InsertToDoItemDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection= databaseConnection;
		}

		public async Task<bool> InsertToDoItem(InsertToDoItemDataModel model)
		{
			var query = "insert into ToDo(Id,Title,IsDone,Progress,UserId) values (@Id,@Title,@IsDone,@Progress,@UserId)";
			var conn = _databaseConnection.GetConnection();
			var response=await conn.ExecuteAsync(query,model);
			return response > 0;
		}
	}
}
