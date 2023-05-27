namespace NailRestApi.Models
{
	public partial class NailAppContext
	{
		private static NailAppContext _context;
		public static NailAppContext GetContext()
		{
			if (_context == null)
			{
				_context = new NailAppContext();
			}
			return _context;
		}
	}
}
