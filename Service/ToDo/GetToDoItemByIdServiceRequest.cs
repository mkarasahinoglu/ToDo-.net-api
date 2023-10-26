using ToDo_API_SR.Data.ToDo;
using ToDo_API_SR.Model.ToDo;

namespace ToDo_API_SR.Service.ToDo
{
	public interface IGetToDoItemByIdServiceRequest
	{
		Task<GetToDoItemDataModel> GetToDoItemById(int id);
	}
	public class GetToDoItemByIdServiceRequest:IGetToDoItemByIdServiceRequest
	{
		private readonly IGetToDoItemByIdDataRequest _getToDoItemByIdDataRequest;
		public GetToDoItemByIdServiceRequest(IGetToDoItemByIdDataRequest getToDoItemByIdDataRequest)
		{
			_getToDoItemByIdDataRequest=getToDoItemByIdDataRequest;
		}

		public async Task<GetToDoItemDataModel> GetToDoItemById(int id)
		{
			return await _getToDoItemByIdDataRequest.GetToDoItemById(id);
		}
	}
}
