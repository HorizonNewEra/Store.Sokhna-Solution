using Store.Sokhna.BLL.Repositories;
using Store.Sokhna.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.BLL.Interfaces
{
    public interface IUnitofWork
    {
        public UsersRepository usersRepository { get; }
        public UserssDatasRepository userssDatasRepository { get; }
        public PactRepository pactRepository  { get; }
        public EquipmentsRepository equipmentsRepository { get; }
        public  ExpensesRepository expensesRepository { get; }
        public  Supplies_IncomeRepository supplies_IncomeRepository { get; }
        public  Supplies_OutcomeRepository supplies_OutcomeRepository { get; }
        public  WorkerSalariesRepository workerSalariesRepository { get; }
        public  WorkersRepository workersRepository { get; }
        public  ImportersRepository importersRepository { get; }
        public  ReportsRepository reportsRepository { get; }
    }
}
