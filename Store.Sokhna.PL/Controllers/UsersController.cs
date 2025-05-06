using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.BLL.Repositories;
using Store.Sokhna.DAL.Models;

namespace Store.Sokhna.PL.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
		private readonly UserManager<ApplicationUser> _UserManager;
		private readonly SignInManager<ApplicationUser> _SignInManager;
		public UsersController(IUnitofWork unitofWork,
            UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager)
        {
            _UnitofWork = unitofWork;
			_UserManager = userManager;
			_SignInManager = signInManager;
		}
        public async Task<IActionResult> Index(string search)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            var users = Enumerable.Empty<Users>();
            if (string.IsNullOrEmpty(search))
                users = await _UnitofWork.usersRepository.GetUnDeletedUsers();
            else
                users = await _UnitofWork.usersRepository.GetUserNameLike(search);
            return View(users);
        }
        public async Task<IActionResult> Deleted(string search)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            var users = Enumerable.Empty<Users>();
            if (string.IsNullOrEmpty(search))
                users = await _UnitofWork.usersRepository.GetDeletedUsers();
            else
                users = await _UnitofWork.usersRepository.GetUserNameLike(search);
            return View(users);
        }
        public async Task<IActionResult> Restore(string? id)
        {
            var user = await _UnitofWork.usersRepository.GetBySSN(id);
            user.Deleted = "F";
            var count = _UnitofWork.usersRepository.Update(user);
            if (count > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Deleted));
        }
        [HttpGet]
        public IActionResult Create()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Users model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            if (ModelState.IsValid)
            {
                var getemp= await _UnitofWork.usersRepository.GetBySSN(model.SSN);
                if (getemp is not null)
                {
                    if (getemp.Deleted == "T")
                        ModelState.AddModelError(string.Empty, "هذا الحساب موجود بالفعل و غير مفعل");
                    else
                        ModelState.AddModelError(string.Empty, "هذا الحساب موجود بالفعل");
                }
                else
                {
                    if (model.Deleted == null)
                        model.Deleted = "F";
                    if (model.DateofEmployed == null)
                        model.DateofEmployed = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
                    else
                    {
                        try
                        {
                            DateTime dt = DateTime.Parse(model.DateofEmployed);
                            model.DateofEmployed = $"{dt.Day}/{dt.Month}/{dt.Year}";
                        }
                        catch
                        {
                            model.DateofEmployed = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
                        }
                    }
                    var count = await _UnitofWork.usersRepository.Add(model);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            if (id is null) return BadRequest();
            var user = await _UnitofWork.usersRepository.GetBySSN(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            if (id is null) return BadRequest();
            var user = await _UnitofWork.usersRepository.GetBySSN(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Users model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            if (ModelState.IsValid)
            {
                if (model.Deleted == null)
                    model.Deleted = "F";
                if (model.DateofEmployed == null)
                    model.DateofEmployed = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
                else
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(model.DateofEmployed);
                        model.DateofEmployed = $"{dt.Day}/{dt.Month}/{dt.Year}";
                    }
                    catch
                    {
                        ModelState.AddModelError(string.Empty, "يجب ادخال التاريخ");
                    }
                }
                var count = _UnitofWork.usersRepository.Update(model);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            if (id is null) return BadRequest();
            var user = await _UnitofWork.usersRepository.GetBySSN(id);
            if (user is null) return NotFound();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Users model)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            model.Deleted = "T";
            if (ModelState.IsValid)
            {
                var count = _UnitofWork.usersRepository.Update(model);
                if (count > 0)
                {
					var user = await _UserManager.FindByNameAsync(model.FullName);
                    try
                    {
                        var flag = await _UserManager.DeleteAsync(user);
                        if (flag.Succeeded)
                            return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    
                }
            }
            return View(model);
        }
    }
}
