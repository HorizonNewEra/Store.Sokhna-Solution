using Microsoft.EntityFrameworkCore;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.DAL.Data.Contexts;
using Store.Sokhna.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.BLL.Repositories
{
    public class Supplies_IncomeRepository : IRepository<Supplies_Income>
    {
        private readonly AppDbContext _context;
        public Supplies_IncomeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Supplies_Income>> Getall()
        {
            return await _context.Supplies_Incomes.Include(p => p.Engineer).ToListAsync();
        }
        public async Task<Supplies_Income?> GetById(int? Id)
        {
            return await _context.Supplies_Incomes.Include(p => p.Engineer).FirstOrDefaultAsync(e => e.SI_ID == Id);
        }
        public async Task<int> Add(Supplies_Income entity)
        {
            await _context.Supplies_Incomes.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public int Update(Supplies_Income entity)
        {
            _context.Supplies_Incomes.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(Supplies_Income entity)
        {
            _context.Supplies_Incomes.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
