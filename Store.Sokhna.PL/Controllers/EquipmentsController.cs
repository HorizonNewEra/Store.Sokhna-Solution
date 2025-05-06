using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.DAL.Models;
using Store.Sokhna.PL.HelperClasses;

namespace Store.Sokhna.PL.Controllers
{
    [Authorize]
    public class EquipmentsController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public EquipmentsController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            string USSN = TempData["SSN"] as string;
            var users = await _UnitofWork.equipmentsRepository.Getall();
            return View(users.Where(u => u.Engineer.SSN == USSN).ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D2"] = await _UnitofWork.importersRepository.Getall();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Equipments model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D2"] =await _UnitofWork.importersRepository.Getall();
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
                model.TotalPrice = (float)Math.Round((double)model.HourPrice * (double)model.HourCount, 2);
                var count = await _UnitofWork.equipmentsRepository.Add(model);
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
            var user = await _UnitofWork.equipmentsRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D2"] = await _UnitofWork.importersRepository.Getall();
            if (id is null) return BadRequest();
            var user = await _UnitofWork.equipmentsRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Equipments model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D2"] = await _UnitofWork.importersRepository.Getall();
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
                model.TotalPrice = (float)Math.Round((double)model.HourPrice * (double)model.HourCount, 2);
                var count = _UnitofWork.equipmentsRepository.Update(model);
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
            var user = await _UnitofWork.equipmentsRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Equipments model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            var count = _UnitofWork.equipmentsRepository.Delete(model);
            if (count > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
