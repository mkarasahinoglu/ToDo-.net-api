using ToDo_API_SR.Data.SubToDo;
using ToDo_API_SR.Model.SubToDo;

namespace ToDo_API_SR.Service.SubToDo
{
	public interface IInsertSubToDoItemServiceRequest
	{
		Task<bool> InsertSubToDoItem(InsertSubToDoItemDataModel model);
	}
	public class InsertSubToDoItemServiceRequest: IInsertSubToDoItemServiceRequest
	{
		private readonly IInsertSubToDoItemDataRequest _insertSubToDoItemDataRequest;
		public InsertSubToDoItemServiceRequest(IInsertSubToDoItemDataRequest insertSubToDoItemDataRequest)
		{
			_insertSubToDoItemDataRequest=insertSubToDoItemDataRequest;
		}

		public async Task<bool> InsertSubToDoItem(InsertSubToDoItemDataModel model)
		{
			return await _insertSubToDoItemDataRequest.InsertSubToDoItem(model);
		}
	}
}
