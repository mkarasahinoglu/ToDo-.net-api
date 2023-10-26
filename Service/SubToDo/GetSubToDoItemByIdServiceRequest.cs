using ToDo_API_SR.Data.SubToDo;
using ToDo_API_SR.Model.SubToDo;

namespace ToDo_API_SR.Service.SubToDo
{
	public interface IGetSubToDoItemByIdServiceRequest
	{
		Task<GetSubToDoItemDataModel> GetSubToDoItemById(int id);
	}
	public class GetSubToDoItemByIdServiceRequest:IGetSubToDoItemByIdServiceRequest
	{
		private readonly IGetSubToDoItemByIdDataRequest _getSubToDoItemByIdDataRequest;
		public GetSubToDoItemByIdServiceRequest(IGetSubToDoItemByIdDataRequest getSubToDoItemByIdDataRequest)
		{
			_getSubToDoItemByIdDataRequest= getSubToDoItemByIdDataRequest;
		}

		public async Task<GetSubToDoItemDataModel> GetSubToDoItemById(int id)
		{
			return await _getSubToDoItemByIdDataRequest.GetSubToDoItemById(id);
		}
	}
}
