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
    public class ImportersRepository : IRepository<Importers>
    {
        private readonly AppDbContext _context;
        public ImportersRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Importers>> Getall()
        {
            return await _context.Importers.ToListAsync();
        }
        public async Task<Importers?> GetById(int? Id)
        {
            return await _context.Importers.FirstOrDefaultAsync(e => e.Imp_ID == Id);
        }
        public async Task<int> Add(Importers entity)
        {
            await _context.Importers.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public int Update(Importers entity)
        {
            _context.Importers.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(Importers entity)
        {
            _context.Importers.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
