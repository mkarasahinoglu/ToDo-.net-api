using ToDo_API_SR.Data.ToDo;
using ToDo_API_SR.Model.ToDo;

namespace ToDo_API_SR.Service.ToDo
{
	public interface IInsertToDoItemServiceRequest
	{
		Task<bool> InsertToDoItem(InsertToDoItemDataModel model);
	}
	public class InsertToDoItemServiceRequest: IInsertToDoItemServiceRequest
	{
		private readonly IInsertToDoItemDataRequest _insertToDoItemDataRequest;
		public InsertToDoItemServiceRequest(IInsertToDoItemDataRequest insertToDoItemDataRequest)
		{
			_insertToDoItemDataRequest=insertToDoItemDataRequest;
		}

		public async Task<bool> InsertToDoItem(InsertToDoItemDataModel model)
		{
			return await _insertToDoItemDataRequest.InsertToDoItem(model);
		}
	}
}
