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
    public class ExpensesRepository:IRepository<Expenses>
    {
        private readonly AppDbContext _context;
        public ExpensesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Expenses>> Getall()
        {
            return await _context.Expensess.Include(p => p.Engineer).ToListAsync();
        }
        public async Task<Expenses?> GetById(int? Id)
        {
            return await _context.Expensess.Include(p => p.Engineer).FirstOrDefaultAsync(e => e.Exp_ID == Id);
        }
        public async Task<int> Add(Expenses entity)
        {
            await _context.Expensess.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public int Update(Expenses entity)
        {
            _context.Expensess.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(Expenses entity)
        {
            _context.Expensess.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
