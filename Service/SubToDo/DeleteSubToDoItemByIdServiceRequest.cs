using ToDo_API_SR.Data.SubToDo;

namespace ToDo_API_SR.Service.SubToDo
{
	public interface IDeleteSubToDoItemByIdServiceRequest
	{
		Task<bool> DeleteSubToDoItemById(int id);
	}
	public class DeleteSubToDoItemByIdServiceRequest: IDeleteSubToDoItemByIdServiceRequest
	{
		private readonly IDeleteSubToDoItemByIdDataRequest _deleteSubToDoItemByIdDataRequest;
		public DeleteSubToDoItemByIdServiceRequest(IDeleteSubToDoItemByIdDataRequest deleteSubToDoItemByIdDataRequest)
		{
			_deleteSubToDoItemByIdDataRequest= deleteSubToDoItemByIdDataRequest;
		}

		public async Task<bool> DeleteSubToDoItemById(int id)
		{
			return await _deleteSubToDoItemByIdDataRequest.DeleteSubToDoItemById(id);
		}
	}
}
