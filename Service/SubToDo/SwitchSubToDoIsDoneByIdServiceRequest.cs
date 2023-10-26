using ToDo_API_SR.Data.SubToDo;
using ToDo_API_SR.Model.SubToDo;

namespace ToDo_API_SR.Service.SubToDo
{
	public interface ISwitchSubToDoIsDoneByIdServiceRequest
	{
		Task<bool> SwitchSubToDoIsDoneById(SwitchSubToDoIsDoneDataModel model, int id);
	}
	public class SwitchSubToDoIsDoneByIdServiceRequest: ISwitchSubToDoIsDoneByIdServiceRequest
	{
		private readonly ISwitchSubToDoIsDoneByIdDataRequest _switchSubToDoIsDoneByIdDataRequest;
		public SwitchSubToDoIsDoneByIdServiceRequest(ISwitchSubToDoIsDoneByIdDataRequest switchSubToDoIsDoneByIdDataRequest)
		{
			_switchSubToDoIsDoneByIdDataRequest= switchSubToDoIsDoneByIdDataRequest;
		}

		public async Task<bool> SwitchSubToDoIsDoneById(SwitchSubToDoIsDoneDataModel model,int id)
		{
			return await _switchSubToDoIsDoneByIdDataRequest.SwitchSubToDoIsDoneById(model,id);
		}
	}
}
