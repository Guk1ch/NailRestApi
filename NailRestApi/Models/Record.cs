namespace NailRestApi.Models
{
	public class Record
	{
		public int Id { get; set; }
		public int? IdClient { get; set; }
		public string Time { get; set; }
        public int Cost { get; set; }
        public bool IsDone { get; set; }
		//новое поле даты
		public string? Date { get; set; }
        
        public virtual Client? IdClientNavigation { get; }
    }
}
