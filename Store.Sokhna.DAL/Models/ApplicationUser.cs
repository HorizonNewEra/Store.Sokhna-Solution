using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Models
{
	public class ApplicationUser:IdentityUser
	{
        public string Serial { get; set; }
        public string FullName { get; set; }
        public bool RememberMe { get; set; }
		public string Role { get; set; }
	}
}
