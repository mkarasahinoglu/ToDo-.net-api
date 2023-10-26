using ToDo_API_SR.Data.User;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Model.User;

namespace ToDo_API_SR.Service.User
{
    public interface IUpdateUserByIdServiceRequest
	{
		Task<bool> UpdateUserById(UpdateUserDataModel model, int id);
	}
	public class UpdateUserByIdServiceRequest:IUpdateUserByIdServiceRequest
	{
		private readonly IUpdateUserByIdDataRequest _updateUserByIdDataRequest;
		public UpdateUserByIdServiceRequest(IUpdateUserByIdDataRequest updateUserByIdDataRequest)
		{
			_updateUserByIdDataRequest=updateUserByIdDataRequest;
		}
		public async Task<bool> UpdateUserById(UpdateUserDataModel model,int id)
		{
			return await _updateUserByIdDataRequest.UpdateUserById(model,id);
		}
	}
}
