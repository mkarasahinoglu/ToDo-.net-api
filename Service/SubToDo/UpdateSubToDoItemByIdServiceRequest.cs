using ToDo_API_SR.Data.SubToDo;
using ToDo_API_SR.Model.SubToDo;

namespace ToDo_API_SR.Service.SubToDo
{
	public interface IUpdateSubToDoItemByIdServiceRequest
	{
		Task<bool> UpdateSubToDoItemById(InsertSubToDoItemDataModel model, int id);
	}
	public class UpdateSubToDoItemByIdServiceRequest: IUpdateSubToDoItemByIdServiceRequest
	{
		private readonly IUpdateSubToDoItemByIdDataRequest _updateSubToDoItemByIdDataRequest;
		public UpdateSubToDoItemByIdServiceRequest(IUpdateSubToDoItemByIdDataRequest updateSubToDoItemByIdDataRequest)
		{
			_updateSubToDoItemByIdDataRequest=	updateSubToDoItemByIdDataRequest;
		}
		public async Task<bool> UpdateSubToDoItemById(InsertSubToDoItemDataModel model, int id)
		{
			return await _updateSubToDoItemByIdDataRequest.UpdateSubToDoItemById(model, id);
		}
	}
}
