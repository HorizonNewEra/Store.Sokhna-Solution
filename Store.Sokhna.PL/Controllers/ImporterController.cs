using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.DAL.Models;

namespace Store.Sokhna.PL.Controllers
{
    public class ImporterController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public ImporterController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            TempData["Importers"] = await _UnitofWork.importersRepository.Getall();
            return View();
        }
        public async Task<IActionResult> Create(Importers model)
        {
            if (ModelState.IsValid)
            {
                await _UnitofWork.importersRepository.Add(model);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Importers model)
        {
            if (ModelState.IsValid)
            {
               _UnitofWork.importersRepository.Update(model);
            }
            return RedirectToAction(nameof(Index));
        }
        public  IActionResult Delete(Importers model)
        {
            if (ModelState.IsValid)
            {
                _UnitofWork.importersRepository.Delete(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
