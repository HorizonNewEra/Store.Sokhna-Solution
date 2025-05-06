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
    public class Supplies_OutcomeRepository : IRepository<Supplies_Outcome>
    {
        private readonly AppDbContext _context;
        public Supplies_OutcomeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Supplies_Outcome>> Getall()
        {
            return await _context.Supplies_Outcomes.Where(e => e.Engineer.Job == "Engineer").Include(p => p.Engineer).ToListAsync();
        }
        public async Task<Supplies_Outcome?> GetById(int? Id)
        {
            return await _context.Supplies_Outcomes.Include(p => p.Engineer).FirstOrDefaultAsync(e => e.SO_ID == Id);
        }
        public async Task<int> Add(Supplies_Outcome entity)
        {
            await _context.Supplies_Outcomes.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public int Update(Supplies_Outcome entity)
        {
            _context.Supplies_Outcomes.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(Supplies_Outcome entity)
        {
            _context.Supplies_Outcomes.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
