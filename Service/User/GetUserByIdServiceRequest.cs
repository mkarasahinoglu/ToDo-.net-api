using ToDo_API_SR.Data.User;
using ToDo_API_SR.Model.User;

namespace ToDo_API_SR.Service.User
{
    public interface IGetUserByIdServiceRequest
	{
		Task<GetUserDataModel> GetUserById(int id);
	}
	public class GetUserByIdServiceRequest: IGetUserByIdServiceRequest
	{
		private readonly IGetUserByIdDataRequest _getUserByIdDataRequest;
		public GetUserByIdServiceRequest(IGetUserByIdDataRequest getUserByIdDataRequest)
		{
			_getUserByIdDataRequest = getUserByIdDataRequest;
		}

		public async Task<GetUserDataModel> GetUserById(int id)
		{
			return await _getUserByIdDataRequest.GetUserById(id);
		}
	}
}
