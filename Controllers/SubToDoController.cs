using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using ToDo_API_SR.Model.SubToDo;
using ToDo_API_SR.Service.SubToDo;

namespace ToDo_API_SR.Controllers
{
	[Controller]
	[Route("api/[controller]")]
	public class SubToDoController : Controller
	{
		private readonly IGetSubToDoItemByIdServiceRequest _getSubToDoItemByIdServiceRequest;
		private readonly IInsertSubToDoItemServiceRequest _insertSubToDoItemServiceRequest;
		private readonly IDeleteSubToDoItemByIdServiceRequest _deleteSubToDoItemByIdServiceRequest;
		private readonly IUpdateSubToDoItemByIdServiceRequest _updateSubToDoItemByIdServiceRequest;
		private readonly ISwitchSubToDoIsDoneByIdServiceRequest _switchSubToDoIsDoneByIdServiceRequest;
		public SubToDoController(
			IGetSubToDoItemByIdServiceRequest getSubToDoItemByIdServiceRequest,
			IInsertSubToDoItemServiceRequest insertSubToDoItemServiceRequest,
			IDeleteSubToDoItemByIdServiceRequest deleteSubToDoItemByIdServiceRequest,
			IUpdateSubToDoItemByIdServiceRequest updateSubToDoItemByIdServiceRequest,
			ISwitchSubToDoIsDoneByIdServiceRequest switchSubToDoIsDoneByIdServiceRequest
			)
		{
			_getSubToDoItemByIdServiceRequest= getSubToDoItemByIdServiceRequest;
			_insertSubToDoItemServiceRequest= insertSubToDoItemServiceRequest;
			_deleteSubToDoItemByIdServiceRequest= deleteSubToDoItemByIdServiceRequest;
			_updateSubToDoItemByIdServiceRequest = updateSubToDoItemByIdServiceRequest;
			_switchSubToDoIsDoneByIdServiceRequest= switchSubToDoIsDoneByIdServiceRequest;
		}

		[HttpGet("SubToDoItemId={id}")]
		public async Task<GetSubToDoItemDataModel> GetSubToDoItemById(int id)
		{
			return await _getSubToDoItemByIdServiceRequest.GetSubToDoItemById(id);
		}

		[HttpPut("InsertSubToDoItem")]
		public async Task<bool> InsertSubToDoItem(InsertSubToDoItemDataModel model)
		{
			return await _insertSubToDoItemServiceRequest.InsertSubToDoItem(model);
		}

		[HttpDelete("DeleteSubToDoItem")]
		public async Task<bool> DeleteSubToDoItemById(int id)
		{
			return await _deleteSubToDoItemByIdServiceRequest.DeleteSubToDoItemById(id);
		}

		[HttpPost("UpdateSubToDoItem")]
		public async Task<bool> UpdateSubToDoItemById(InsertSubToDoItemDataModel model,int id)
		{
			return await _updateSubToDoItemByIdServiceRequest.UpdateSubToDoItemById(model, id);
		}

		[HttpPost("SwitchSubToDoIsDoneById")]
		public async Task<bool> SwitchSubToDoIsDoneById(SwitchSubToDoIsDoneDataModel model, int id)
		{
			return await _switchSubToDoIsDoneByIdServiceRequest.SwitchSubToDoIsDoneById(model, id);
		}
	}
}
