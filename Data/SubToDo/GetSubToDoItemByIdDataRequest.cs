using Dapper;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.SubToDo;
using ToDo_API_SR.Model.ToDo;

namespace ToDo_API_SR.Data.SubToDo
{
	public interface IGetSubToDoItemByIdDataRequest
	{
		Task<GetSubToDoItemDataModel> GetSubToDoItemById(int id);
	}
	public class GetSubToDoItemByIdDataRequest: IGetSubToDoItemByIdDataRequest
	{
		private readonly IDatabaseConnection _databaseConnection;
		public GetSubToDoItemByIdDataRequest(IDatabaseConnection databaseConnection)
		{
			_databaseConnection=databaseConnection;
		}

		public async Task<GetSubToDoItemDataModel> GetSubToDoItemById(int id)
		{
			var query = $"select * from SubToDo where Id={id}";
			var conn=_databaseConnection.GetConnection();
			var response= await conn.QueryFirstOrDefaultAsync<GetSubToDoItemDataModel>(query);
			return response;
		}
	}
}
