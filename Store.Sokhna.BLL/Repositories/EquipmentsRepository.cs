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
    public class EquipmentsRepository : IRepository<Equipments>
    {
        private readonly AppDbContext _context;
        public EquipmentsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Equipments>> Getall()
        {
            return await _context.Equipmentss.Include(p => p.Engineer).ToListAsync();
        }
        public async Task<Equipments?> GetById(int? Id)
        {
            return await _context.Equipmentss.Include(p => p.Engineer).FirstOrDefaultAsync(e => e.Eq_ID == Id);
        }
        public async Task<int> Add(Equipments entity)
        {
            await _context.Equipmentss.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public int Update(Equipments entity)
        {
            _context.Equipmentss.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(Equipments entity)
        {
            _context.Equipmentss.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
