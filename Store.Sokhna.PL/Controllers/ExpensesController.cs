using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.BLL.Repositories;
using Store.Sokhna.DAL.Models;

namespace Store.Sokhna.PL.Controllers
{
	[Authorize]
	public class ExpensesController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public ExpensesController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            string USSN = TempData["SSN"] as string;
            var users =await _UnitofWork.expensesRepository.Getall();
            return View(users.Where(u => u.Engineer.SSN == USSN).ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] =await _UnitofWork.usersRepository.GetUnDeletedUsers();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expenses model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] = await _UnitofWork.usersRepository.GetUnDeletedUsers();
            if (ModelState.IsValid)
            {
                if (model.DateOfAdding == null)
                    model.DateOfAdding = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
                else
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(model.DateOfAdding);
                        model.DateOfAdding = $"{dt.Day}/{dt.Month}/{dt.Year}";
                    }
                    catch
                    {
                        model.DateOfAdding = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
                    }
                }
                var count =await _UnitofWork.expensesRepository.Add(model);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            if (id is null) return BadRequest();
            var user =await _UnitofWork.expensesRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] =await _UnitofWork.usersRepository.GetUnDeletedUsers();
            if (id is null) return BadRequest();
            var user = await _UnitofWork.expensesRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Expenses model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] = await _UnitofWork.usersRepository.GetUnDeletedUsers();
            if (ModelState.IsValid)
            {
                if (model.DateOfAdding == null)
                    model.DateOfAdding = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
                else
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(model.DateOfAdding);
                        model.DateOfAdding = $"{dt.Day}/{dt.Month}/{dt.Year}";
                    }
                    catch
                    {
                        ModelState.AddModelError(string.Empty, "يجب ادخال التاريخ");
                    }
                }
                var count = _UnitofWork.expensesRepository.Update(model);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            if (id is null) return BadRequest();
            var user =await _UnitofWork.expensesRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Expenses model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            var count = _UnitofWork.expensesRepository.Delete(model);
            if (count > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
