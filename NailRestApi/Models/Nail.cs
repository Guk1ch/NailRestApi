namespace NailRestApi.Models
{
	public class Nail
	{
		public int Id { get; set; }
		public int IdForm { get; set; }

        public string? Image { get; set; }
        public int IdLenght { get; set; }
        public virtual NailForm IdFormNavigation { get; set; }
        public virtual NailLenght IdLenghtNavigation { get; set; }

    }
}
