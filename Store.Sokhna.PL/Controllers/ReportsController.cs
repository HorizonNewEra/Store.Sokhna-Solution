using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Sokhna.BLL.Interfaces;

namespace Store.Sokhna.PL.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public ReportsController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PactReport()
        {
            var users = await _UnitofWork.reportsRepository.GetallPactGroup();
            return View(users); 
        }
        public async Task<IActionResult> PactDetails(string Id)
        {
            var pacts = await _UnitofWork.reportsRepository.GetallPactBySSN(Id);
            TempData["Pact"] = pacts;
            var Expenses = await _UnitofWork.reportsRepository.GetallExpensesBySSN(Id);
            TempData["Expenses"] = Expenses;
            var Equipments = await _UnitofWork.reportsRepository.GetallEquipmentsBySSN(Id);
            TempData["Equipments"] = Equipments;
            var Supplies_Outcome = await _UnitofWork.reportsRepository.GetallSupplies_OutcomesBySSN(Id);
            TempData["Supplies_Outcome"] = Supplies_Outcome;
            float PactSum=0, ExpensesSum=0, EquipmentsSum=0, SuppliesSum=0;
            foreach (var p in pacts)
            {
                PactSum += p.Value;
            }
            foreach (var p in Expenses)
            {
                ExpensesSum += p.Value;
            }
            foreach (var p in Equipments)
            {
                EquipmentsSum += p.TotalPrice;
            }
            foreach (var p in Supplies_Outcome)
            {
                SuppliesSum += p.Price;
            }
            TempData["PactSum"] = PactSum;
            TempData["ExpensesSum"] = ExpensesSum;
            TempData["EquipmentsSum"] = EquipmentsSum;
            TempData["SuppliesSum"] = SuppliesSum;
            return View();
        }


        public async Task<IActionResult> SuppliesInDetails()
        {
            var users = await _UnitofWork.reportsRepository.GetallSuppliesInGroup();
            return View(users);
        }
        public async Task<IActionResult> SuppliesInReport(string Id)
        {
            var Supplies_Income = await _UnitofWork.reportsRepository.GetallSuppliesInByImporter(Id);
            TempData["Supplies_Income"] = Supplies_Income;
            var Equipments = await _UnitofWork.reportsRepository.GetallEquipmentsByImporter(Id);
            TempData["EquipmentsM"] = Equipments;
            var Supplies_Outcome = await _UnitofWork.reportsRepository.GetallSupplies_OutcomesByImporter(Id);
            TempData["Supplies_OutcomeM"] = Supplies_Outcome;
            float Supplies_IncomeSum = 0, EquipmentsSum = 0, SuppliesSum = 0;
            foreach (var p in Supplies_Income)
            {
                Supplies_IncomeSum += p.Value;
            }
            foreach (var p in Equipments)
            {
                EquipmentsSum += p.TotalPrice;
            }
            foreach (var p in Supplies_Outcome)
            {
                SuppliesSum += p.Price;
            }
            TempData["Supplies_IncomeSum"] = Supplies_IncomeSum;
            TempData["EquipmentsSumM"] = EquipmentsSum;
            TempData["SuppliesSumM"] = SuppliesSum;
            return View();
        }
    }
}
