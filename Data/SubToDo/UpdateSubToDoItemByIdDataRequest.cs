using Dapper;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.SubToDo;

namespace ToDo_API_SR.Data.SubToDo
{
	public interface IUpdateSubToDoItemByIdDataRequest
	{
		Task<bool> UpdateSubToDoItemById(InsertSubToDoItemDataModel model, int id);
	}
	public class UpdateSubToDoItemByIdDataRequest: IUpdateSubToDoItemByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public UpdateSubToDoItemByIdDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection=databaseConnection;
		}

		public async Task<bool> UpdateSubToDoItemById(InsertSubToDoItemDataModel model, int id)
		{
			var query = $"update SubToDo set Title=@Title, IsDone=@IsDone, EffectPercentage=@EffectPercentage, ToDoId=@ToDoId where Id={id}";
			var conn=_databaseConnection.GetConnection();
			var response= await conn.ExecuteAsync(query,model) ;
			return response > 0;
		}
	}
}
