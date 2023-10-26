using Microsoft.AspNetCore.Mvc;
using ToDo_API_SR.Model.User;
using ToDo_API_SR.Service.User;

namespace ToDo_API_SR.Controllers
{
    [Controller]
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		private readonly IGetUserByIdServiceRequest _getUserByIdServiceRequest;
		private readonly IInsertUserServiceRequest _insertUserServiceRequest;
		private readonly IDeleteUserByIdServiceRequest _deleteUserByIdServiceRequest;
		private readonly IUpdateUserByIdServiceRequest _updateUserByIdServiceRequest;
		public UserController(
			IGetUserByIdServiceRequest getUserByIdServiceRequest,
			IInsertUserServiceRequest insertUserServiceRequest,
			IDeleteUserByIdServiceRequest deleteUserByIdServiceRequest,
			IUpdateUserByIdServiceRequest updateUserByIdServiceRequest
			)
		{
			_getUserByIdServiceRequest = getUserByIdServiceRequest;
			_insertUserServiceRequest= insertUserServiceRequest;
			_deleteUserByIdServiceRequest= deleteUserByIdServiceRequest;
			_updateUserByIdServiceRequest= updateUserByIdServiceRequest;
		}

		[HttpGet("UserId={id}")]
		public async Task<GetUserDataModel> GetUserById(int id)
		{
			return await _getUserByIdServiceRequest.GetUserById(id);
		}

		[HttpPut("InsertUser")]
		public async Task<bool> InsertUser(InsertUserDataModel model)
		{
			return await _insertUserServiceRequest.InserUser(model);
		}

		[HttpDelete("DeleteUser")]
		public async Task<bool> DeleteUserById(int id)
		{
			return await _deleteUserByIdServiceRequest.DeleteUserById(id);
		}

		[HttpPost("UpdateUser")]
		public async Task<bool> UpdateUserById(UpdateUserDataModel model,int id)
		{
			return await _updateUserByIdServiceRequest.UpdateUserById(model,id);
		}
	}
}
