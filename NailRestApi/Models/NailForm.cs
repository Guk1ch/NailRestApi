namespace NailRestApi.Models
{
	public class NailForm
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public virtual ICollection<Nail> Nails { get; } = new List<Nail>();
    }
}
