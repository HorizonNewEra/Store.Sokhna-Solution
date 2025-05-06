using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Store.Sokhna.PL.Models;

namespace Store.Sokhna.PL.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("error")]
        public IActionResult NotFound()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("error")]
        public IActionResult Error()
        {
            return View("Error");
        }
        [HttpGet("Forbidden")]
        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }
        [HttpGet("Unauthorized")]
        public IActionResult Unauthorized()
        {
            return View("Unauthorized");
        }

    }
}
