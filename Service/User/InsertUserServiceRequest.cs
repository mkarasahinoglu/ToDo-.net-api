using ToDo_API_SR.Data.User;
using ToDo_API_SR.Model.User;

namespace ToDo_API_SR.Service.User
{
    public interface IInsertUserServiceRequest
	{
		Task<bool> InserUser(InsertUserDataModel model);
	}
	public class InsertUserServiceRequest: IInsertUserServiceRequest
	{
		private readonly IInsertUserDataRequest _insertUserDataRequest;
		public InsertUserServiceRequest(IInsertUserDataRequest insertUserDataRequest)
		{
			_insertUserDataRequest = insertUserDataRequest;
		}

		public async Task<bool> InserUser(InsertUserDataModel model)
		{
			return await _insertUserDataRequest.InsertUser(model);
		}
	}
}
