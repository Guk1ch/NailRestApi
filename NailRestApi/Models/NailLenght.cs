namespace NailRestApi.Models
{
	public class NailLenght
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Nail> Nails { get;} = new List<Nail>();
    }
}
