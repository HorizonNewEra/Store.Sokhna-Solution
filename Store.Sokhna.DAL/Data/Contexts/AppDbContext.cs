using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Sokhna.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Users> Userss { get; set; }
        public DbSet<UserssDatas> UserssDatas { get; set; }
        public DbSet<Pact> Pacts { get; set; }
        public DbSet<Equipments> Equipmentss { get; set; }
        public DbSet<Expenses> Expensess { get; set; }
        public DbSet<Supplies_Outcome> Supplies_Outcomes { get; set; }
        public DbSet<Supplies_Income> Supplies_Incomes { get; set; }
        public DbSet<Importers> Importers { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<WorkersSalaries> WorkersSalaries { get; set; }
    }
}
