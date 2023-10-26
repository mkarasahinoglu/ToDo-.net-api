using Dapper;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.ToDo;

namespace ToDo_API_SR.Data.ToDo
{
	public interface IGetToDoItemByIdDataRequest
	{
		Task<GetToDoItemDataModel> GetToDoItemById(int id);
	}
	public class GetToDoItemByIdDataRequest:IGetToDoItemByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public GetToDoItemByIdDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection=databaseConnection;
		}

		public async Task<GetToDoItemDataModel> GetToDoItemById(int id)
		{
			var query = $"select * from ToDo where Id={id}";
			var conn = _databaseConnection.GetConnection();
			var response=await conn.QueryFirstOrDefaultAsync<GetToDoItemDataModel>(query);
			return response;
		}
	}
}
