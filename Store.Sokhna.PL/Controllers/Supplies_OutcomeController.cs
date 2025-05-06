using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.BLL.Repositories;
using Store.Sokhna.DAL.Models;
using Store.Sokhna.PL.HelperClasses;
using System.Reflection.Metadata;

namespace Store.Sokhna.PL.Controllers
{
	[Authorize]
	public class Supplies_OutcomeController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public Supplies_OutcomeController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            var users =await _UnitofWork.supplies_OutcomeRepository.Getall();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] =await _UnitofWork.usersRepository.GetUnDeletedUsers();
            ViewData["D2"] =await _UnitofWork.importersRepository.Getall();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplies_Outcome model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] =await _UnitofWork.usersRepository.GetUnDeletedUsers();
            ViewData["D2"] =await _UnitofWork.importersRepository.Getall();
            if (ModelState.IsValid)
            {
                if(model.Image is not null)
                    model.ImageName= DocumentSetting.Upload(model.Image, "images");
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
                var count =await _UnitofWork.supplies_OutcomeRepository.Add(model);
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
            var user =await _UnitofWork.supplies_OutcomeRepository.GetById(id);
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
            ViewData["D2"] =await  _UnitofWork.importersRepository.Getall();
            if (id is null) return BadRequest();
            var user = await _UnitofWork.supplies_OutcomeRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Supplies_Outcome model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] =await _UnitofWork.usersRepository.GetUnDeletedUsers();
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
                        ModelState.AddModelError(string.Empty, "يجب ادخال التاريخ");
                    }
                }
                var count = _UnitofWork.supplies_OutcomeRepository.Update(model);
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
            var user =await _UnitofWork.supplies_OutcomeRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Supplies_Outcome model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            var count = _UnitofWork.supplies_OutcomeRepository.Delete(model);
            if (count > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
