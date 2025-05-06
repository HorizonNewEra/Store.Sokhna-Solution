using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.BLL.Repositories;
using Store.Sokhna.DAL.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.Sokhna.PL.Controllers
{
    [Authorize]
    public class PactController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public PactController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            string USSN= TempData["SSN"] as string;
            string role= TempData["Role"] as string;
            if(role == "Engineer")
            {
                
                var engpacts = await _UnitofWork.reportsRepository.GetallPactGroup();
                var engp =engpacts.Where(e=>e.SSN == USSN).FirstOrDefault();
                //string remain=engp.
                TempData["PactRemain"] = engp;
                var users = await _UnitofWork.pactRepository.Getall();
                return View(users.Where(u=>u.Engineer.SSN== USSN).ToList());
            }
            else
            {
                var users = await _UnitofWork.pactRepository.Getall();
                return View(users);
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] = await _UnitofWork.usersRepository.GetUnDeletedEngineers();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pact model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] = await _UnitofWork.usersRepository.GetUnDeletedEngineers();
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
                var count = await _UnitofWork.pactRepository.Add(model);
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
            var user = await _UnitofWork.pactRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] = await _UnitofWork.usersRepository.GetUnDeletedEngineers();
            if (id is null) return BadRequest();
            var user = await _UnitofWork.pactRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pact model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
            TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
            ViewData["D1"] = _UnitofWork.usersRepository.GetUnDeletedEngineerss();
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
                var pact = _UnitofWork.pactRepository.GetByIdd(model.Pact_ID);
                if (!pact.Confirmed)
                {
                    model.DateOfConfirmation= $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
                    var count = _UnitofWork.pactRepository.Update(model);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
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
            var user = await _UnitofWork.pactRepository.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Pact model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            var pact = await _UnitofWork.pactRepository.GetById(model.Pact_ID);
            if (!pact.Confirmed)
            {
                var count = _UnitofWork.pactRepository.Delete(model);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
