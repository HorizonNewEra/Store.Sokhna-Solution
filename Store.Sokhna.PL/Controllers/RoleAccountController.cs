using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.DAL.Models;

namespace Store.Sokhna.PL.Controllers
{
    [Authorize]
    public class RoleAccountController : Controller
	{
		private readonly RoleManager<IdentityRole> _RoleManager;

		public RoleAccountController(RoleManager<IdentityRole> roleManager)
		{
			_RoleManager = roleManager;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
