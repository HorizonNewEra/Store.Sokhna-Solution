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
    public class WorkersRepository : IRepository<Workers>
    {
        private readonly AppDbContext _context;
        public WorkersRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Workers>> Getall()
        {
            return await _context.Workers.ToListAsync();
        }
        public async Task<Workers?> GetById(int? Id)
        {
            return await _context.Workers.FirstOrDefaultAsync(e => e.W_ID == Id);
        }
        public async Task<int> Add(Workers entity)
        {
            await _context.Workers.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public int Update(Workers entity)
        {
            _context.Workers.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(Workers entity)
        {
            _context.Workers.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
