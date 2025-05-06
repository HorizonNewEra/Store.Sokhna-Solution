using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Sokhna.BLL;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.PL.Models;
using System.Diagnostics;

namespace Store.Sokhna.PL.Controllers
{
	[Authorize]
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IUnitofWork _UnitofWork;
		public HomeController(ILogger<HomeController> logger, IUnitofWork unitofWork)
        {
            _logger = logger;
			_UnitofWork = unitofWork;
		}

        public IActionResult Index()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            return View();
        }

        public IActionResult Privacy()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
