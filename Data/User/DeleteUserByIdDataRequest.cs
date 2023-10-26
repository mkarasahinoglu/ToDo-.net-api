using Dapper;
using ToDo_API_SR.Data.Utilities;

namespace ToDo_API_SR.Data.User
{
	public interface IDeleteUserByIdDataRequest
	{
		Task<bool> DeleteUserById(int id);
	}
	public class DeleteUserByIdDataRequest: IDeleteUserByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public DeleteUserByIdDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection=databaseConnection;
		}

		public async Task<bool> DeleteUserById(int id)
		{
			var query = $"Delete from [User] where Id={id}";
			var conn=_databaseConnection.GetConnection();
			var response= await conn.ExecuteAsync(query) ;
			return response > 0;
		}
	}
}
