using Microsoft.AspNetCore.Mvc;
using ToDo_API_SR.Data.SubToDo;
using ToDo_API_SR.Data.ToDo;
using ToDo_API_SR.Model.ToDo;
using ToDo_API_SR.Service.ToDo;

namespace ToDo_API_SR.Controllers
{
	[Controller]
	[Route("api/[controller]")]
	public class ToDoController : Controller
	{
		private readonly IGetToDoItemByIdServiceRequest _getToDoItemByIdServiceRequest;
		private readonly IInsertToDoItemServiceRequest _insertToDoItemByIdServiceRequest;
		private readonly IDeleteToDoItemByIdServiceRequest _deleteToDoItemByIdServiceRequest;
		private readonly IUpdateToDoItemByIdServiceRequest _updateToDoItemByIdServiceRequest;
		private readonly ISwitchToDoIsDoneByIdDataRequest _switchToDoIsDoneByIdDataRequest;
		public ToDoController(
			IGetToDoItemByIdServiceRequest getToDoItemByIdServiceRequest,
			IInsertToDoItemServiceRequest insertToDoItemServiceRequest,
			IDeleteToDoItemByIdServiceRequest deleteToDoItemByIdServiceRequest,
			IUpdateToDoItemByIdServiceRequest updateToDoItemByIdServiceRequest,
			ISwitchToDoIsDoneByIdDataRequest switchToDoIsDoneByIdDataRequest
			)
		{
			_getToDoItemByIdServiceRequest= getToDoItemByIdServiceRequest;
			_insertToDoItemByIdServiceRequest = insertToDoItemServiceRequest;
			_deleteToDoItemByIdServiceRequest = deleteToDoItemByIdServiceRequest;
			_updateToDoItemByIdServiceRequest= updateToDoItemByIdServiceRequest;
			_switchToDoIsDoneByIdDataRequest = switchToDoIsDoneByIdDataRequest;
	}

		[HttpGet("ToDoItemId={id}")]
		public async Task<GetToDoItemDataModel> GetToDoItemById(int id)
		{
			return await _getToDoItemByIdServiceRequest.GetToDoItemById(id);
		}

		[HttpPut("InsertToDoItem")]
		public async Task<bool> InsertToDoItem(InsertToDoItemDataModel model)
		{
			return await _insertToDoItemByIdServiceRequest.InsertToDoItem(model);
		}

		[HttpDelete("DeleteToDoItem")]
		public async Task<bool> DeleteToDoItemById(int id)
		{
			return await _deleteToDoItemByIdServiceRequest.DeleteToDoItemById(id);
		}

		[HttpPost("UpdateToDoItem")]
		public async Task<bool> UpdateToDoItemById(InsertToDoItemDataModel model,int id)
		{
			return await _updateToDoItemByIdServiceRequest.UpdateToDoItemById(model, id);
		}

		[HttpPost("SwitchToDoIsDoneById")]
		public async Task<bool> SwitchToDoIsDoneById(SwitchToDoIsDoneDataModel model, int id)
		{
			return await _switchToDoIsDoneByIdDataRequest.SwitchToDoIsDoneById(model, id);
		}
	}
}
