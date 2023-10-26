namespace ToDo_API_SR.Model.ToDo
{
	public class GetToDoItemDataModel
	{
		public int ?Id { get; set; }
		public string ?Title { get; set; }
		public bool ?IsDone { get; set; }
		public int ?Progress { get; set; }
		public int ?UserId { get; set; }
	}
}
