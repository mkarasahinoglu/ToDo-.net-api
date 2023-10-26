using Dapper;
using ToDo_API_SR.Data.Utilities;

namespace ToDo_API_SR.Data.SubToDo
{
	public interface IDeleteSubToDoItemByIdDataRequest
	{
		Task<bool> DeleteSubToDoItemById(int id);
	}
	public class DeleteSubToDoItemByIdDataRequest: IDeleteSubToDoItemByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public DeleteSubToDoItemByIdDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection=databaseConnection;
		}

		public async Task<bool> DeleteSubToDoItemById(int id)
		{
			var query = $"delete from SubToDo where Id={id}";
			var conn=_databaseConnection.GetConnection();
			var response= await conn.ExecuteAsync(query) ;
			return response > 0;
		}
	}
}
