namespace NailRestApi.Models
{
	public class Client
	{
		public int Id { get; set; }
		public string? FullName { get; set; }
		public string? UserKey { get; set; }
		public string? Phone { get; set; }

        public virtual ICollection<Record> Records { get; } = new List<Record>();
        
    }
}
