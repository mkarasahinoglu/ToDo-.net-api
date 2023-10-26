using Dapper;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.SubToDo;

namespace ToDo_API_SR.Data.SubToDo
{
	public interface IInsertSubToDoItemDataRequest
	{
		Task<bool> InsertSubToDoItem(InsertSubToDoItemDataModel model);
	}
	public class InsertSubToDoItemDataRequest: IInsertSubToDoItemDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public InsertSubToDoItemDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection=databaseConnection;
		}

		public async Task<bool> InsertSubToDoItem(InsertSubToDoItemDataModel model)
		{
			var query = "insert into SubToDo(Id,Title, IsDone, EffectPercentage, ToDoId) values(@Id,@Title, @IsDone, @EffectPercentage, @ToDoId)";
			var conn = _databaseConnection.GetConnection();
			var response= await conn.ExecuteAsync(query,model);
			return response > 0;
		}
	}
}
