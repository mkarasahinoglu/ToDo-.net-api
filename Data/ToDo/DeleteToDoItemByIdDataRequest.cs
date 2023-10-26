using Dapper;
using ToDo_API_SR.Data.Utilities;

namespace ToDo_API_SR.Data.ToDo
{
	public interface IDeleteToDoItemByIdDataRequest
	{
		Task<bool> DeleteToDoItemById(int id);
	}
	public class DeleteToDoItemByIdDataRequest: IDeleteToDoItemByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public DeleteToDoItemByIdDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection=databaseConnection;
		}

		public async Task<bool> DeleteToDoItemById(int id)
		{
			var query = $"delete from ToDo where Id={id}";
			var conn=_databaseConnection.GetConnection();
			var response= await conn.ExecuteAsync(query) ;
			return response > 0;
		}
	}
}
