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
    public class WorkerSalariesRepository : IRepository<WorkersSalaries>
    {
        private readonly AppDbContext _context;
        public WorkerSalariesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<WorkersSalaries>> Getall()
        {
            return await _context.WorkersSalaries.ToListAsync();
        }
        public async Task<WorkersSalaries?> GetById(int? Id)
        {
            return await _context.WorkersSalaries.FirstOrDefaultAsync(e => e.WS_ID == Id);
        }
        public async Task<int> Add(WorkersSalaries entity)
        {
           await _context.WorkersSalaries.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public int Update(WorkersSalaries entity)
        {
            _context.WorkersSalaries.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(WorkersSalaries entity)
        {
            _context.WorkersSalaries.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
