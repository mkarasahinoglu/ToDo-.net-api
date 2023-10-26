using Dapper;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.User;

namespace ToDo_API_SR.Data.User
{
    public interface IUpdateUserByIdDataRequest
	{
		Task<bool> UpdateUserById(UpdateUserDataModel model, int id);
	}
	public class UpdateUserByIdDataRequest:IUpdateUserByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public UpdateUserByIdDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection=databaseConnection;
		}

		public async Task<bool> UpdateUserById(UpdateUserDataModel model,int id)
		{
			var query = $"update [User] set UserName=@UserName, Password=@Password where Id={id}";
			var conn= _databaseConnection.GetConnection();
			var response=await conn.ExecuteAsync(query,model);
			return response > 0;
		}
	}
}
