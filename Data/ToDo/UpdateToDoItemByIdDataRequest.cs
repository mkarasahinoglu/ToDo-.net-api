using Dapper;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.ToDo;

namespace ToDo_API_SR.Data.ToDo
{
	public interface IUpdateToDoItemByIdDataRequest
	{
		Task<bool> UpdateToDoItemById(InsertToDoItemDataModel model, int id);
	}
	public class UpdateToDoItemByIdDataRequest: IUpdateToDoItemByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public UpdateToDoItemByIdDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection=databaseConnection;
		}

		public async Task<bool> UpdateToDoItemById(InsertToDoItemDataModel model,int id)
		{
			var query = $"update ToDo set Title=@Title, IsDone=@IsDone, Progress=@Progress, UserId=@UserId where Id={id}";
			var conn=_databaseConnection.GetConnection();
			var response=await conn.ExecuteAsync(query,model);
			return response > 0;
		}
	}
}
