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
    public class UserssDatasRepository : IRepository<UserssDatas>
    {
        private readonly AppDbContext _context;
        public UserssDatasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserssDatas>> Getall()
        {
            return await _context.UserssDatas.ToListAsync();
        }
        public async Task<UserssDatas?> GetUnDeletedUsersBySSN(string? id)
        {
            return await _context.UserssDatas.FirstOrDefaultAsync(e => e.SSN == id);
        }
        public async Task<UserssDatas?> GetById(int? Id)
        {
            //return _context.Employees.FirstOrDefault(e=>e.SSN==SSN);
            return await _context.UserssDatas.FindAsync(Id);
        }
        public async Task<UserssDatas?> GetBySSN(string? Id)
        {
            //return _context.Employees.FirstOrDefault(e=>e.SSN==SSN);
            return await _context.UserssDatas.FindAsync(Id);
        }
        public async Task<int> Add(UserssDatas entity)
        {
            await _context.UserssDatas.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public int Update(UserssDatas entity)
        {
            _context.UserssDatas.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(UserssDatas entity)
        {
            _context.UserssDatas.Update(entity);
            return _context.SaveChanges();
        }
    }
}
