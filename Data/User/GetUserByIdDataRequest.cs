using Dapper;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.User;

namespace ToDo_API_SR.Data.User
{
    public interface IGetUserByIdDataRequest
	{
		Task<GetUserDataModel> GetUserById(int id);
	}
	public class GetUserByIdDataRequest: IGetUserByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public GetUserByIdDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection= databaseConnection;
		}

		public async Task<GetUserDataModel> GetUserById(int id)
		{
			var query = $"Select * from [User] where Id={id}";
			var conn=_databaseConnection.GetConnection();
			var response= await conn.QueryFirstOrDefaultAsync<GetUserDataModel>(query);
			return response;
		}
	}
}
