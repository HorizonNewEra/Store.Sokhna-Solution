using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.DAL.Models;
using Store.Sokhna.PL.Models;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.Sokhna.PL.Controllers
{
    public class FinancialsController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public FinancialsController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }
        public IActionResult Index()
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            return View();
        }
        public async Task<IActionResult> DailyFees(string datepicker)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            string date = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
            if (datepicker is not null)
            {
                DateTime D=DateTime.Parse(datepicker);
                date = $"{D.Day}/{D.Month}/{D.Year}";
            }
            var equipments = await _UnitofWork.equipmentsRepository.Getall();
            equipments = equipments.Where(x => x.DateOfAdding == date);
            TempData["equipment"] = equipments;
            var bills = await _UnitofWork.supplies_OutcomeRepository.Getall();
            bills = bills.Where(x => x.DateOfAdding == date);
            TempData["bills"] = bills;
            var expenses = await _UnitofWork.expensesRepository.Getall();
            expenses = expenses.Where(x => x.DateOfAdding == date);
            TempData["expenses"] = expenses;
            var pacts = await _UnitofWork.pactRepository.Getall();
            pacts = pacts.Where(x => x.DateOfAdding == date);
            TempData["pacts"] = pacts;
            float PactSum = 0, ExpensesSum = 0, EquipmentsSum = 0, SuppliesSum = 0;
            foreach (var p in pacts)
            {
                PactSum += p.Value;
            }
            foreach (var p in expenses)
            {
                ExpensesSum += p.Value;
            }
            foreach (var p in equipments)
            {
                EquipmentsSum += p.TotalPrice;
            }
            foreach (var p in bills)
            {
                SuppliesSum += p.Price;
            }
            TempData["PactSum"] = PactSum;
            TempData["ExpensesSum"] = ExpensesSum;
            TempData["EquipmentsSum"] = EquipmentsSum;
            TempData["SuppliesSum"] = SuppliesSum;
            return View();
        }
        public async Task<IActionResult> TrialBalance(string yearpicker)
        {
            TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
            //IEnumerable<TrialBalanceModel> Balance=Enumerable.Empty< TrialBalanceModel>();
            List<TrialBalanceModel> Balance = new List<TrialBalanceModel>();
            string year = DateTime.Now.Year.ToString();
            if (yearpicker is not null)
            {
                year = yearpicker;
            }
            for (int i = 1; i <= 12; i++)
            {
                string date = $"/{i}/{year}";
                var eql = await _UnitofWork.equipmentsRepository.Getall();
                var eq = eql.Where(x => x.DateOfAdding.Contains(date)).Sum(y => y.TotalPrice);

                var exl = await _UnitofWork.expensesRepository.Getall();
                var ex = exl.Where(x => x.DateOfAdding.Contains(date)).Sum(y => y.Value);

                var ptl = await _UnitofWork.pactRepository.Getall();
                var pt = ptl.Where(x => x.DateOfAdding.Contains(date)).Sum(y => y.Value);

                var spl = await _UnitofWork.supplies_OutcomeRepository.Getall();
                var sp = spl.Where(x => x.DateOfAdding.Contains(date)).Sum(y => y.Price);

                Balance.Add(new TrialBalanceModel
                {
                    Month = i,
                    TEquipments = eq,
                    TExpenses=ex,
                    TPact=pt,
                    TSupplies=sp
                    });
            }
            Balance.Add(new TrialBalanceModel
            {
                Month = 13,
                TEquipments = Balance.Sum(x=>x.TEquipments),
                TExpenses = Balance.Sum(x => x.TExpenses),
                TPact = Balance.Sum(x => x.TPact),
                TSupplies = Balance.Sum(x => x.TSupplies)
            });
            return View(Balance);

        }
    }
}
