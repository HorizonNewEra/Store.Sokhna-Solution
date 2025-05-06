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
    public class PactRepository : IRepository<Pact>
    {
        private readonly AppDbContext _context;
        public PactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pact>> Getall()
        {
           return await _context.Pacts.Include(p => p.Engineer).ToListAsync();
        }
        public IEnumerable<Pact> Getalll()
        {
            return _context.Pacts.Include(p => p.Engineer).ToList();
        }
        public async Task<Pact?> GetById(int? Id)
        {
            return await _context.Pacts.Include(p => p.Engineer).FirstOrDefaultAsync(e => e.Pact_ID == Id);
        }
        public Pact? GetByIdd(int? Id)
        {
            return _context.Pacts.Include(p => p.Engineer).FirstOrDefault(e => e.Pact_ID == Id);
        }
        public async Task<int> Add(Pact entity)
        {
            await _context.Pacts.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public int Update(Pact entity)
        {
            _context.Pacts.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(Pact entity)
        {
            _context.Pacts.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
