using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Sokhna.DAL.Data.Contexts;
using Store.Sokhna.DAL.Models;
using Store.Sokhna.DAL.ModelViews;

namespace Store.Sokhna.BLL.Repositories
{
    public class ReportsRepository
    {
        private readonly AppDbContext _context;
        public ReportsRepository(AppDbContext context)
        {
            _context = context;
        }
        //new
        public async Task<IEnumerable<PactIndex>> GetallPactGroup()
        {
            return await _context.Database.SqlQuery<PactIndex>($@"SELECT * FROM [dbo].[GetallPactsReport]()").ToListAsync();
        }
        public async Task<IEnumerable<SuppliesInIndex>> GetallSuppliesInGroup()
        {
            return await _context.Database.SqlQuery<SuppliesInIndex>($@"select * from [dbo].[GetallImporterReport]()").ToListAsync();
        }
        public async Task<IEnumerable<Pact>> GetallPactBySSN(string SSN)
        {
            var pacts = await _context.Pacts.Include(p => p.Engineer).ToListAsync();
            return pacts.Where(p => p.SSN == SSN);
        }
        public async Task<IEnumerable<Expenses>> GetallExpensesBySSN(string SSN)
        {
            var pacts = await _context.Expensess.Include(p => p.Engineer).ToListAsync();
            return pacts.Where(p => p.SSN == SSN);
        }
        public async Task<IEnumerable<Equipments>> GetallEquipmentsBySSN(string SSN)
        {
            var pacts = await _context.Equipmentss.Include(p => p.Engineer).ToListAsync();
            return pacts.Where(p => p.SSN == SSN);
        }
        public async Task<IEnumerable<Equipments>> GetallEquipmentsByImporter(string Importer)
        {
            var pacts = await _context.Equipmentss.Include(p => p.Engineer).ToListAsync();
            return pacts.Where(p => p.Importer == Importer);
        }
        public async Task<IEnumerable<Supplies_Outcome>> GetallSupplies_OutcomesBySSN(string SSN)
        {
            var pacts = await _context.Supplies_Outcomes.Include(p => p.Engineer).ToListAsync();
            return pacts.Where(p => p.SSN == SSN);
        }
        public async Task<IEnumerable<Supplies_Outcome>> GetallSupplies_OutcomesByImporter(string Importer)
        {
            var pacts = await _context.Supplies_Outcomes.Include(p => p.Engineer).ToListAsync();
            return pacts.Where(p => p.Importer == Importer);
        }
        public async Task<IEnumerable<Supplies_Income>> GetallSuppliesInByImporter(string Importer)
        {
            var pacts = await _context.Supplies_Incomes.Include(p => p.Engineer).ToListAsync();
            return pacts.Where(p => p.Importer == Importer);
        }

    }
}
