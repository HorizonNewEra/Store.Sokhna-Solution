using Microsoft.EntityFrameworkCore;
using Store.Sokhna.DAL.Data.Contexts;

namespace Store.Sokhna.PL.HelperClasses
{
	public static class Helpers
	{
		public static readonly AppDbContext _context;
		public static DateTime ServerDate()
		{
			DateTime currentDate= DateTime.Now;
			try
			{
				 currentDate =DateTime.Parse(_context.Userss.FromSqlRaw("SELECT GETDATE()").FirstOrDefault().ToString());
			}
			catch { }
			return currentDate;
		}
	}
}
