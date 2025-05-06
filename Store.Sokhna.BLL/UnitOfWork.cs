using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.BLL.Repositories;
using Store.Sokhna.DAL.Data.Contexts;
using Store.Sokhna.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.BLL
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly AppDbContext context;
        private UsersRepository _usersRepository;
        private UserssDatasRepository _userssDatasRepository;
        private PactRepository _PactRepository;
        private EquipmentsRepository _EquipmentsRepository;
        private ExpensesRepository _ExpensesRepository;
        private Supplies_IncomeRepository _Supplies_IncomeRepository;
        private Supplies_OutcomeRepository _Supplies_OutcomeRepository;
        private WorkersRepository _WorkersRepository;
        private WorkerSalariesRepository _WorkerSalariesRepository;
        private ImportersRepository _ImportersRepository;
        private ReportsRepository _ReportsRepository;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            _EquipmentsRepository = new EquipmentsRepository(context);
            _ExpensesRepository = new ExpensesRepository(context);
            _PactRepository = new PactRepository(context);
            _Supplies_IncomeRepository = new Supplies_IncomeRepository(context);
            _Supplies_OutcomeRepository = new Supplies_OutcomeRepository(context);
            _usersRepository = new UsersRepository(context);
            _userssDatasRepository = new UserssDatasRepository(context);
            _WorkerSalariesRepository = new WorkerSalariesRepository(context);
            _WorkersRepository = new WorkersRepository(context);
            _ImportersRepository = new ImportersRepository(context);
            _ReportsRepository = new ReportsRepository(context);
        }
        public UsersRepository usersRepository => _usersRepository;
        public UserssDatasRepository userssDatasRepository => _userssDatasRepository;
        public PactRepository pactRepository => _PactRepository;
        public EquipmentsRepository equipmentsRepository => _EquipmentsRepository;
        public ExpensesRepository expensesRepository => _ExpensesRepository;
        public Supplies_IncomeRepository supplies_IncomeRepository => _Supplies_IncomeRepository;
        public Supplies_OutcomeRepository supplies_OutcomeRepository => _Supplies_OutcomeRepository;
        public WorkerSalariesRepository workerSalariesRepository => _WorkerSalariesRepository;
        public WorkersRepository workersRepository => _WorkersRepository;
        public ImportersRepository importersRepository => _ImportersRepository;
        public ReportsRepository reportsRepository => _ReportsRepository;
    }
}
