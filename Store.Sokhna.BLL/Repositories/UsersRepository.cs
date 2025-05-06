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
    
    public class UsersRepository : IRepository<Users>
    {
        private readonly AppDbContext _context;
        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> Getall()
        {
           return await _context.Userss.ToListAsync();
        }
        public async Task<IEnumerable<Users>> GetDeletedUsers()
        {
            return await _context.Userss.Where(u=>u.Deleted=="T").ToListAsync();
        }
        public async Task<IEnumerable<Users>> GetUnDeletedUsers()
        {
            return await _context.Userss.Where(u => u.Deleted == "F").ToListAsync();
        }
		public async Task<IEnumerable<Users>> GetUnDeletedEngineers()
		{
            return await _context.Userss.Where(u => u.Deleted == "F" && u.Job == "Engineer").ToListAsync();
		}
        public IEnumerable<Users> GetUnDeletedEngineerss()
        {
            return _context.Userss.Where(u => u.Deleted == "F" && u.Job == "Engineer").ToList();
        }
        public async Task<IEnumerable<Users>> GetUnDeletedAccountant()
		{
			return await _context.Userss.Where(u => u.Deleted == "F" && u.Job == "Accountant").ToListAsync();
		}
        public async Task<IEnumerable<Users>> GetUnDeletedManager()
		{
			return await _context.Userss.Where(u => u.Deleted == "F" && u.Job == "Manager").ToListAsync();
		}
		public async Task<Users?> GetUnDeletedUsersBySSN(string? id)
		{
			return await _context.Userss.Where(u => u.Deleted == "F").FirstOrDefaultAsync(e => e.SSN == id);
		}
		public async Task<Users?> GetById(int? Id)
        {
            //return _context.Employees.FirstOrDefault(e=>e.SSN==SSN);
            return await _context.Userss.FindAsync(Id);
        }
        public async Task<Users?> GetBySSN(string? Id)
        {
            //return _context.Employees.FirstOrDefault(e=>e.SSN==SSN);
            return await _context.Userss.FindAsync(Id);
        }
        public async Task<IEnumerable<Users>> GetUserNameLike(string name)
        {
            // return _context.Userss.Where(u => EF.Functions.Like(u.FullName, $"%{name}%"));
            return await _context.Userss.Where(u => u.FullName.ToLower().Contains(name.ToLower())).ToListAsync();
        }
        public async Task<int> Add(Users entity)
        {
            await _context.Userss.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public int Update(Users entity)
        {
            _context.Userss.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(Users entity)
        {
            entity.Deleted = "F";
			_context.Userss.Update(entity);
			return _context.SaveChanges();
		}
    }
}
