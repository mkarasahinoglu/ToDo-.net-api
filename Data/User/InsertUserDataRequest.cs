using Dapper;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.User;

namespace ToDo_API_SR.Data.User
{
    public interface IInsertUserDataRequest
	{
		Task<bool> InsertUser(InsertUserDataModel model);
	}
	public class InsertUserDataRequest: IInsertUserDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public InsertUserDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection= databaseConnection;
		}

		public async Task<bool> InsertUser(InsertUserDataModel model)
		{
			var query = "insert into [User](Id,UserName,Password) values (@Id,@UserName, @Password)";
			var conn= _databaseConnection.GetConnection();
			var response= await conn.ExecuteAsync(query,model);
			return response > 0;
		}
	}
}
